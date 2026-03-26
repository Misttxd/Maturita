using JetBrains.Annotations;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static FishingEvent;

public class FishingEvent : MonoBehaviour
{
    [Header("Zďż˝kladnďż˝ reference")]
    public Canvas FishingMiniGameCanvas;
    public GameObject InteractWindow;
    public FishingMiniGame FishingMiniGameScript;
    public Timer TimerScript;
    public SpriteRenderer RybaSpriteRenderer;
    public GameObject RybaWindow;

    [HideInInspector] public bool ActionEnabled = false;
    [HideInInspector] public bool Collision = false;
    [HideInInspector] public bool InteractionEnabled = false;

    [Header("Interact key")]
    public KeyCode interactKey = KeyCode.E;

    public static FishingEvent Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Nastaven referenc pes GameManager
        InteractWindow = GameManager.Instance.InteractWindow;
        FishingMiniGameCanvas = GameManager.Instance.SliderCanvas.GetComponent<Canvas>(); // to stejne jako SliderCanvasCanvas
        InteractWindow = GameManager.Instance.InteractWindow;
        FishingMiniGameScript = FishingMiniGame.Instance;
        TimerScript = Timer.Instance;
        RybaSpriteRenderer = GameManager.Instance.RybaSprite.GetComponent<SpriteRenderer>();
        RybaWindow = GameManager.Instance.Ryba;
    }

   

    void FixedUpdate()
    {
        if ((RybaWindow.activeSelf == true) || (FishingMiniGameCanvas.enabled == true) || (FishingMiniGameScript.FishdexMenu.activeSelf == true) || (GameManager.Instance.FailWindow.activeSelf == true))
        {
            ActionEnabled = false;
            InteractionEnabled = false;
            InteractWindow.SetActive(false);
        }

        if ((RybaWindow.activeSelf == false) && (FishingMiniGameCanvas.enabled == false) && (FishingMiniGameScript.FishdexMenu.activeSelf == false) && (Collision == true) && (GameManager.Instance.FailWindow.activeSelf == false)) 
        {
            ActionEnabled = true;
            InteractionEnabled = true;
            InteractWindow.SetActive(true);
        }
            if (ActionEnabled == true) { 
            if ((Input.GetKey(interactKey)) && (Collision == true)) 
            {
            Debug.Log("E");
            FishingMiniGameScript.RandomFish();

            //kďż˝d pro upravovďż˝nďż˝ ryhclosti slideru podle vygenerovanďż˝ ryby
            FishingMiniGameScript.SliderSpeedModifier();
                
            FishingMiniGameCanvas.enabled = true;

                InteractWindow.SetActive(false);
                TimerScript.StartCountdown();
            }
        }
        if (((InteractionEnabled == true) && (ActionEnabled == true)) && (GameManager.Instance.FailWindow.activeSelf == false))
        {
            Debug.Log("InteractWindow.SetActive(true);");
            InteractWindow.SetActive(true);
        }
        else if ((InteractionEnabled == false) && (ActionEnabled == false))
        {
            //InteractWindow.SetActive(false);
        }
    }

    
    public void OnCollisionEnter2D(Collision2D collision)//Akce, kterďż˝ se stanou po kolizi s Rybnďż˝kem
    {
        if (collision.otherCollider.gameObject.name.StartsWith("Voda")) //Potďż˝eba rozliďż˝it GameObjecty podle jmďż˝na aby se mohl dynamicky mďż˝nil objekt, se kterďż˝m hrďż˝c koliduje
        {
            FishingMiniGameScript.FishingEventScript = collision.otherCollider.gameObject.GetComponent<FishingEvent>();
            Collision = true;
            ActionEnabled = true;
            Debug.Log("COLLISION ENTER");
            InteractWindow.SetActive(true);
            FixedUpdate();
            FishingMiniGameScript.TimerScript.ResetCountdown();
        }
    }
    

    private void OnCollisionExit2D(Collision2D collision) //Akce, kterďż˝ se stanou po ukonďż˝enďż˝ kolize s Rybnďż˝kem
    {
        Collision = false;
        ActionEnabled = false;
        Debug.Log("COLLISION EXIT");
        FishingMiniGameCanvas.enabled = false;
        InteractWindow.SetActive(false);
        InteractionEnabled = false;

        FishingMiniGameScript.ResetSliderProgress();
        FishingMiniGameScript.TimerScript.ResetCountdown();

        FishingMiniGameScript.FishingEventScript = null;
    }
}
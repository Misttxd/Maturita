using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [Header("Reference")]
    public GameObject InteractWindow;
    public GameObject Player;
    public GameObject UICanvas;
    public Canvas UICanvasCanvas;
    public GameObject SliderCanvas;
    public Canvas SliderCanvasCanvas;
    public Camera Cam;
    public Camera NewCam;
    public GameObject RybaSprite;
    public GameObject RybaWindowPrefab;
    public GameObject LakeSpawner;
    public MapGenerator MapGeneratorScript;
    public GameObject Ryba; //pravdepodobne neni potreba
    public GameObject FishRating;
    public GameObject FishdexMenu;
    public GameObject FailWindow;
    public Slider FishingSlider;
    public GameObject CatchCounterText;
    public GameObject RybaObrazek;
    public GameObject Stamp;
    public GameObject FishNameText;

    public static GameManager Instance { get; private set; }

    private void Awake() //Ukládání referencí + pøiøazování nìkterých do scény DontDestroyOnLoad
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        FishdexMenu = GameObject.Find("FishdexMenu");
        CatchCounterText = GameObject.Find("CatchCounterText");
        RybaObrazek = GameObject.Find("RybaObrazek");
        FishRating = GameObject.Find("FishRating");
        FishNameText = GameObject.Find("FishNameText");
        Stamp = GameObject.Find("Stamp");
        FishdexMenu.SetActive(false);

        InteractWindow = GameObject.Find("InteractWindow");
        DontDestroyOnLoad(InteractWindow);

        Player = GameObject.Find("PlayerT");

        UICanvas = GameObject.Find("UICanvas");
        DontDestroyOnLoad(UICanvas);

        SliderCanvas = GameObject.Find("CanvasSlider");
        DontDestroyOnLoad(SliderCanvas);
        SliderCanvas.SetActive(false);

        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        

        LakeSpawner = GameObject.Find("SpawnerLake");
        DontDestroyOnLoad(LakeSpawner);

        RybaSprite = GameObject.Find("RybaSprite");

        Ryba = GameObject.Find("Ryba");
        Ryba.SetActive(false);

        FailWindow = GameObject.Find("Fail");
        FailWindow.SetActive(false);

        

        FishingSlider = GameObject.Find("SliderT").GetComponent<Slider>();

        

        MapGeneratorScript = GameObject.Find("GeneratorMap").GetComponent<MapGenerator>();
        //MapGeneratorScript.LakeSpawnerScript = GameObject.Find("LakeSpawner").GetComponent<LakeSpawner>();

    }


    private void Update()
    {
        //MapGeneratorScript.LakeSpawnerScript = GameObject.Find("LakeSpawner").GetComponent<LakeSpawner>();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoadedGM;
        SceneManager.sceneUnloaded += OnSceneUnloadedGM;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoadedGM;
        SceneManager.sceneUnloaded -= OnSceneUnloadedGM;
    }

    public void OnSceneLoadedGM(Scene scene, LoadSceneMode mode)
    {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
       
        FishingMiniGame.Instance.FailWindow.SetActive(false); // tvori error pri prvnim spusteni ale neni to nic duleziteho, pravdepodobne by to slo jednoduse cele odstranit        

        FishingEvent.Instance.ActionEnabled = false;
        FishingEvent.Instance.Collision = false;
        FishingEvent.Instance.InteractionEnabled = false;
        

        SliderCanvas.GetComponent<Canvas>().enabled = false;
        FishingMiniGame.Instance.BarReset();
        
        Timer.Instance.ResetCountdown();
       
        Ryba.SetActive(false);
        FishdexMenu.SetActive(false);

        if (UICanvas != null)
        {
            UICanvasCanvas = UICanvas.GetComponent<Canvas>();
            UICanvasCanvas.worldCamera = Camera.main;
        }

        if (SliderCanvas != null)
        {
            SliderCanvasCanvas = SliderCanvas.GetComponent<Canvas>();
            SliderCanvasCanvas.worldCamera = Camera.main;
        }

        if ((SceneManager.GetActiveScene().name == "MapSelect") || (SceneManager.GetActiveScene().name == "MainMenu"))
        {
            UICanvas.SetActive(false);
            SliderCanvas.SetActive(false);
        }
        else
        {
            Player = GameObject.Find("PlayerT");
            Debug.Log("Finding Player...");
            FishdexMenu = GameObject.Find("FishdexMenu");
            MapGeneratorScript = GameObject.Find("GeneratorMap").GetComponent<MapGenerator>();
        }
        
    }

    public void OnSceneUnloadedGM(Scene scene)
    {
        UICanvas.SetActive(true);
        SliderCanvas.SetActive(true);
    }

}

using UnityEngine;

public class LakeSpawner : MonoBehaviour
{
    public Canvas fishingMiniGameCanvas;
    public GameObject InteractWindow;
    public FishingMiniGame fishingMiniGameScript;
    public Timer timerScript;
    public SpriteRenderer rybaSpriteRenderer;
    public GameObject rybaWindowPrefab;

    public static LakeSpawner Instance { get; private set; } //Pøidìluje reference pro novì spawnuté objekty rybníkù

    private void Start()
    {
        //fishingMiniGameCanvas = GameManager.Instance.SliderCanvasCanvas;
        //InteractWindow = GameManager.Instance.InteractWindow;
        //fishingMiniGameScript = FishingEvent.Instance;
        


        Instance = this;


        fishingMiniGameCanvas = GameManager.Instance.SliderCanvas.GetComponent<Canvas>();
        InteractWindow = GameManager.Instance.InteractWindow;
        fishingMiniGameScript = FishingMiniGame.Instance;
        timerScript = Timer.Instance;
        rybaSpriteRenderer = GameManager.Instance.RybaSprite.GetComponent<SpriteRenderer>();
        //rybaWindowPrefab = GameManager.Instance.Ryba;    //neni to nikde potreba je to k nice mu ale necham to tady pro budouci potreby (asi nebudou)
    }
}
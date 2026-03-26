using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // === Permanent UI & Prefab References (Assign in Prefab Inspector) ===
    [Header("Permanent UI & Prefabs")]
    public GameObject InteractWindow;
    public GameObject UICanvas;
    public GameObject SliderCanvas;
    public GameObject RybaWindowPrefab;
    public GameObject FishdexMenu;
    public GameObject FailWindow;
    public Slider FishingSlider;
    public GameObject CatchCounterText;
    public GameObject RybaObrazek;
    public GameObject Stamp;
    public GameObject FishNameText;
    public GameObject RybaSprite;

    // === Scene-Specific References (Managed by SceneInitializer) ===
    public PlayerMovement Player { get; private set; }
    public MapGenerator MapGeneratorScript { get; private set; }
    public Camera Cam { get; private set; }

    // === Other References ===
    [Header("Other/Legacy References")]
    public GameObject LakeSpawner;
    public GameObject Ryba; //pravdepodobne neni potreba
    public GameObject FishRating;
    public Canvas UICanvasCanvas;
    public Canvas SliderCanvasCanvas;
    public Camera NewCam;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoadedGM;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoadedGM;
    }
    
    // Public method for SceneInitializer to call
    public void RegisterSceneSpecificReferences(PlayerMovement player, MapGenerator mapGenerator, Camera sceneCamera)
    {
        Player = player;
        MapGeneratorScript = mapGenerator;
        Cam = sceneCamera;
        Debug.Log("Scene references registered successfully in GameManager.");

        // We can also re-link cameras for canvases here, ensuring it's always correct
        if (UICanvas != null)
        {
            UICanvas.GetComponent<Canvas>().worldCamera = Cam;
        }
        if (SliderCanvas != null)
        {
            SliderCanvas.GetComponent<Canvas>().worldCamera = Cam;
        }
    }

    private void OnSceneLoadedGM(Scene scene, LoadSceneMode mode)
    {
        // This method is now much cleaner.
        // Most logic is handled by SceneInitializer calling RegisterSceneSpecificReferences.

        if ((SceneManager.GetActiveScene().name == "MapSelect") || (SceneManager.GetActiveScene().name == "MainMenu"))
        {
            if (UICanvas != null) UICanvas.SetActive(false);
            if (SliderCanvas != null) SliderCanvas.SetActive(false);
        }
        else
        {
            if (UICanvas != null) UICanvas.SetActive(true);
            // SliderCanvas should be controlled by the fishing logic, so we ensure it's off on load
            if (SliderCanvas != null) SliderCanvas.SetActive(false);
        }
    }
}

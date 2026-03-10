using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class FishingMiniGame : MonoBehaviour, IDataPersistence
{
    [Header("Konfigurace slideru")]
    public Slider fishingSlider;
    float decreasingSpeed = 0.5f;
    private float progress = 0f;


    [Header("Základní reference")]
    public Canvas FishingMiniGameCanvas;
    public FishingEvent FishingEventScript;
    public GameObject RybaWindow;
    public GameObject InteractWindow;
    public GameObject FailWindow;
    public SpriteRenderer RybaSpriteRenderer;
    public Timer TimerScript;
    public GameObject FishdexMenu;


    [HideInInspector] public bool minigameCompleted = false;
    [HideInInspector] public string fishName;


    [Header("Booly pro odemèené ryby")]
    [HideInInspector] public bool ryba1 = false;
    [HideInInspector] public bool ryba2 = false;
    [HideInInspector] public bool ryba3 = false;
    [HideInInspector] public bool ryba4 = false;
    [HideInInspector] public bool ryba5 = false;
    [HideInInspector] public bool ryba6 = false;
    [HideInInspector] public bool ryba7 = false;
    [HideInInspector] public bool ryba8 = false;
    [HideInInspector] public bool ryba9 = false;
    [HideInInspector] public bool ryba10 = false;
    [HideInInspector] public bool ryba11 = false;
    [HideInInspector] public bool ryba12 = false;
    [HideInInspector] public bool ryba13 = false;
    [HideInInspector] public bool ryba14 = false;
    [HideInInspector] public bool ryba15 = false;

    [Header("Poèty chycených ryb")]
    [HideInInspector] public int ryba1Count = 0;
    [HideInInspector] public int ryba2Count = 0;
    [HideInInspector] public int ryba3Count = 0;
    [HideInInspector] public int ryba4Count = 0;
    [HideInInspector] public int ryba5Count = 0;
    [HideInInspector] public int ryba6Count = 0;
    [HideInInspector] public int ryba7Count = 0;
    [HideInInspector] public int ryba8Count = 0;
    [HideInInspector] public int ryba9Count = 0;
    [HideInInspector] public int ryba10Count = 0;
    [HideInInspector] public int ryba11Count = 0;
    [HideInInspector] public int ryba12Count = 0;
    [HideInInspector] public int ryba13Count = 0;
    [HideInInspector] public int ryba14Count = 0;
    [HideInInspector] public int ryba15Count = 0;

    [Header("Odemèené svìty")]
    [HideInInspector] public bool World2Unlocked = false;
    [HideInInspector] public bool World3Unlocked = false;

    [Header("Reference pro jednotlivé jména ryb")]
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;
    public TextMeshProUGUI Text4;
    public TextMeshProUGUI Text5;
    public TextMeshProUGUI Text6;
    public TextMeshProUGUI Text7;
    public TextMeshProUGUI Text8;
    public TextMeshProUGUI Text9;
    public TextMeshProUGUI Text10;
    public TextMeshProUGUI Text11;
    public TextMeshProUGUI Text12;
    public TextMeshProUGUI Text13;
    public TextMeshProUGUI Text14;
    public TextMeshProUGUI Text15;

    [Header("Reference pro GameObjety ryb ve fishdexu")]
    public GameObject Ryba1;
    public GameObject Ryba2;
    public GameObject Ryba3;
    public GameObject Ryba4;
    public GameObject Ryba5;
    public GameObject Ryba6;
    public GameObject Ryba7;
    public GameObject Ryba8;
    public GameObject Ryba9;
    public GameObject Ryba10;
    public GameObject Ryba11;
    public GameObject Ryba12;
    public GameObject Ryba13;
    public GameObject Ryba14;
    public GameObject Ryba15;

    public string SceneName;
    public static FishingMiniGame Instance { get; private set; }

    
    void Start()
    {
        Instance = this;
        FishingEventScript = FishingEvent.Instance;
        FishingMiniGameCanvas = GameManager.Instance.SliderCanvasCanvas;
        FishingMiniGameCanvas.enabled = false;


        fishingSlider = GameManager.Instance.FishingSlider;
        RybaWindow = GameManager.Instance.Ryba;
        InteractWindow = GameManager.Instance.InteractWindow;
        FailWindow = GameManager.Instance.FailWindow;
        RybaSpriteRenderer = GameManager.Instance.RybaSprite.GetComponent<SpriteRenderer>();
        TimerScript = Timer.Instance;
        FishdexMenu = GameManager.Instance.FishdexMenu;
}


    public void Update()
    {
        SceneName = SceneManager.GetActiveScene().name; //Uložení aktivní scény

        if (ryba1 == true)
        {
            Text1.color = Color.black;
            Ryba1.GetComponent<Button>().enabled = true;
        }
        if (ryba2 == true)
        {
            Text2.color = Color.black;
            Ryba2.GetComponent<Button>().enabled = true;
        }
        if (ryba3 == true)
        {
            Text3.color = Color.black;
            Ryba3.GetComponent<Button>().enabled = true;
        }
        if (ryba4 == true)
        {
            Text4.color = Color.black;
            Ryba4.GetComponent<Button>().enabled = true;
        }
        if (ryba5 == true)
        {
            Text5.color = Color.black;
            Ryba5.GetComponent<Button>().enabled = true;
        }
        if (ryba6 == true)
        {
            Text6.color = Color.black;
            Ryba6.GetComponent<Button>().enabled = true;
        }
        if (ryba7 == true)
        {
            Text7.color = Color.black;
            Ryba7.GetComponent<Button>().enabled = true;
        }
        if (ryba8 == true)
        {
            Text8.color = Color.black;
            Ryba8.GetComponent<Button>().enabled = true;
        }
        if (ryba9 == true)
        {
            Text9.color = Color.black;
            Ryba9.GetComponent<Button>().enabled = true;
        }
        if (ryba10 == true)
        {
            Text10.color = Color.black;
            Ryba10.GetComponent<Button>().enabled = true;
        }
        if (ryba11 == true)
        {
            Text11.color = Color.black;
            Ryba11.GetComponent<Button>().enabled = true;
        }
        if (ryba12 == true)
        {
            Text12.color = Color.black;
            Ryba12.GetComponent<Button>().enabled = true;
        }
        if (ryba13 == true)
        {
            Text13.color = Color.black;
            Ryba13.GetComponent<Button>().enabled = true;
        }
        if (ryba14 == true)
        {
            Text14.color = Color.black;
            Ryba14.GetComponent<Button>().enabled = true;
        }
        if (ryba15 == true)
        {
            Text15.color = Color.black;
            Ryba15.GetComponent<Button>().enabled = true;
        }


        if (FishingMiniGameCanvas.enabled == false)
        {
            progress = 0f;
        }

        void UpdateSliderValue()
        {
            fishingSlider.value = progress;
        }

        if (!minigameCompleted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                progress += 0.1f;
                UpdateSliderValue();
            }

            if (progress >= 1f)
            {
                minigameCompleted = true;
                ShowResult();
            }


            progress -= Time.deltaTime * decreasingSpeed;


            if (progress < 0)
            {
                progress = 0;
            }

            UpdateSliderValue();
        }

        if ((Input.GetKey(KeyCode.Escape)) && ((RybaWindow.activeInHierarchy) || (FailWindow.activeInHierarchy)))
        {
            Debug.Log("ESC2");
            RybaWindow.SetActive(false);
            FailWindow.SetActive(false);
            FishingEventScript.ActionEnabled = true; 

            if (FishingEventScript.ActionEnabled == true && FishingEventScript.Collision == true)
            {
                InteractWindow.SetActive(true);
            }
        }
    }


    public void BarReset()
    {
        progress = 0f;
        fishingSlider.value = progress;
        minigameCompleted = false;
        FishingMiniGameCanvas.enabled = false;
    }


    //                                                                 GENEROVÁNÍ RYB  

    private int[] starRatings = { 1, 2, 3, 4, 5 }; //tiery rarity (ve hvezdickach)
    private float[] starChances = { 55f, 26f, 13f, 4f, 2f }; //procentuální šance

    public string[][] fishesByStarW1 = new string[][] //ryby pro 1. svìt
    {
        new string[] { "ryba1" },   // 1* ryby
        new string[] { "ryba2" },   // 2* ryby
        new string[] { "ryba3" },   // 3* ryby
        new string[] { "ryba4" },   // 4* ryby
        new string[] { "ryba5" }    // 5* ryby
    };

    public string[][] fishesByStarW2 = new string[][] //ryby pro 2. svìt
    {
        new string[] { "ryba6" },   // 1* ryby
        new string[] { "ryba7" },   // 2* ryby
        new string[] { "ryba8" },   // 3* ryby
        new string[] { "ryba9" },   // 4* ryby
        new string[] { "ryba10" }    // 5* ryby
    };

    public string[][] fishesByStarW3 = new string[][] //ryby pro 3. svìt
    {
        new string[] { "ryba11" },   // 1* ryby
        new string[] { "ryba12" },   // 2* ryby
        new string[] { "ryba13" },   // 3* ryby
        new string[] { "ryba14" },   // 4* ryby
        new string[] { "ryba15" }    // 5* ryby
    };


    public void RandomFish()
    {
        float randomStar = Random.Range(0f, 100f);
        int starTier = ChooseStarTier(randomStar);

        fishName = ChooseFishFromStarTier(starTier);


        string fullPath = "Ryby/" + fishName;


        Sprite fishSprite = Resources.Load<Sprite>(fullPath);


        RybaSpriteRenderer.sprite = fishSprite;
        Debug.Log("loaded fish sprite: " + fullPath);
    }

    private int ChooseStarTier(float randomStar)
    {
        float cumulativeChance = 0f;
        for (int i = 0; i < starChances.Length; i++)
        {
            cumulativeChance += starChances[i];
            if (randomStar <= cumulativeChance)
            {
                return starRatings[i];
            }
        }
        return starRatings[starRatings.Length - 1];
    }

    private string ChooseFishFromStarTier(int starTier)
    {

        int starIndex = starTier - 1;
        if ((SceneName == "World1") || (SceneName == "World11"))
        {
            
            string[] fishes = fishesByStarW1[starIndex];
            int randomFishIndex = Random.Range(0, fishes.Length);
            return fishes[randomFishIndex];
        }
        else if (SceneName == "World2")
        {
            string[] fishes = fishesByStarW2[starIndex];
            int randomFishIndex = Random.Range(0, fishes.Length);
            return fishes[randomFishIndex];
        }
        else if (SceneName == "World3")
        {
            string[] fishes = fishesByStarW3[starIndex];
            int randomFishIndex = Random.Range(0, fishes.Length);
            return fishes[randomFishIndex];
        }
        else 
        {
            Debug.LogWarning("WORLD ELSE (klikni pro info)");
            string[] fishes = fishesByStarW3[starIndex];
            int randomFishIndex = Random.Range(0, fishes.Length);
            return fishes[randomFishIndex];
            
        }

    }

    //                                                                 GENEROVÁNÍ RYB  

    void ShowResult()
    {
        if (minigameCompleted)
        {
            Debug.Log("Ulovil jsi rybu!");
            FishingMiniGameCanvas.enabled = false;
            BarReset();
            TimerScript.ResetCountdown();

            RybaWindow.SetActive(true);


            if (fishName == "ryba1")
            {
                ryba1Count += 1;
                ryba1 = true;
                Debug.Log("ryba1 true");
            }
            else if (fishName == "ryba2")
            {
                ryba2Count += 1;
                ryba2 = true;
                Debug.Log("ryba2 true");
            }
            else if (fishName == "ryba3")
            {
                ryba3Count += 1;
                ryba3 = true;
                Debug.Log("ryba3 true");
            }
            else if (fishName == "ryba4")
            {
                ryba4Count += 1;
                ryba4 = true;
                Debug.Log("ryba4 true");
            }
            else if (fishName == "ryba5")
            {
                ryba5Count += 1;
                ryba5 = true;
                Debug.Log("ryba5 true");


                World2Unlocked = true;
            }
            else if (fishName == "ryba6")
            {
                ryba6Count += 1;
                ryba6 = true;
                Debug.Log("ryba6 true");
            }
            else if (fishName == "ryba7")
            {
                ryba7Count += 1;
                ryba7 = true;
                Debug.Log("ryba7 true");
            }
            else if (fishName == "ryba8")
            {
                ryba8Count += 1;
                ryba8 = true;
                Debug.Log("ryba8 true");

            }
            else if (fishName == "ryba9")
            {
                ryba9Count += 1;
                ryba9 = true;
                Debug.Log("ryba9 true");
            }
            else if (fishName == "ryba10")
            {
                ryba10Count += 1;
                ryba10 = true;
                Debug.Log("ryba10 true");



                World3Unlocked = true;
            }
            else if (fishName == "ryba11")
            {
                ryba11Count += 1;
                ryba11 = true;
                Debug.Log("ryba11 true");
            }
            else if (fishName == "ryba12")
            {
                ryba12Count += 1;
                ryba12 = true;
                Debug.Log("ryba12 true");
            }
            else if (fishName == "ryba13")
            {
                ryba13Count += 1;
                ryba13 = true;
                Debug.Log("ryba13 true");
            }
            else if (fishName == "ryba14")
            {
                ryba14Count += 1;
                ryba14 = true;
                Debug.Log("ryba14 true");
            }
            else if (fishName == "ryba15")
            {
                ryba15Count += 1;
                ryba15 = true;
                Debug.Log("ryba15 true");
            }
        }

        else
        {
            Debug.Log("Ryba unikla! :(");
        }
    }

    public void ResetSliderProgress()
    {
        progress = 0f;
        Debug.Log("resetsliderprogress");
    }

    public void SliderSpeedModifier()
    {
        if ((fishName == "ryba1") || (fishName == "ryba6") || (fishName == "ryba11"))
        {
            decreasingSpeed = 0.1f;
            Debug.Log("1*");
        }
        else if ((fishName == "ryba2") || (fishName == "ryba7") || (fishName == "ryba12"))
        {
            decreasingSpeed = 0.2f;
            Debug.Log("2*");
        }
        else if ((fishName == "ryba3") || (fishName == "ryba8") || (fishName == "ryba13"))
        {
            decreasingSpeed = 0.4f;
            Debug.Log("3*");
        }
        else if ((fishName == "ryba4") || (fishName == "ryba9") || (fishName == "ryba14"))
        {
            decreasingSpeed = 0.6f;
            Debug.Log("4*");
        }
        else if ((fishName == "ryba5") || (fishName == "ryba10") || (fishName == "ryba15"))
        {
            decreasingSpeed = 0.8f;
            Debug.Log("5*");
        }
    }

    public void UloveneRyby()
    {
        if (fishName == "ryba1")
        {
            ryba1 = true;
            Debug.Log("ryba1 true");
        }
        else if (fishName == "ryba2")
        {
            ryba2 = true;
            Debug.Log("ryba2 true");
        }
        else if (fishName == "ryba3")
        {
            ryba3 = true;
            Debug.Log("ryba3 true");
        }
        else if (fishName == "ryba4")
        {
            ryba4 = true;
            Debug.Log("ryba4 true");
        }
        else if (fishName == "ryba5")
        {
            ryba5 = true;
            Debug.Log("ryba5 true");
        }
        else if (fishName == "ryba6")
        {
            ryba6 = true;
            Debug.Log("ryba6 true");
        }
        else if (fishName == "ryba7")
        {
            ryba7 = true;
            Debug.Log("ryba7 true");
        }
    }

    public void LoadData(GameData data) //Nahrávání dat pøes persistance manager do jednotlivých promìnných po loadnutí hry
    {
        this.ryba1Count = data.ryba1Count;
        this.ryba2Count = data.ryba2Count;
        this.ryba3Count = data.ryba3Count;
        this.ryba4Count = data.ryba4Count;
        this.ryba5Count = data.ryba5Count;
        this.ryba6Count = data.ryba6Count;
        this.ryba7Count = data.ryba7Count;
        this.ryba8Count = data.ryba8Count;
        this.ryba9Count = data.ryba9Count;
        this.ryba10Count = data.ryba10Count;
        this.ryba11Count = data.ryba11Count;
        this.ryba12Count = data.ryba12Count;
        this.ryba13Count = data.ryba13Count;
        this.ryba14Count = data.ryba14Count;
        this.ryba15Count = data.ryba15Count;

        this.ryba1 = data.ryba1;
        this.ryba2 = data.ryba2;
        this.ryba3 = data.ryba3;
        this.ryba4 = data.ryba4;
        this.ryba5 = data.ryba5;
        this.ryba6 = data.ryba6;
        this.ryba7 = data.ryba7;
        this.ryba8 = data.ryba8;
        this.ryba9 = data.ryba9;
        this.ryba10 = data.ryba10;
        this.ryba11 = data.ryba11;
        this.ryba12 = data.ryba12;
        this.ryba13 = data.ryba13;
        this.ryba14 = data.ryba14;
        this.ryba15 = data.ryba15;

        this.World2Unlocked = data.World2Unlocked;
        this.World3Unlocked = data.World3Unlocked;
        
    }

    public void SaveData(ref GameData data) //Ukládání dat pøes persistance manager do gamefily
    {
        data.ryba1Count = this.ryba1Count;
        data.ryba2Count = this.ryba2Count;
        data.ryba3Count = this.ryba3Count;
        data.ryba4Count = this.ryba4Count;
        data.ryba5Count = this.ryba5Count;
        data.ryba6Count = this.ryba6Count;
        data.ryba7Count = this.ryba7Count;
        data.ryba8Count = this.ryba8Count;
        data.ryba9Count = this.ryba9Count;
        data.ryba10Count = this.ryba10Count;
        data.ryba11Count = this.ryba11Count;
        data.ryba12Count = this.ryba12Count;
        data.ryba13Count = this.ryba13Count;
        data.ryba14Count = this.ryba14Count;
        data.ryba15Count = this.ryba15Count;

        data.ryba1 = this.ryba1;
        data.ryba2 = this.ryba2;
        data.ryba3 = this.ryba3;
        data.ryba4 = this.ryba4;
        data.ryba5 = this.ryba5;
        data.ryba6 = this.ryba6;
        data.ryba7 = this.ryba7;
        data.ryba8 = this.ryba8;
        data.ryba9 = this.ryba9;
        data.ryba10 = this.ryba10;
        data.ryba11 = this.ryba11;
        data.ryba12 = this.ryba12;
        data.ryba13 = this.ryba13;
        data.ryba14 = this.ryba14;
        data.ryba15 = this.ryba15;

        data.World2Unlocked = this.World2Unlocked;
        data.World3Unlocked = this.World3Unlocked;
    }
}
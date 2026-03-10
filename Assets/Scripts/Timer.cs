using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float countdownDuration = 5f;

    private float timer;
    private bool countdownStarted = false;

    public GameObject FailWindow;

    public FishingMiniGame FishingMiniGameScript;

    public static Timer Instance { get; private set; }

    void Start()
    {
        Instance = this;
        FishingMiniGameScript = FishingMiniGame.Instance;

        timer = countdownDuration;
        UpdateTimerUI();
    } 

    void Update()
    {
        if (countdownStarted == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerUI();
            }
            else if (timer <= 0.1)
            {
                FailWindow.SetActive(true);
                Debug.Log("reset");
                ResetCountdown();
            }
        }
    }
    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
    }
    public void ResetCountdown()
    {
        countdownStarted = false;
        timer = 5f;
        FishingMiniGameScript.BarReset();
    }

    public void StartCountdown()
    {
        countdownStarted = true;
    }

    
}
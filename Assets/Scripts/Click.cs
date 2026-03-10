using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public GameObject FishdexMenu;
    bool FishdexMenuActive = false;

    public TextMeshProUGUI FishNameText;
    public TextMeshProUGUI CatchCounterText;
    public SpriteRenderer RybaObrazek;
    public SpriteRenderer FishRating;


    public void Start()
    {
        FishdexMenu = GameManager.Instance.FishdexMenu;

        FishNameText = GameManager.Instance.FishNameText.GetComponent<TextMeshProUGUI>();
        CatchCounterText = GameManager.Instance.CatchCounterText.GetComponent<TextMeshProUGUI>();
        RybaObrazek = GameManager.Instance.RybaObrazek.GetComponent<SpriteRenderer>();
        FishRating = GameManager.Instance.FishRating.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (FishdexMenuActive == true && Input.GetKeyDown(KeyCode.Escape))
        {
            FishdexMenuActive=false;
            FishdexMenu.SetActive(false);
        }
    }


    public void MapClick()
    {
        SceneManager.LoadSceneAsync("MapSelect");
        Debug.Log("MapClick");
    }

    public void InventoryClick()
    {
        Debug.Log("InventoryClick");
    }

    public void FishdexClick()
    {
        Debug.Log("FishdexClick");

        RybaObrazek.sprite = null;
        CatchCounterText.text = string.Empty;
        FishNameText.text = string.Empty;
        FishRating.sprite = null;

        FishdexMenuActive = !FishdexMenuActive;

        if (FishdexMenuActive == true) {
           FishdexMenu.SetActive(true);
        }

        else if (FishdexMenuActive == false)
        {
            FishdexMenu.SetActive(false);
        }
        
    }
}

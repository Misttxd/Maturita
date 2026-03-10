using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FishdexFishSelect : MonoBehaviour
{
    public SpriteRenderer RybaObrazek;
    public FishingMiniGame FishingMiniGameScript;
    public TextMeshProUGUI CatchCounterText;
    public TextMeshProUGUI FishNameText;
    public SpriteRenderer FishRating;

    public void Start()
    {
        RybaObrazek = GameObject.Find("RybaObrazek").GetComponent<SpriteRenderer>();
        CatchCounterText = GameObject.Find("CatchCounterText").GetComponent<TextMeshProUGUI>();
        FishNameText = GameObject.Find("FishNameText").GetComponent<TextMeshProUGUI>();
        FishRating = GameObject.Find("FishRating").GetComponent<SpriteRenderer>();

        FishingMiniGameScript = FishingMiniGame.Instance;
    }
    public void Update()
    {
        
    }
    public void Ryba1Click()
    {
        if (FishingMiniGameScript.ryba1 == true) { 
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba1");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba1Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text1.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star1");
            
        }
    }
    public void Ryba2Click()
    {
        if (FishingMiniGameScript.ryba2 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba2");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba2Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text2.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star2");
           
        }
    }
    public void Ryba3Click()
    {
        if (FishingMiniGameScript.ryba3 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba3");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba3Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text3.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star3");
            
        }
    }
    public void Ryba4Click()
    {
        if (FishingMiniGameScript.ryba4 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba4");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba4Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text4.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star4");
            
        }
    }
    public void Ryba5Click()
    {
        if (FishingMiniGameScript.ryba5 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba5");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba5Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text5.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star5");
            
        }
    }
    public void Ryba6Click()
    {
        if (FishingMiniGameScript.ryba6 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba6");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba6Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text6.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star1");
            
        }
    }
    public void Ryba7Click()
    {
        if (FishingMiniGameScript.ryba7 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba7");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba7Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text7.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star2");
            
        }
    }

    public void Ryba8Click()
    {
        if (FishingMiniGameScript.ryba8 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba8");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba8Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text8.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star3");
            
        }
    }

    public void Ryba9Click()
    {
        if (FishingMiniGameScript.ryba9 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba9");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba9Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text9.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star4");
           
        }
    }

    public void Ryba10Click()
    {
        if (FishingMiniGameScript.ryba10 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba10");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba10Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text10.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star5");
            
        }
    }

    public void Ryba11Click()
    {
        if (FishingMiniGameScript.ryba11 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba11");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba11Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text11.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star1");
            
        }
    }

    public void Ryba12Click()
    {
        if (FishingMiniGameScript.ryba12 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba12");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba12Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text12.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star2");
            
        }
    }

    public void Ryba13Click()
    {
        if (FishingMiniGameScript.ryba13 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba13");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba13Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text13.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star3");
            
        }
    }

    public void Ryba14Click()
    {
        if (FishingMiniGameScript.ryba14 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba14");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba14Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text14.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star4");
            
        }
    }

    public void Ryba15Click()
    {
        if (FishingMiniGameScript.ryba15 == true)
        {
            RybaObrazek.sprite = Resources.Load<Sprite>("Ryby/RRyba15");
            CatchCounterText.text = "Poèet ulovení: " + FishingMiniGameScript.ryba15Count.ToString();
            FishNameText.text = FishingMiniGameScript.Text15.text;
            FishRating.sprite = Resources.Load<Sprite>("StarBar/Star5");
            
        }
    }

}

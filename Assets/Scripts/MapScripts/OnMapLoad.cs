using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OnMapLoad : MonoBehaviour
{
    public SpriteRenderer MapSpriteRenderer; 
    public FishingMiniGame FishingMiniGameScript;
    

    void Start()

    {
        FishingMiniGameScript = FishingMiniGame.Instance; //Reference pro FishingMiniGameScript, Který se inicializuje po spawnutí rybníku, což v tomhle pøípadì nedìlá problém jelikož mapa prakticky nejde rozkliknout bez toho, aby se rybník inicializoval
        MapSpriteRenderer = GameObject.Find("Mapa").GetComponent<SpriteRenderer>(); //Reference obrázku mapy, pro zmìnu podle odemèených svìtù


        if (FishingMiniGameScript.World2Unlocked == false && FishingMiniGameScript.World3Unlocked == false)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Default1");
        }
        if (FishingMiniGameScript.World2Unlocked == true && FishingMiniGameScript.World3Unlocked == false)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Default2");
        }
        if (FishingMiniGameScript.World2Unlocked == true && FishingMiniGameScript.World3Unlocked == true)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Default3");
        }
    }
}

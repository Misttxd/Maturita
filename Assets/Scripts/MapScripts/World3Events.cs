using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class World3Events : MonoBehaviour
{

    public SpriteRenderer MapSpriteRenderer;
    public FishingMiniGame FishingMiniGameScript;

    void Start()
    {
        FishingMiniGameScript = FishingMiniGame.Instance;
        MapSpriteRenderer = GameObject.Find("Mapa").GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        if (FishingMiniGameScript.World3Unlocked == true)
        {
            Debug.Log("click3");
            SceneManager.LoadSceneAsync("Iceland");
        }
        
    }

    private void OnMouseEnter()
    {
        if (FishingMiniGameScript.World2Unlocked == false && FishingMiniGameScript.World3Unlocked == false)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Select31");
        }
        else if (FishingMiniGameScript.World2Unlocked == true && FishingMiniGameScript.World3Unlocked == false)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Select32");
        }
        else if (FishingMiniGameScript.World2Unlocked == true && FishingMiniGameScript.World3Unlocked == true)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Select33");
        }
    }

    private void OnMouseExit()
    {
        if (FishingMiniGameScript.World2Unlocked == false && FishingMiniGameScript.World3Unlocked == false)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Default1");
        }
        else if (FishingMiniGameScript.World2Unlocked == true && FishingMiniGameScript.World3Unlocked == false)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Default2");
        }
        else if (FishingMiniGameScript.World2Unlocked == true && FishingMiniGameScript.World3Unlocked == true)
        {
            MapSpriteRenderer.sprite = Resources.Load<Sprite>("MapTextures/Default3");
        }
    }
}

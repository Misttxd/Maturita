using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWindowLocation : MonoBehaviour //Jednoduchý script pro dynamické mìnìní pozice okna interakce podle pozice hráèe
{
    [Header("Reference")]
    public GameObject Player;
    public GameObject InteractWindow;

    [Header("Hodnoty pozic")]
    float X, Y;

    public void Awake()
    {
        InteractWindow = GameManager.Instance.InteractWindow;
        this.gameObject.SetActive(false);
    }

    private void Start()
    {
        Player = GameManager.Instance.Player;
    }
    
    void Update()
    {
        Player = GameManager.Instance.Player;

        X = Player.transform.position.x;
        Y = Player.transform.position.y;

        InteractWindow.transform.position = new Vector2(X, Y + 1.8f) ;
    }
}

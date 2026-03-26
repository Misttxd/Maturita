using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWindowLocation : MonoBehaviour //Jednoduchý script pro dynamické měnění pozice okna interakce podle pozice hráče
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

    void Update()
    {
        // Zkontroluje, jestli existuje GameManager a jestli má platnou referenci na hráče
        if (GameManager.Instance != null && GameManager.Instance.Player != null)
        {
            // Přiřadí herní objekt hráče. Toto opravuje chybu CS0029.
            Player = GameManager.Instance.Player.gameObject;

            X = Player.transform.position.x;
            Y = Player.transform.position.y;

            InteractWindow.transform.position = new Vector2(X, Y + 1.8f);
        }
    }
}

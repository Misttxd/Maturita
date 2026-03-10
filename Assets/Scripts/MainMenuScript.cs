using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Forest2");
        Debug.Log("PLAY GAME");
    }

    public void NewGame()
    {
        DataPersistenceManager.Instance.NewGame();
        SceneManager.LoadSceneAsync("Forest2");
        Debug.Log("NEW GAME");
    }

    public void LoadGame()
    {
        //Melo by stacit jenom SceneManager.LoadScene(1) jelikoz gameData se loadne pres OnSceneUnloaded() v DataPersistenceManager

        //DataPersistenceManager.Instance.LoadGame();
        SceneManager.LoadSceneAsync("Forest2");
        Debug.Log("LOAD GAME");
    }


    public void Settings()
    {
        Debug.Log("SETTINGS");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    
}

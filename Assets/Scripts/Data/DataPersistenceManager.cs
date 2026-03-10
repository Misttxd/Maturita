using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Confdig")]
    [SerializeField] private string fileName;


    public GameData gameData;
    private List<IDataPersistence> dataPersistanceObjects;
    private FileDataHandler dataHandler;

    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Našlo se více než jeden Data Persistence Manager ve scénì. Destroying the newest one");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded Called");

        this.dataPersistanceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded Called");
        SaveGame();
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        Debug.Log("LOADGAME");

        // naètení dat pomocí dataHandler
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("Nebyly nalezeny žádné data, založne novou hru");
            this.gameData = new GameData();
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistanceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("Nebyly nalezeny žádné data, založne novou hru");
            return;
        }

        // pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        //save that data to a file using the data handler
        dataHandler.Save(gameData);

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }

}

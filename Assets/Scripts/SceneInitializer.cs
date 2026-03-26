using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [Header("Scene-Specific References")]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private Camera sceneCamera;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterSceneSpecificReferences(player, mapGenerator, sceneCamera);
        }
        else
        {
            Debug.LogError("GameManager.Instance is not available. Cannot register scene references.");
        }
    }
}

using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Static reference to the singleton instance
    public static ResourceManager Instance;

    public int numIron = 0;

    void Awake()
    {
        // Check if there's already an instance of ResourceManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
        else
        {
            Instance = this; // Assign the instance
            DontDestroyOnLoad(gameObject); // Optional: Keeps the instance across scenes
        }
    }
}
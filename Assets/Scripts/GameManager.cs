using UnityEngine;
using UnityEngine.Events; // Required for UnityEvent

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Unity Events to serialize in the inspector
    public UnityEvent onStartGame;
    public UnityEvent onStopGame;

    private void Awake()
    {
        // Check if an instance of GameManager already exists
        if (Instance == null)
        {
            // If not, set this as the instance and make sure it persists across scenes
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one to ensure singleton
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        // Call any functions subscribed to onStartGame event
        onStartGame.Invoke();

        // Additional game start logic can be added here
        Debug.Log("Game Started");
    }

    public void StopGame()
    {
        // Call any functions subscribed to onStopGame event
        onStopGame.Invoke();

        // Additional game stop logic can be added here
        Debug.Log("Game Stopped");
    }
}

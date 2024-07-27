using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public LevelObject[] levels;
    public Text levelText;
    public Text starsText;
    public Text messageText;
    public AudioSource audioSource;

    private int currentLevel;
    private int collectedStars;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (Instance == this)
        {
            if (levels == null || levels.Length == 0)
            {
                Debug.LogError("Levels array is not set or empty.");
                return;
            }

            if (levelText == null || starsText == null || messageText == null || audioSource == null)
            {
                Debug.LogError("UI Text elements or AudioSource are not set.");
                return;
            }

            currentLevel = 0;
            collectedStars = 0;
            UpdateUI();
            PlayBackgroundMusic();
        }
    }

    public void CollectStar()
    {
        collectedStars++;
        Debug.Log("Star collected! Total stars: " + collectedStars);
        UpdateUI();
    }

    public void ShowStarCollectedMessage()
    {
        messageText.text = "I got a star!";
        StartCoroutine(ClearMessageAfterDelay(2f));
        Debug.Log("Star collected message displayed.");
    }

    private IEnumerator ClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.text = "";
    }

    public void CompleteLevel()
    {
        if (collectedStars >= levels[currentLevel].requiredStars)
        {
            Debug.Log("Level " + (currentLevel + 1) + " completed.");
            messageText.text = "Level Completed!";
            currentLevel++;
            collectedStars = 0;
            if (currentLevel >= levels.Length)
            {
                Debug.Log("All levels completed.");
                messageText.text = "All Levels Completed!";
            }
            else
            {
                UpdateUI();
                PlayBackgroundMusic();
            }
        }
        else
        {
            Debug.LogWarning("Not enough stars to complete the level.");
            messageText.text = "Not enough stars to complete the level!";
        }
    }

    void UpdateUI()
    {
        if (currentLevel < levels.Length)
        {
            levelText.text = "Level: " + (currentLevel + 1);
            starsText.text = "Stars: " + collectedStars + "/" + levels[currentLevel].requiredStars;
            messageText.text = "";
            Debug.Log("UI updated for level " + (currentLevel + 1));
        }
    }

    void PlayBackgroundMusic()
    {
        if (levels[currentLevel].backgroundMusic != null)
        {
            audioSource.clip = levels[currentLevel].backgroundMusic;
            audioSource.Play();
            Debug.Log("Playing background music for level " + (currentLevel + 1));
        }
        else
        {
            Debug.LogWarning("No background music set for level " + (currentLevel + 1));
        }
    }
}
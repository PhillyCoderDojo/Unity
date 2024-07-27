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
            currentLevel = 0;
            collectedStars = 0;
            UpdateUI();
        }
    }

    public void CollectStar()
    {
        collectedStars++;
        UpdateUI();
    }

    public void ShowStarCollectedMessage()
    {
        messageText.text = "I got a star!";
        StartCoroutine(ClearMessageAfterDelay(2f)); // Clear the message after 2 seconds
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
            messageText.text = "Level Completed!";
            currentLevel++;
            collectedStars = 0;
            if (currentLevel >= levels.Length)
            {
                messageText.text = "All Levels Completed!";
            }
            else
            {
                UpdateUI();
            }
        }
        else
        {
            messageText.text = "Not enough stars to complete the level!";
        }
    }

    void UpdateUI()
    {
        levelText.text = "Level: " + (currentLevel + 1);
        starsText.text = "Stars: " + collectedStars + "/" + levels[currentLevel].requiredStars;
        messageText.text = "";
    }
}
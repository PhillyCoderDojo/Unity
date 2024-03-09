using TMPro;
using UnityEngine;

public class StarPlayer : MonoBehaviour
{
    public int stars = 0; // An integer whole number
    
    public TMP_Text starText;
    
    public TMP_Text timeText;
    
    public GameMasterController gamemaster;
    // Update is called once per frame
    void Update()
    {
        starText.SetText("Stars: " + stars);
        if (stars < 3 && gamemaster.gameStarted == true)
        {
            timeText.SetText("Time: " + Mathf.Round(Time.time - gamemaster.startTime));
        }
      

    }
}

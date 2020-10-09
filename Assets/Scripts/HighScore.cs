using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int score = 100; // so we can reference it as Highscore from other screen.
    // Update is called once per frame
    //new in Oct0.9
    void awake()
    {
        //We will have a key in playerPrefs
        //Keyname: ApplePickerHighScore
        if (PlayerPrefs.HasKey("ApplePickerHighscore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighscore");
        }
        PlayerPrefs.SetInt("ApplePickerHighscore", score);
    }
    void Update()
    {
        score += 1;
        Text highScore = this.GetComponent<Text>();
        highScore.text = "Highscore: " + score.ToString();
        if(score > PlayerPrefs.GetInt("ApplePickerHighscore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighscore", score);
        }

    }
}

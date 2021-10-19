using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text textScoreUI;
    int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            UpdateTextScore();
        }
    }
    void Start()
    {
        textScoreUI = GetComponent<Text>();
    }

    void UpdateTextScore()
    {
        string scoreStr = string.Format("{0:000000}", score);
        textScoreUI.text = scoreStr;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    Text textTime;
    int seconds, minutes;
    float startTime,ellapsedTime;
    bool isStart;

    void Start()
    {
        isStart = false;
        textTime = GetComponent<Text>();
    }
    public void StartTimeCounter()
    {
        isStart = true;
        startTime = Time.time;
    }
    public void StopTimeCounter()
    {
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
            return;
        ellapsedTime = Time.time - startTime;
        minutes = (int)(ellapsedTime / 60);
        seconds = (int)(ellapsedTime % 60);
        textTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

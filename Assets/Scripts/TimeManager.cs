using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    //タイマーカウント用変数
    [SerializeField] private float timeLimit;
    public float currentTime;
    public bool timeCounting;

    [SerializeField] private GameObject timerObject;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = timerObject.GetComponent<TextMeshProUGUI>();

        currentTime = timeLimit;
    }

    public void Update()
    {

    }

    public void DisplayTime()
    {
        if (currentTime <= 0f)
        {
            tmp.text = "0 : 00";
            return;
        }

        int ss = (int)currentTime % 60;
        int mm = (int)currentTime / 60;
        int cscs = (int)(((currentTime % 60) - ss) * 100);

        if (currentTime < 60)
        {
            if(cscs < 10)
            {
                tmp.text = ss.ToString() + " . 0" + cscs.ToString();
            }
            else
            {
                tmp.text = ss.ToString() + " . " + cscs.ToString();
            }
            
        }
        else
        {
            if (ss < 10)
            {
                string i = mm.ToString() + " : 0" + ss.ToString();
                tmp.text = i;
            }
            else
            {
                string i = mm.ToString() + " : " + ss.ToString();
                tmp.text = i;
            }
        }
    }

    public void TimeCounter(bool c)
    {
        if (currentTime >= timeLimit) currentTime = timeLimit;
        if (c)
        {
            currentTime -= Time.deltaTime;
        }
    }

    public float GetTimeLimit()
    {
        return timeLimit;
    }

    public void SetTimeLimit(float i)
    {
        timeLimit = i;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public void SetCurrentTime(float i)
    {
        currentTime = i;
    }

}

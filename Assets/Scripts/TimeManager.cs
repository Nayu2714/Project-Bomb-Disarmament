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

    [SerializeField] private GameObject timerTextObject;
    [SerializeField] private GameObject timerBlackScreenTextObject;
    [SerializeField] private GameObject pointTextObject;
    private TextMeshProUGUI timerTextTMP;
    private TextMeshProUGUI timerBlackScreenTextTMP;
    private TextMeshProUGUI pointTextTMP;

    [SerializeField] private Color timerTextColor;
    [SerializeField] private Color blackScreenColor;

    private void Start()
    {
        timerTextTMP = timerTextObject.GetComponent<TextMeshProUGUI>();
        timerBlackScreenTextTMP = timerBlackScreenTextObject.GetComponent<TextMeshProUGUI>();
        pointTextTMP = pointTextObject.GetComponent<TextMeshProUGUI>();

        currentTime = timeLimit;
    }

    private void Update()
    {
        timerTextTMP.color = timerTextColor;
        timerBlackScreenTextTMP.color = blackScreenColor;
        pointTextTMP.color = blackScreenColor;
    }

    public void DisplayTime()
    {
        if (currentTime <= 0f)
        {
            pointTextTMP.color = timerTextColor;
            timerTextTMP.text = "00 00";
            return;
        }

        int ss = (int)currentTime % 60;
        int mm = (int)currentTime / 60;
        int cscs = (int)(((currentTime % 60) - ss) * 100);

        if (currentTime < 60)
        {
            pointTextTMP.color = timerTextColor;
            if (ss < 10)
            {
                if (cscs < 10)
                {
                    timerTextTMP.text = "0" + ss.ToString() + " 0" + cscs.ToString();
                }
                else
                {
                    timerTextTMP.text = "0" + ss.ToString() + " " + cscs.ToString();
                }
            }
            else
            {
                if (cscs < 10)
                {
                    timerTextTMP.text = ss.ToString() + " 0" + cscs.ToString();
                }
                else
                {
                    timerTextTMP.text = ss.ToString() + " " + cscs.ToString();
                }
            }


        }
        else
        {
            pointTextTMP.color = blackScreenColor;
            if (mm < 10)
            {
                if (ss < 10)
                {
                    string i = "0" + mm.ToString() + ":0" + ss.ToString();
                    timerTextTMP.text = i;
                }
                else
                {
                    string i = "0" + mm.ToString() + ":" + ss.ToString();
                    timerTextTMP.text = i;
                }
            }
            else
            {
                if (ss < 10)
                {
                    string i = mm.ToString() + ":0" + ss.ToString();
                    timerTextTMP.text = i;
                }
                else
                {
                    string i = mm.ToString() + ":" + ss.ToString();
                    timerTextTMP.text = i;
                }
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

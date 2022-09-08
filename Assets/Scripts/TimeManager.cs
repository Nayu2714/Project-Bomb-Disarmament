using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    //タイマーカウント用変数
    public float timer;
    [SerializeField] private bool counting = false;

    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(counting == true)
        {
            tmp.text = TimeCounter();
        }
    }

    private string TimeCounter()
    {
        if (timer == 0f) return "0 : 00";

        timer -= Time.deltaTime;
        int t = (int)timer;

        int ss = t % 60;
        int mm = t / 60;

        string i;

        if(ss < 10)
        {
            i = mm.ToString() + " : 0" + ss.ToString();
        }
        else
        {
            i = mm.ToString() + " : " + ss.ToString();
        }
        
        return i;
    }
}

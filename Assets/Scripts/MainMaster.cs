using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMaster : MonoBehaviour
{
    public bool bombed = false;
    private StrikesManager strikesManager;
    private TimeManager timeManager;

    public void Start()
    {
        strikesManager = this.GetComponent<StrikesManager>();
        timeManager = this.GetComponent<TimeManager>();
    }

    public void Update()
    {
        timeManager.DisplayTime();
        timeManager.TimeCounter(timeManager.timeCounting);
        if (!bombed)
        {
            if (strikesManager.GetStrikes() == 3)
            {
                Debug.Log("Bomb!!");
                bombed = true;
            }
        }
    }

}
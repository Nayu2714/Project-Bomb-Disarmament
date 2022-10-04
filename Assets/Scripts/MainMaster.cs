using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMaster : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;

    public void Start()
    {
        
    }

    public void Update()
    {
        timeManager.DisplayTime();
        timeManager.TimeCounter(timeManager.timeCounting);
    }

}

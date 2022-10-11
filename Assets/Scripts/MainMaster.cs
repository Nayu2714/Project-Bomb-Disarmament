using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMaster : MonoBehaviour
{
    public bool bombed = false;
    private StrikesManager strikesManager;
    private TimeManager timeManager;

    public GameObject timer;

    public int completedCount = 0;
    public int modules = 5;

    private AudioSource audioSource;
    [SerializeField] private AudioClip AC_exp;

    public void Start()
    {
        strikesManager = this.GetComponent<StrikesManager>();
        timeManager = this.GetComponent<TimeManager>();
        audioSource = this.GetComponent<AudioSource>();

        completedCount = 0;
    }

    public void Update()
    {
        timeManager.DisplayTime();

        if (!bombed)
        {
            timeManager.TimeCounter(true);
            if (timeManager.GetCurrentTime() < 0 || strikesManager.GetStrikes() == 3)
            {
                audioSource.PlayOneShot(AC_exp);
                Debug.Log("Bomb!!");
                bombed = true;
                return;
            }

            if(completedCount == modules)
            {
                Debug.Log("AllClear!!");
            }



        }
        else
        {
            timeManager.TimeCounter(false);
        }
    }

    public void AddCompletedCount()
    {
        completedCount++;
    }
}
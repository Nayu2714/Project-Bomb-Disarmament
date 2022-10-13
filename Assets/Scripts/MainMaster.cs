using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainMaster : MonoBehaviour
{
    public bool bombed = false;
    private StrikesManager strikesManager;
    private TimeManager timeManager;

    public int completedCount = 0;
    public int modules = 5;

    private AudioSource audioSource;
    [SerializeField] private AudioClip AC_exp;

    [SerializeField] List<GameObject> moduleList = new List<GameObject>();
    private GameObject timer;

    [SerializeField] private GameObject modulesObject;

    public void Start()
    {
        strikesManager = this.GetComponent<StrikesManager>();
        timeManager = this.GetComponent<TimeManager>();
        audioSource = this.GetComponent<AudioSource>();

        timer = GameObject.Find("Timer");

        completedCount = 0;

        for (int i = 0; i < modules + 1; i++)
        {
            Transform t = modulesObject.transform.Find(i.ToString()).transform;
            Instantiate(moduleList[Random.Range(0, moduleList.Count)]).transform.SetParent(t, false);
        }
        int rnd1 = Random.Range(0, modules + 1);
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

            if (completedCount >= modules)
            {
                Debug.Log("AllClear!!");
                bombed = true;
                return;
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
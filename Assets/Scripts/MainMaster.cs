using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainMaster : MonoBehaviour
{
    private bool begin = false;
    private bool bombed = false;
    
    private StrikesManager strikesManager;
    private TimeManager timeManager;

    public int completedCount = 0;
    public int modules = 6;

    private AudioSource audioSource;
    [SerializeField] private AudioClip AC_exp;

    [SerializeField] List<GameObject> moduleList = new List<GameObject>();
    private GameObject timer;

    [SerializeField] private GameObject modulesObject;

    public void Start()
    {
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographic = false;

        strikesManager = this.GetComponent<StrikesManager>();
        timeManager = this.GetComponent<TimeManager>();
        audioSource = this.GetComponent<AudioSource>();

        timer = GameObject.Find("Timer");

        completedCount = 0;

        /*********************************************///モジュール生成及び初期化プロセス

        GameObject[] go = new GameObject[6];
        go[Random.Range(0, modules)] = timer;

        for (int i = 0; i < modules; i++)
        {
            Transform t = modulesObject.transform.Find(i.ToString()).transform;

            if (go[i] != null)
            {
                if (go[i] == timer) timer.transform.SetParent(t, false);
                continue;
            }

            int rnd = Random.Range(0, moduleList.Count);
            go[i] = moduleList[rnd];

            Instantiate(moduleList[rnd]).transform.SetParent(t, false);
        }

        /*********************************************/

        StartCoroutine(DelayMethod(5.0f, () =>
        {
            begin = true;
        }));


    }

    public void Update()
    {
        timeManager.DisplayTime();
        if (begin)
        {
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
    }

    public void AddCompletedCount()
    {
        completedCount++;
    }

    private IEnumerator DelayMethod(float waitTime, System.Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
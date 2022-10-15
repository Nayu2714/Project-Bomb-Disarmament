using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
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

    private GameObject bsObj;

    [SerializeField] private int tenjiCounter;

    public void Start()
    {
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographic = false;

        strikesManager = this.GetComponent<StrikesManager>();
        timeManager = this.GetComponent<TimeManager>();
        audioSource = this.GetComponent<AudioSource>();

        timer = GameObject.Find("Timer");

        completedCount = 0;

        tenjiCounter = 0;

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

        StartCoroutine(DelayMethod(10.0f, () =>
        {
            begin = true;
        }));

        completedCount = 1;

        bsObj = GameObject.Find("Black Screen");
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
                    bsObj.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
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

    public void AddTenjiCounter()
    {
        tenjiCounter++;
    }

    public int GetTenjiCounter()
    {
        return tenjiCounter;
    }

    private IEnumerator DelayMethod(float waitTime, System.Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
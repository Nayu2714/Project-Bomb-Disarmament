using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletedManager : MonoBehaviour
{
    public GameObject completedSign = null;

    public void Start()
    {
        completedSign.SetActive(false);
    }

    public void completedDisplaying(bool c)
    {
        if (c)
        {
            completedSign.SetActive(true);
            GameObject.Find("Main Master").GetComponent<MainMaster>().AddCompletedCount();
        }
        else
        {
            completedSign.SetActive(false);
        }
    }

}

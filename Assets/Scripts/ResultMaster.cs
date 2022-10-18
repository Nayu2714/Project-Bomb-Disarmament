using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultMaster : MonoBehaviour
{
    public GameObject noExImg;
    public GameObject exImg;
    public GameObject resultObj;

    public void Start()
    {
        TextMeshProUGUI resultTMP = resultObj.GetComponent<TextMeshProUGUI>();
        if (MainMaster.allCompleted)
        {
            resultTMP.text = ("Success!!");
            noExImg.SetActive(true);
            exImg.SetActive(false);
        }
        else
        {
            resultTMP.text = ("Failed...");
            noExImg.SetActive(false);
            exImg.SetActive(true);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Main");

    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}

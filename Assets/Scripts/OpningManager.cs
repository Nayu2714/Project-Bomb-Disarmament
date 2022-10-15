using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Bson;

public class OpningManager : MonoBehaviour
{
    [SerializeField] private GameObject tipsObj;
    private TextMeshProUGUI tipsTMP;

    [SerializeField] private GameObject bsObj;
    private Color bsColor;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float tipsDisplayTime = 5f;

    private bool tipsAlphaZero = false;
    private bool tipsAlphaOne = false;
    private bool blackScreenRemoving = false;

    private float tipsTime;


    private void Start()
    {
        tipsTMP = tipsObj.GetComponent<TextMeshProUGUI>();
        tipsTMP.alpha = 0f;
        tipsTime = 0f;

        bsColor = bsObj.GetComponent<Image>().color;
        bsColor.b = 0f;
        bsColor.g = 0f;
        bsColor.r = 0f;
        bsColor.a = 1f;

        tipsAlphaZero = true;
        tipsAlphaOne = false;
        blackScreenRemoving = false;
    }

    private void Update()
    {
        if (tipsAlphaZero)
        {
            tipsTMP.alpha += speed * Time.deltaTime;
            if (tipsTMP.alpha >= 1f)
            {
                tipsAlphaZero = false;
                tipsAlphaOne = true;
            }
        }

        if (tipsAlphaOne)
        {
            tipsTime += Time.deltaTime;
            if (tipsTime >= tipsDisplayTime)
            {
                tipsTMP.alpha -= speed * Time.deltaTime;
                if (tipsTMP.alpha <= 0f)
                {
                    tipsAlphaOne = false;
                    blackScreenRemoving = true;
                }
            }
        }

        if (blackScreenRemoving)
        {
            bsColor.a = bsColor.a - speed * Time.deltaTime;
            bsObj.GetComponent<Image>().color = bsColor;
            if (bsColor.a <= 0f)
            {
                blackScreenRemoving = false;
            }
        }

    }
}

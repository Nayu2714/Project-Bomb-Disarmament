using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpningManager : MonoBehaviour
{
    [SerializeField] private GameObject tipsObj;
    private TextMeshProUGUI tipsTMP;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float tipsDisplayTime = 5f;

    private bool tipsAlphaZero = false;
    private bool tipsAlphaOne = false;
    private bool blackScreenZero = false;

    private float tipsTime;


    private void Start()
    {
        tipsTMP = tipsObj.GetComponent<TextMeshProUGUI>();
        tipsTMP.alpha = 0f;
        tipsTime = 0f;
        tipsAlphaZero = true;
    }

    private void Update()
    {
        if (tipsAlphaZero)
        {
            tipsTMP.alpha += speed * Time.deltaTime;
            if (tipsTMP.alpha >= 255f)
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
                    blackScreenZero = true;
                }
            }
        }

        if (blackScreenZero)
        {

        }

    }
}

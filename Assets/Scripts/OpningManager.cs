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

    private bool tipsAlphaZero = false;
    private bool tipsAlphaOne = false;

    private void Start()
    {
        tipsTMP = tipsObj.GetComponent<TextMeshProUGUI>();
        tipsTMP.alpha = 0f;
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


    }
}

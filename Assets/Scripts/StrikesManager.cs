using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StrikesManager : MonoBehaviour
{
    [Range(0, 3)] public int strikes = 0;//0‚©‚ç3‚Ü‚Å

    [SerializeField] private float cycle = 0.5f;
    private float time = 0;

    [SerializeField] private Behaviour strikeMark1;
    [SerializeField] private Behaviour strikeMark2;

    [Space(5)]
    [SerializeField] private AudioClip AC_strike;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (strikes == 0)
        {
            strikeMark1.enabled = false;
            strikeMark2.enabled = false;
        }
        else if (strikes == 1)
        {
            strikeMark1.enabled = true;
            strikeMark2.enabled = false;
        }
        else if (strikes == 2)
        {
            time += Time.deltaTime;
            var repeatValue = Mathf.Repeat(time, cycle);
            strikeMark1.enabled = repeatValue >= cycle * 0.5f;
            strikeMark2.enabled = repeatValue >= cycle * 0.5f;
        }
        else if (strikes == 3)
        {
            strikeMark1.enabled = true;
            strikeMark2.enabled = true;
        }
    }
    public int GetStrikes()
    {
        return strikes;
    }

    public void CountStrike()
    {
        audioSource.PlayOneShot(AC_strike);
        if (strikes >= 3)
        {
            return;
        }
        strikes++;
    }
}

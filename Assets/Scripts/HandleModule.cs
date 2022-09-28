using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleModule : MonoBehaviour
{
    public bool completed = false;

    [SerializeField] private GameObject handlePre;
    //[SerializeField] private GameObject light1;
    //[SerializeField] private GameObject light2;
    //[SerializeField] private GameObject light3;

    //ハンドルの実体
    private GameObject handleObject = null;

    //謎解き用の変数
    private int angle = 0 ;

    //ボタン制御用の変数
    private string Directions;
    private bool isClick;

    //コルーチン(非同期処理)
    bool coroutineBool = false; 

    //ボタン制御用
    public void ButtonLeft(){
        Directions = "L";
        isClick = true;
    }
    public void ButtonRight(){
        Directions = "R";
        isClick = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        //初期状態の設定
        handleObject = GameObject.Instantiate<GameObject>(handlePre);
        //int num = Random.Range(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick == true){

            if (Directions == "R")
            {
                if (!coroutineBool)
                {
                    coroutineBool = true;
                    isClick = true;
                    StartCoroutine("RightMove");
                    angle += 90 ;
                }
            }
            
            if (Directions == "L")
            {
                if (!coroutineBool)
                {
                    coroutineBool = true;
                    isClick = true;
                    StartCoroutine("LeftMove");
                    angle -= 90 ;
                }
            }
            //Debug.Log("angle = " + angle);

                //謎解き　その1
                /*
                if(num == 0){
                    if(angle == 270){
                    }
                }
                */
        }
    }

    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            handleObject.transform.Rotate(0, -1, 0);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
        isClick = false;
    }

    IEnumerator LeftMove()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            handleObject.transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
        isClick = false;
    }
}
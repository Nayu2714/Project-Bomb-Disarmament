using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TenjiModule : MonoBehaviour
{
    public bool completed = false;

    //[SerializeField] private GameObject modulePre;
    [SerializeField] private GameObject upperPre1;
    [SerializeField] private GameObject lowerPre1;
    [SerializeField] private GameObject decisionPre;
    /*
    [SerializeField] private GameObject TextPre2;
    [SerializeField] private GameObject TextPre3;
    [SerializeField] private GameObject TextPre4;
    [SerializeField] private GameObject TextPre5;
    */
    //[SerializeField] private Text choicetext1;

    public Text choicetext1;

    private GameObject UpperButton1 = null;
    private GameObject LowerButton1 = null;
    private GameObject decisionButton = null;

    //マウスカーソル制御用
    private Vector3 mouse;

    //テキスト表示用変数
        int n1=0;

    // Start is called before the first frame update
    void Start()
    {
        //ボタンの生成
        UpperButton1 = GameObject.Instantiate<GameObject>(upperPre1);
        LowerButton1 = GameObject.Instantiate<GameObject>(lowerPre1);
        decisionButton = GameObject.Instantiate<GameObject>(decisionPre);
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;

        string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        //ボタンを押す
        if(Input.GetMouseButtonDown(0)){
            //レイの生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1000.0f)){
                //Debug.DrawRay(ray.origin, ray.direction*1000, Color.red, 5, false);

                if(hit.collider.CompareTag("upper"))
                {
                    n1--;
                    if(n1 == -1){
                    n1=25;
                    }
                }
            else if(hit.collider.CompareTag("lower"))q
                {
                    n1++;
                    if(n1 == 26){
                    n1 = 0;
                    }
                }
                //Debug.Log("n1 = " + n1 );
            }
            Debug.Log("alpha = " + alpha[n1] );
        }
        choicetext1.text = alpha[n1].ToString();
    }
}

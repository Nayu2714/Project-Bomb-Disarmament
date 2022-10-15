using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleModule : MonoBehaviour
{
    public bool completed = false;

    [SerializeField] private GameObject handleObject;
    [SerializeField] private GameObject Leftbutton;
    [SerializeField] private GameObject Rightbutton;
    [SerializeField] private GameObject diamondlamp;
    [SerializeField] private GameObject lampUpper;
    [SerializeField] private GameObject lampMiddle;
    [SerializeField] private GameObject lampLower;

    [SerializeField] private GameObject clearObject;

    //マウスカーソル制御用
    private Vector3 mouse;

    //謎解き用の変数
    private int angle = 0;
    private int degree = 0;
    private int sumdegree = 0;
    private int n;
    private bool stage1 = false;
    private bool stage2 = false;
    private bool stage3 = false;

    //ピンク色の生成
    Color pink = new Color(0.933f, 0.509f, 0.933f, 1.0f);

    //コルーチン(非同期処理)
    bool coroutineBool = false; 

    // Start is called before the first frame update
    void Start()
    {
        //初期状態の設定
        clearObject.SetActive(false);
        lampUpper.GetComponent<Renderer>().material.color = Color.black;
        lampMiddle.GetComponent<Renderer>().material.color = Color.black;
        lampLower.GetComponent<Renderer>().material.color = Color.black;

        int num = Random.Range(0,6);
        n = num;
        degree = LampColor(num);
        sumdegree = degree;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        Debug.Log("degree = "+ degree +" sumdegree = "+ sumdegree +"angle ="+ angle);
        Debug.Log("stage1 = "+ stage1 +" stage2 = "+stage2 +" stage3 = "+stage3);
        /*
        if(stage2 == true){
                        Debug.Log("stage2 == true");
                    }else if(stage2 == false){
                        Debug.Log("stage2 == false");
                    }else{
                        Debug.Log("エラー");
                    }
                    */

        if(Input.GetMouseButtonDown(0)){
            //レイの生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1000.0f)){
                //Debug.DrawRay(ray.origin, ray.direction*1000, Color.red, 5, false);
                if(hit.collider.name == "ButtonLeft"){
                    if (!coroutineBool)
                    {
                        coroutineBool = true;
                        StartCoroutine("LeftMove");
                        angle -= 90 ;
                    }
                }else if(hit.collider.name == "ButtonRight"){
                    if (!coroutineBool)
                    {
                        coroutineBool = true;
                        StartCoroutine("RightMove");
                        angle += 90 ;
                    }
                }else if(hit.collider.name == "AnswerButton"){
                    if(stage1 == false){
                        if(angle == degree){
                            lampLower.GetComponent<Renderer>().material.color = Color.green;
                            int num = 0;
                                if  (n <= 2){
                                    num = Random.Range(3,6);
                            }else if(3 <= n){
                                    num = Random.Range(0,2);
                            }
                            degree = LampColor(num);
                            n = num;
                            sumdegree = sumdegree + degree;
                            stage1 = true;
                        }
                    }else if(stage1 == true && stage2 == false){
                            if(sumdegree == angle){
                                lampMiddle.GetComponent<Renderer>().material.color = Color.green;
                                int num = 0;
                                if  (n <= 2){
                                    num = Random.Range(3,6);
                            }else if(3 <= n){
                                    num = Random.Range(0,2);
                            }
                                degree = LampColor(num);
                                sumdegree = sumdegree + degree;
                                stage2 = true;
                                }
                    }else if(stage1 == true && stage2 == true){
                        if(sumdegree == angle){
                            lampUpper.GetComponent<Renderer>().material.color = Color.green;
                            stage3 = true;
                            completed = true;
                        }
                    }
                Debug.Log("エラー");
                }
            }
                
        }
        if(completed == true){
            clearObject.SetActive(true);
            return;
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
    }

    IEnumerator LeftMove()
    {
        for (int turn = 0; turn < 90; turn++)
        {
            handleObject.transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
    }

    //ダイヤランプ色決定関数
    int LampColor(int n){
        int angle = 0;
        if(n == 0){
            diamondlamp.GetComponent<Renderer>().material.color = pink;
            angle = 270;
        }else if(n == 1){
            diamondlamp.GetComponent<Renderer>().material.color = Color.blue;
            angle = 360;
        }else if(n == 2){
            diamondlamp.GetComponent<Renderer>().material.color = Color.green;
            angle = 180;
        }else if(n == 3){
            diamondlamp.GetComponent<Renderer>().material.color = Color.white;
            angle = -360;
        }else if(n == 4){
            diamondlamp.GetComponent<Renderer>().material.color = Color.red;
            angle = -270;
        }else if(n == 5){
            diamondlamp.GetComponent<Renderer>().material.color = Color.yellow;
            angle = -180;
        }
        return angle;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireModule : MonoBehaviour
{
    public bool completed = false;

    //[SerializeField] private GameObject modulePre;
    [SerializeField] private GameObject wirePre1;
    [SerializeField] private GameObject cuttedwirePre1;
    [SerializeField] private GameObject wirePre2;
    [SerializeField] private GameObject cuttedwirePre2;
    [SerializeField] private GameObject wirePre3;
    [SerializeField] private GameObject cuttedwirePre3;
    [SerializeField] private GameObject wirePre4;
    [SerializeField] private GameObject cuttedwirePre4;
    [SerializeField] private GameObject wirePre5;
    [SerializeField] private GameObject cuttedwirePre5;
    [SerializeField] private GameObject wirePre6;
    [SerializeField] private GameObject cuttedwirePre6;

    [SerializeField] private GameObject clearmaruPre;

    //各実体
    //private GameObject moduleObject = null;
    private GameObject wireObject1 = null;
    private GameObject cuttedwireObject1 = null;
    private GameObject wireObject2 = null;
    private GameObject cuttedwireObject2 = null;
    private GameObject wireObject3 = null;
    private GameObject cuttedwireObject3 = null;
    private GameObject wireObject4 = null;
    private GameObject cuttedwireObject4 = null;
    private GameObject wireObject5 = null;
    private GameObject cuttedwireObject5 = null;
    private GameObject wireObject6 = null;
    private GameObject cuttedwireObject6 = null;

    private GameObject clearObject = null;

    //マウスカーソル制御用
    private Vector3 mouse;

    //ワイヤー生成用乱数
    int num;
    //正解のワイヤー
    int answernum;
    //プレイヤーが切ったワイヤー
    int playeranswer;

    // Start is called before the first frame update
    void Start()
    {
        //初期状態の設定
        Color newColor = new Color(0.933f, 0.509f, 0.933f, 1.0f);

        //ワイヤーの生成
        wireObject1 = GameObject.Instantiate<GameObject>(wirePre1);
        cuttedwireObject1 = GameObject.Instantiate<GameObject>(cuttedwirePre1);
        wireObject2 = GameObject.Instantiate<GameObject>(wirePre2);
        cuttedwireObject2 = GameObject.Instantiate<GameObject>(cuttedwirePre2);
        wireObject3 = GameObject.Instantiate<GameObject>(wirePre3);
        cuttedwireObject3 = GameObject.Instantiate<GameObject>(cuttedwirePre3);
        wireObject4 = GameObject.Instantiate<GameObject>(wirePre4);
        cuttedwireObject4 = GameObject.Instantiate<GameObject>(cuttedwirePre4);
        wireObject5 = GameObject.Instantiate<GameObject>(wirePre5);
        cuttedwireObject5 = GameObject.Instantiate<GameObject>(cuttedwirePre5);
        wireObject6 = GameObject.Instantiate<GameObject>(wirePre6);
        cuttedwireObject6 = GameObject.Instantiate<GameObject>(cuttedwirePre6);

        clearObject = GameObject.Instantiate<GameObject>(clearmaruPre);
       
       cuttedwireObject1.SetActive(false);
       cuttedwireObject2.SetActive(false);
       cuttedwireObject3.SetActive(false);
       cuttedwireObject4.SetActive(false);
       cuttedwireObject5.SetActive(false);
       cuttedwireObject6.SetActive(false);

       clearObject.SetActive(false);

       num = Random.Range(0,20);
       wireColor(num, newColor);

    }

    // Update is called once per frame
    void Update()
    {
        
        mouse = Input.mousePosition;

        //ワイヤーの切断
        if(Input.GetMouseButtonDown(0)){
            //レイの生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1000.0f)){
                Debug.DrawRay(ray.origin, ray.direction*1000, Color.red, 5, false);
                //Debug.Log("hit collider's name = " + hit.collider.name);
                
                if(hit.collider.CompareTag("wire1")){
                        if(wireObject1.activeSelf){
                            wireObject1.SetActive(false);
                            cuttedwireObject1.SetActive(true);
                            playeranswer = 1;
                            Answercheck();
                        }
                }else if(hit.collider.CompareTag("wire2")){
                        if(wireObject2.activeSelf){
                            wireObject2.SetActive(false);
                            cuttedwireObject2.SetActive(true);
                            playeranswer = 2;
                            Answercheck();
                        }
                }else if(hit.collider.CompareTag("wire3")){
                        if(wireObject3.activeSelf){
                            wireObject3.SetActive(false);
                            cuttedwireObject3.SetActive(true);
                            playeranswer = 3;
                            Answercheck();
                        }
                }else if(hit.collider.CompareTag("wire4")){
                        if(wireObject4.activeSelf){
                            wireObject4.SetActive(false);
                            cuttedwireObject4.SetActive(true);
                            playeranswer = 4;
                            Answercheck();
                        }
        
                }else if(hit.collider.CompareTag("wire5")){
                        if(wireObject5.activeSelf){
                            wireObject5.SetActive(false);
                            cuttedwireObject5.SetActive(true);
                            playeranswer = 5;
                            Answercheck();
                        }
                }else if(hit.collider.CompareTag("wire6")){
                        if(wireObject6.activeSelf){
                            wireObject6.SetActive(false);
                            cuttedwireObject6.SetActive(true);
                            playeranswer = 6;
                            Answercheck();
                        }
                }
            }
        }
    }
    //ワイヤーパターン生成用関数
    void wireColor(int num, Color pink){
            if(num == 0){
                wireObject1.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject1.GetComponent<Renderer>().material.color = pink;
                wireObject2.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject2.GetComponent<Renderer>().material.color = pink;
                wireObject3.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject3.GetComponent<Renderer>().material.color = pink;
                wireObject4.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject4.GetComponent<Renderer>().material.color = pink;
                wireObject5.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.blue;
                wireObject6.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject6.GetComponent<Renderer>().material.color = pink;
                answernum = 5;
            }else if(num == 1){
                wireObject1.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.blue;
                wireObject2.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.red;
                wireObject3.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.green;
                wireObject4.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject4.GetComponent<Renderer>().material.color = pink;
                wireObject5.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.red;
                wireObject6.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.red;
                answernum = 2;
            }else if(num == 2){
                wireObject1.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.white;
                wireObject2.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject2.GetComponent<Renderer>().material.color = pink;
                wireObject3.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.red;
                wireObject4.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.green;
                wireObject5.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.blue;
                wireObject6.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.white;
                answernum = 6;
            }else if(num == 3){
                wireObject1.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.blue;
                wireObject2.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.white;
                wireObject3.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject3.GetComponent<Renderer>().material.color = pink;
                wireObject4.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.green;
                wireObject5.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.white;
                wireObject6.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.blue;
                answernum = 6;
            }else if(num == 4){
                wireObject1.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject2.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.white;
                wireObject3.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject4.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.red;
                wireObject5.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject5.GetComponent<Renderer>().material.color = pink;
                wireObject6.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.green;
                answernum = 3;
            }else if(num == 5){
                wireObject1.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.red;
                wireObject2.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.blue;
                wireObject3.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.green;
                wireObject4.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject4.GetComponent<Renderer>().material.color = pink;
                wireObject5.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.red;
                wireObject6.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.red;
                answernum = 2;
            }else if(num == 6){
                wireObject1.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.blue;
                wireObject2.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.blue;
                wireObject3.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.white;
                wireObject4.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject4.GetComponent<Renderer>().material.color = pink;
                wireObject5.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.white;
                wireObject6.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.blue;
                answernum = 3;
            }else if(num == 7){
                wireObject1.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.red;
                wireObject2.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.red;
                wireObject3.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject3.GetComponent<Renderer>().material.color = pink;
                wireObject4.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.red;
                wireObject5.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.white;
                wireObject6.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.black;
                answernum = 4;
            }else if(num == 8){
                wireObject1.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.green;
                wireObject2.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject2.GetComponent<Renderer>().material.color = pink;
                wireObject3.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.black;
                wireObject4.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.white;
                wireObject5.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.blue;
                wireObject6.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject6.GetComponent<Renderer>().material.color = pink;
                answernum = 4;
            }else if(num == 9){
                wireObject1.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.black;
                wireObject2.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject3.GetComponent<Renderer>().material.color = pink;
                cuttedwireObject3.GetComponent<Renderer>().material.color = pink;
                wireObject4.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.green;
                wireObject5.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject6.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.blue;
                answernum = 4;
            }else if(num == 10){
                wireObject1.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.blue;
                wireObject2.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.red;
                wireObject3.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.black;
                wireObject4.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.red;
                wireObject5.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.red;
                wireObject6.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.blue;
                answernum = 5;
            }else if(num == 11){
                wireObject1.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.blue;
                wireObject2.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.black;
                wireObject3.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.white;
                wireObject4.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.black;
                wireObject5.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.black;
                wireObject6.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.blue;
                answernum = 4;
            }else if(num == 12){
                wireObject1.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject2.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.black;
                wireObject3.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.red;
                wireObject4.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.blue;
                wireObject5.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.green;
                wireObject6.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.green;
                answernum = 2;
            }else if(num == 13){
                wireObject1.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.black;
                wireObject2.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.red;
                wireObject3.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.green;
                wireObject4.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject5.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.black;
                wireObject6.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.green;
                answernum = 2;
            }else if(num == 14){
                wireObject1.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.green;
                wireObject2.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.white;
                wireObject3.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject4.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.blue;
                wireObject5.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.white;
                wireObject6.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.white;
                answernum = 6;
            }else if(num == 15){
                wireObject1.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.green;
                wireObject2.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.black;
                wireObject3.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.white;
                wireObject4.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject5.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.blue;
                wireObject6.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.blue;
                answernum = 6;
            }else if(num == 16){
                wireObject1.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.white;
                wireObject2.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject3.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.white;
                wireObject4.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.white;
                wireObject5.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.white;
                wireObject6.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.white;
                answernum = 6;
            }else if(num == 17){
                wireObject1.GetComponent<Renderer>().material.color = Color.blue;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.blue;
                wireObject2.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.black;
                wireObject3.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject4.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.black;
                wireObject5.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.green;
                wireObject6.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.red;
                answernum = 3;
            }else if(num == 18){
                wireObject1.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.white;
                wireObject2.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.white;
                wireObject3.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.green;
                wireObject4.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.red;
                wireObject5.GetComponent<Renderer>().material.color = Color.yellow;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.yellow;
                wireObject6.GetComponent<Renderer>().material.color = Color.black;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.black;
                answernum = 3;
            }else if(num == 19){
                wireObject1.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject1.GetComponent<Renderer>().material.color = Color.red;
                wireObject2.GetComponent<Renderer>().material.color = Color.green;
                cuttedwireObject2.GetComponent<Renderer>().material.color = Color.green;
                wireObject3.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject3.GetComponent<Renderer>().material.color = Color.white;
                wireObject4.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject4.GetComponent<Renderer>().material.color = Color.red;
                wireObject5.GetComponent<Renderer>().material.color = Color.white;
                cuttedwireObject5.GetComponent<Renderer>().material.color = Color.white;
                wireObject6.GetComponent<Renderer>().material.color = Color.red;
                cuttedwireObject6.GetComponent<Renderer>().material.color = Color.red;
                answernum = 3;
            }
        //Debug.Log("num =" + num);
        return;
    }

    void Answercheck(){
            if(answernum == playeranswer){
                //Debug.Log(" Clear !! ");
                completed = true;
                if(completed == true){
                    clearObject.SetActive(true);
                }
            }else{
                //Debug.Log(" Bomb !! ");
            }
    }

}


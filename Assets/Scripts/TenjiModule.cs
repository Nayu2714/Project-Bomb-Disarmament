using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TenjiModule : MonoBehaviour
{
    public bool completed = false;
    public bool Tenjipattern;    //true → ケース1, false → ケース2

    [SerializeField] private GameObject FinalalphaText0;
    [SerializeField] private GameObject FinalalphaText1;
    [SerializeField] private GameObject FinalalphaText2;
    [SerializeField] private GameObject FinalalphaText3;
    [SerializeField] private GameObject FinalalphaText4;

    [SerializeField] private GameObject Tenjimonitor;

    [SerializeField] private GameObject TenjiblockPre;
    [SerializeField] private GameObject TenjiblockshadowPre;

    [SerializeField] private GameObject clearObject;

    List<int[,]> tenji = new List<int[,]>();
    private int[,] currentTenji = new int[5, 31];

    //マウスカーソル制御用
    private Vector3 mouse;

    //テキスト表示用変数
        int n0=0, n1=0, n2=0, n3=0, n4=0;

        string alphatext0 = "A";
        string alphatext1 = "A";
        string alphatext2 = "A";
        string alphatext3 = "A";
        string alphatext4 = "A";

    //点字
    private int TenjiNum;
    private int[,] tenji0 = 
    {
        {2,0,2,0,0,0,0,2,0,1,0,0,0,0,2,0,2,0,0,0,0,2,0,1,0,0,0,0,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //・・　・　　・・　・　　・
        {2,0,1,0,0,0,0,1,0,1,0,0,0,0,2,0,2,0,0,0,0,2,0,2,0,0,0,0,2,0,2},        //・　　　　　・・　・・　・・
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //・　　　・　　・　・・　・
        {2,0,1,0,0,0,0,1,0,2,0,0,0,0,1,0,2,0,0,0,0,2,0,2,0,0,0,0,2,0,1},
    };

    private int[,] tenji1 =
    {
        {1,0,2,0,0,0,0,2,0,2,0,0,0,0,1,0,2,0,0,0,0,2,0,2,0,0,0,0,2,0,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //　・　・・　　・　・・　・・
        {2,0,1,0,0,0,0,1,0,1,0,0,0,0,2,0,2,0,0,0,0,1,0,1,0,0,0,0,2,0,2},        //・　　　　　・・　　　　・・　
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //　・　　　　　　　　・　・
        {1,0,2,0,0,0,0,1,0,1,0,0,0,0,1,0,1,0,0,0,0,1,0,2,0,0,0,0,2,0,1},
    };

    private int[,] tenji2 =
    {
        {1,0,2,0,0,0,0,2,0,2,0,0,0,0,1,0,2,0,0,0,0,2,0,2,0,0,0,0,2,0,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //　・　　　　　・　・・　・・
        {2,0,1,0,0,0,0,2,0,2,0,0,0,0,2,0,2,0,0,0,0,2,0,1,0,0,0,0,2,0,1},        //・　　　　　・・　・　　・
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //　・　　　　　　　・　　・
        {1,0,2,0,0,0,0,2,0,2,0,0,0,0,1,0,1,0,0,0,0,2,0,1,0,0,0,0,2,0,1},
    };

    private int[,] tenji3 =
    {
        {2,0,2,0,0,0,0,2,0,1,0,0,0,0,2,0,2,0,0,0,0,2,0,1,0,0,0,0,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //・・　・　　・・　・　　・
        {2,0,1,0,0,0,0,1,0,1,0,0,0,0,2,0,1,0,0,0,0,2,0,1,0,0,0,0,2,0,2},        //・　　　　　・　　・　　・・
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //・　　　・　・　　・　　・
        {2,0,1,0,0,0,0,1,0,2,0,0,0,0,2,0,1,0,0,0,0,2,0,1,0,0,0,0,2,0,1},
    };

    private int[,] tenji4 =
    {
        {2,0,2,0,0,0,0,2,0,1,0,0,0,0,2,0,1,0,0,0,0,2,0,1,0,0,0,0,2,0,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //・・　・　　・　　・　　・
        {2,0,1,0,0,0,0,2,0,2,0,0,0,0,1,0,1,0,0,0,0,2,0,2,0,0,0,0,2,0,1},        //・　　・・　　　　・・　・
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},        //・　　　　　　　　・・　・
        {2,0,1,0,0,0,0,1,0,1,0,0,0,0,1,0,1,0,0,0,0,2,0,2,0,0,0,0,2,0,1},
    };
    

    private Vector3 a = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {

        //ここで bool Tenjipattern を分岐させる
        Tenjipattern = true;

        clearObject.SetActive(false);

        tenji.Add(tenji0);
        tenji.Add(tenji1);
        tenji.Add(tenji2);
        tenji.Add(tenji3);
        tenji.Add(tenji4);
        TenjiNum = Random.Range(0,4);

        if(Tenjipattern == false){
            if(TenjiNum == 3){
                TenjiNum = 4;
                }
            }
        Debug.Log("番号="+TenjiNum);
        
        currentTenji = tenji[TenjiNum];
        CreateTenji(currentTenji);
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;

        string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        //上下ボタンを押す
        if(Input.GetMouseButtonDown(0)){
            //レイの生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1000.0f)){
                //Debug.DrawRay(ray.origin, ray.direction*1000, Color.red, 5, false);


                if(hit.collider.name == "button0"){
                    n0 = alphacontrol(n0);
                }else if(hit.collider.name == "button1"){
                    n1 = alphacontrol(n1);
                }else if(hit.collider.name == "button2"){
                    n2 = alphacontrol(n2);
                }else if(hit.collider.name == "button3"){
                    n3 = alphacontrol(n3);
                }else if(hit.collider.name == "button4"){
                    n4 = alphacontrol(n4);
                }

                int alphacontrol(int n){

                    if(hit.collider.CompareTag("upper"))
                    {
                        n--;
                        if(n == -1){
                            n=25;
                        }
                    }
                else if(hit.collider.CompareTag("lower"))
                    {
                        n++;
                        if(n == 26){
                            n = 0;
                        }
                    }
                return n;
                }
                Debug.Log(n0+","+n1+","+n2+","+n3+","+n4);
            
            }
        }
            alphatext0 = alpha[n0].ToString();
        FinalalphaText0.GetComponent<TextMesh>().text = alphatext0;
            alphatext1 = alpha[n1].ToString();
        FinalalphaText1.GetComponent<TextMesh>().text = alphatext1;
            alphatext2 = alpha[n2].ToString();
        FinalalphaText2.GetComponent<TextMesh>().text = alphatext2;
            alphatext3 = alpha[n3].ToString();
        FinalalphaText3.GetComponent<TextMesh>().text = alphatext3;
            alphatext4 = alpha[n4].ToString();
        FinalalphaText4.GetComponent<TextMesh>().text = alphatext4;


        //決定ボタンを押す
        if(Input.GetMouseButtonDown(0)){
            //レイの生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //答え合わせ
            if(Physics.Raycast(ray, out hit, 1000.0f)){
                if(hit.collider.CompareTag("answer")){

                    /*
                    if(Tenjipattern == true){
                        Debug.Log("Tenjipattern == true");
                    }else if(Tenjipattern == false){
                        Debug.Log("Tenjipattern == false");
                    }else{
                        Debug.Log("エラー");
                    }
                    */

                    if(Tenjipattern == true){
                        if(TenjiNum == 0){
                            if(n0 == 4 && n1 == 13 && n2 == 9 && n3 == 14 && n4 == 24){     //enjoy
                            completed = true;
                            }
                        }else if(TenjiNum == 1){
                            if(n0 == 0 && n1 == 15 && n2 == 17 && n3 == 8 && n4 == 11){      //april
                                completed = true;
                            }
                        }else if(TenjiNum == 2){
                            if(n0 == 0 && n1 == 6 && n2 == 17 && n3 == 4 && n4 == 4){        //agree
                                completed = true;
                            }
                        }else if(TenjiNum == 3){
                            if(n0 == 4 && n1 == 13 && n2 == 4 && n3 == 12 && n4 == 24){      //enemy
                                completed = true;
                            }
                        }
                    }else if(Tenjipattern == false){
                        if(TenjiNum == 0){
                            if(n0 == 18 && n1 == 14 && n2 == 20 && n3 == 13 && n4 == 3){     //sound
                            completed = true;
                            }
                        }else if(TenjiNum == 1){
                            if(n0 == 2 && n1 == 7 && n2 == 0 && n3 == 17 && n4 == 19){      //chart
                                completed = true;
                            }
                        }else if(TenjiNum == 2){
                            if(n0 == 2 && n1 == 11 && n2 == 0 && n3 == 18 && n4 == 18){       //class
                                completed = true;
                            }
                        }else if(TenjiNum == 4){
                            if(n0 == 18 && n1 == 22 && n2 == 8 && n3 == 13 && n4 == 6){      //swing
                                completed = true;
                            }
                        }
                    }else{
                        Debug.Log("点字パターンエラー");
                    }
                }
            }
        }
        if(completed == true){
            clearObject.SetActive(true);
        }

    }

    //点字生成関数
    private void CreateTenji(int[,] Tenji){
        GameObject[] t = GameObject.FindGameObjectsWithTag("Tenji");
        Vector3 a = Tenjimonitor.transform.position;

        a.x = a.x - 58f;
        a.y = a.y + 50f;
        a.z = -100f;

        float n = a.x;

        for(int i = 0; i < Tenji.GetLength(0); i++){
            for(int j = 0; j < Tenji.GetLength(1); j++){
                int p = Tenji[i,j];
                if(p == 1){
                    Instantiate(TenjiblockPre, a, Quaternion.identity);
                }else if(p == 2){
                    Instantiate(TenjiblockshadowPre, a, Quaternion.identity);
                }
                a += new Vector3(3f, 0f, 0f);
            }
            
            a.x = n;
            a += new Vector3(0f, -3f, 0f);
        }
    }
}
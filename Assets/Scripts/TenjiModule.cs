using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TenjiModule : MonoBehaviour
{
    public bool completed = false;
    public bool Tenjipattern;    //true → ケース1, false → ケース2

    public MainMaster mainMaster;
    public StrikesManager strikesManager;
    public CursorManager cursorManager;
    public CompletedManager completedManager;

    [SerializeField] private GameObject FinalalphaText0;
    [SerializeField] private GameObject FinalalphaText1;
    [SerializeField] private GameObject FinalalphaText2;
    [SerializeField] private GameObject FinalalphaText3;
    [SerializeField] private GameObject FinalalphaText4;

    public GameObject button00;
    public GameObject button01;
    public GameObject button02;
    public GameObject button03;
    public GameObject button04;
    public GameObject button10;
    public GameObject button11;
    public GameObject button12;
    public GameObject button13;
    public GameObject button14;
    public GameObject answerButton;

    [SerializeField] private GameObject Tenjimonitor;

    [SerializeField] private GameObject TenjiblockPre;
    [SerializeField] private GameObject TenjiblockshadowPre;
    [SerializeField] private GameObject Blank;

    List<int[,]> tenji = new List<int[,]>();
    private int[,] currentTenji = new int[3, 14];

    //テキスト表示用変数
    int n0 = 0, n1 = 0, n2 = 0, n3 = 0, n4 = 0;

    string alphatext0 = "A";
    string alphatext1 = "A";
    string alphatext2 = "A";
    string alphatext3 = "A";
    string alphatext4 = "A";

    //点字
    private int TenjiNum;
    private int[,] tenji0 =
    {
        {2,2,0,2,1,0,2,2,0,2,1,0,2,1},     //・・　・　　・・　・　　・
        {2,1,0,1,1,0,2,2,0,2,2,0,2,2},        //・　　　・　　・　・・　・
        {2,1,0,1,2,0,1,2,0,2,2,0,2,1},
    };

    private int[,] tenji1 =
    {
        {1,2,0,2,2,0,1,2,0,2,2,0,2,2},     //　・　・・　　・　・・　・・
        {2,1,0,1,1,0,2,2,0,1,1,0,2,2},        //・　　　　　・・　　　　・・　     //　・　　　　　　　　・　・
        {1,2,0,1,1,0,1,1,0,1,2,0,2,1},
    };

    private int[,] tenji2 =
    {
        {1,2,0,2,2,0,1,2,0,2,2,0,2,2},
        {2,1,0,2,2,0,2,2,0,2,1,0,2,1},        //・　　　　　・・　・　　・
        {1,2,0,2,2,0,1,1,0,2,1,0,2,1},
    };

    private int[,] tenji3 =
    {
        {2,2,0,2,1,0,2,2,0,2,1,0,2,1},
        {2,1,0,1,1,0,2,1,0,2,1,0,2,2},        //・　　　　　・　　・　　・・       //・　　　・　・　　・　　・
        {2,1,0,1,2,0,2,1,0,2,1,0,2,1},
    };

    private int[,] tenji4 =
    {
        {2,2,0,2,1,0,2,1,0,2,1,0,2,1},//・　　・　　・　　・
        {2,1,0,2,2,0,1,1,0,2,2,0,2,1},        //・　　・・　　　　・・　・       //・　　　　　　　　・・　・
        {2,1,0,1,1,0,1,1,0,2,2,0,2,1},
    };

    [Space(5)]
    [SerializeField] private AudioClip AC_click;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        var master = GameObject.Find("Main Master");
        mainMaster = master.GetComponent<MainMaster>();
        strikesManager = master.GetComponent<StrikesManager>();
        cursorManager = master.GetComponent<CursorManager>();

        audioSource = this.GetComponent<AudioSource>();

        mainMaster.AddTenjiCounter();

        //ここで bool Tenjipattern を分岐させる
        Tenjipattern = true;

        tenji.Add(tenji0);
        tenji.Add(tenji1);
        tenji.Add(tenji2);
        tenji.Add(tenji3);
        tenji.Add(tenji4);
        TenjiNum = Random.Range(0, 4);

        if (Tenjipattern == false)
        {
            if (TenjiNum == 3)
            {
                TenjiNum = 4;
            }
        }
        Debug.Log("番号=" + TenjiNum);

        currentTenji = tenji[TenjiNum];
        CreateTenji(currentTenji);
    }

    // Update is called once per frame
    void Update()
    {
        string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        GameObject co = cursorManager.GetCursorObject();
        if (co != null)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (co == button00 || co == button10)
                {
                    n0 = alphacontrol(n0);
                    audioSource.PlayOneShot(AC_click);
                }
                else if (co == button01 || co == button11)
                {
                    n1 = alphacontrol(n1);
                    audioSource.PlayOneShot(AC_click);
                }
                else if (co == button02 || co == button12)
                {
                    n2 = alphacontrol(n2);
                    audioSource.PlayOneShot(AC_click);
                }
                else if (co == button03 || co == button13)
                {
                    n3 = alphacontrol(n3);
                    audioSource.PlayOneShot(AC_click);
                }
                else if (co == button04 || co == button14)
                {
                    n4 = alphacontrol(n4);
                    audioSource.PlayOneShot(AC_click);
                }

                if (co == answerButton)
                {
                    audioSource.PlayOneShot(AC_click);
                    /*
                    if(Tenjipattern == true){
                        Debug.Log("Tenjipattern == true");
                    }else if(Tenjipattern == false){
                        Debug.Log("Tenjipattern == false");
                    }else{
                        Debug.Log("エラー");
                    }
                    */
                    if (mainMaster.GetTenjiCounter() >= 2)
                    {
                        Tenjipattern = false;
                    }
                    else
                    {
                        Tenjipattern = true;
                    }

                    if (Tenjipattern == true)
                    {
                        if (TenjiNum == 0)
                        {
                            if (n0 == 4 && n1 == 13 && n2 == 9 && n3 == 14 && n4 == 24)
                            {     //enjoy
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                        else if (TenjiNum == 1)
                        {
                            if (n0 == 0 && n1 == 15 && n2 == 17 && n3 == 8 && n4 == 11)
                            {      //april
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                        else if (TenjiNum == 2)
                        {
                            if (n0 == 0 && n1 == 6 && n2 == 17 && n3 == 4 && n4 == 4)
                            {        //agree
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                        else if (TenjiNum == 3)
                        {
                            if (n0 == 4 && n1 == 13 && n2 == 4 && n3 == 12 && n4 == 24)
                            {      //enemy
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                    }
                    else if (Tenjipattern == false)
                    {
                        if (TenjiNum == 0)
                        {
                            if (n0 == 18 && n1 == 14 && n2 == 20 && n3 == 13 && n4 == 3)
                            {     //sound
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                        else if (TenjiNum == 1)
                        {
                            if (n0 == 2 && n1 == 7 && n2 == 0 && n3 == 17 && n4 == 19)
                            {      //chart
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                        else if (TenjiNum == 2)
                        {
                            if (n0 == 2 && n1 == 11 && n2 == 0 && n3 == 18 && n4 == 18)
                            {       //class
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                        else if (TenjiNum == 3)
                        {
                            if (n0 == 18 && n1 == 22 && n2 == 8 && n3 == 13 && n4 == 6)
                            {      //swing
                                completed = true;
                            }
                            else
                            {
                                strikesManager.CountStrike();
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("点字パターンエラー");
                    }
                }

                int alphacontrol(int n)
                {

                    if (co.CompareTag("upper"))
                    {
                        n--;
                        if (n == -1)
                        {
                            n = 25;
                        }
                    }
                    else if (co.CompareTag("lower"))
                    {
                        n++;
                        if (n == 26)
                        {
                            n = 0;
                        }
                    }
                    return n;
                }
                //Debug.Log(n0 + "," + n1 + "," + n2 + "," + n3 + "," + n4);
            }
        }
        alphatext0 = alpha[n0].ToString();
        FinalalphaText0.GetComponent<TextMeshProUGUI>().text = alphatext0;
        alphatext1 = alpha[n1].ToString();
        FinalalphaText1.GetComponent<TextMeshProUGUI>().text = alphatext1;
        alphatext2 = alpha[n2].ToString();
        FinalalphaText2.GetComponent<TextMeshProUGUI>().text = alphatext2;
        alphatext3 = alpha[n3].ToString();
        FinalalphaText3.GetComponent<TextMeshProUGUI>().text = alphatext3;
        alphatext4 = alpha[n4].ToString();
        FinalalphaText4.GetComponent<TextMeshProUGUI>().text = alphatext4;

        if (completed == true)
        {
            completedManager.completedDisplaying(true);
        }
    }

    //点字生成関数
    private void CreateTenji(int[,] Tenji)
    {
        Transform ts = Tenjimonitor.transform;
        foreach (Transform q in ts) Destroy(q.gameObject);

        for (int i = 0; i < Tenji.GetLength(0); i++)
        {
            for (int j = 0; j < Tenji.GetLength(1); j++)
            {
                int p = Tenji[i, j];
                if (p == 1)
                {
                    Instantiate(TenjiblockPre).transform.SetParent(ts, false);
                }
                else if (p == 2)
                {
                    Instantiate(TenjiblockshadowPre).transform.SetParent(ts, false);
                }
                else if (p == 0)
                {
                    Instantiate(Blank).transform.SetParent(ts, false);
                }
            }
        }
    }
}
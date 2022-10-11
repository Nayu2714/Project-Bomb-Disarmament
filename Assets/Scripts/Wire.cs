using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wire : MonoBehaviour
{
    public bool completed = false;
    public StrikesManager strikesManager;
    public CursorManager cursorManager;
    public CompletedManager completedManager;

    [Space(5)]

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

    [SerializeField] private Transform wire;

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

    //private GameObject clearObject = null;

    //マウスカーソル制御用
    private Vector3 mouse;

    //ワイヤー生成用乱数
    int num;
    //正解のワイヤー
    int answernum;
    //プレイヤーが切ったワイヤー
    int playeranswer;

    [Space(5)]
    [SerializeField] private AudioClip AC_cut;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        var master = GameObject.Find("Main Master");
        strikesManager = master.GetComponent<StrikesManager>();
        cursorManager = master.GetComponent<CursorManager>();

        audioSource = this.GetComponent<AudioSource>();

        //初期状態の設定
        Color newColor = new Color(0.933f, 0.509f, 0.933f, 1.0f);

        //モジュールの生成
        //moduleObject = GameObject.Instantiate<GameObject>(modulePre);

        /*
        //親子関係の構築
            wireObject1.transform.parent = moduleObject.transform;
            wireObject2.transform.parent = moduleObject.transform;
            wireObject3.transform.parent = moduleObject.transform;
            wireObject4.transform.parent = moduleObject.transform;
            wireObject5.transform.parent = moduleObject.transform;
            wireObject6.transform.parent = moduleObject.transform;
            cuttedwireObject1.transform.parent = moduleObject.transform;
            cuttedwireObject2.transform.parent = moduleObject.transform;
            cuttedwireObject3.transform.parent = moduleObject.transform;
            cuttedwireObject4.transform.parent = moduleObject.transform;
            cuttedwireObject5.transform.parent = moduleObject.transform;
            cuttedwireObject6.transform.parent = moduleObject.transform;
        */

        //ワイヤーの生成

        wireObject1 = Instantiate(wirePre1);
        wireObject1.transform.SetParent(wire, false);

        cuttedwireObject1 = Instantiate(cuttedwirePre1);
        cuttedwireObject1.transform.SetParent(wire, false);

        wireObject2 = Instantiate(wirePre2);
        wireObject2.transform.SetParent(wire, false);

        cuttedwireObject2 = Instantiate(cuttedwirePre2);
        cuttedwireObject2.transform.SetParent(wire, false);

        wireObject3 = Instantiate(wirePre3);
        wireObject3.transform.SetParent(wire, false);

        cuttedwireObject3 = Instantiate(cuttedwirePre3);
        cuttedwireObject3.transform.SetParent(wire, false);

        wireObject4 = Instantiate(wirePre4);
        wireObject4.transform.SetParent(wire, false);

        cuttedwireObject4 = Instantiate(cuttedwirePre4);
        cuttedwireObject4.transform.SetParent(wire, false);

        wireObject5 = Instantiate(wirePre5);
        wireObject5.transform.SetParent(wire, false);

        cuttedwireObject5 = Instantiate(cuttedwirePre5);
        cuttedwireObject5.transform.SetParent(wire, false);

        wireObject6 = Instantiate(wirePre6);
        wireObject6.transform.SetParent(wire, false);

        cuttedwireObject6 = Instantiate(cuttedwirePre6);
        cuttedwireObject6.transform.SetParent(wire, false);

        //clearObject = Instantiate(clearmaruPre);

        cuttedwireObject1.SetActive(false);
        cuttedwireObject2.SetActive(false);
        cuttedwireObject3.SetActive(false);
        cuttedwireObject4.SetActive(false);
        cuttedwireObject5.SetActive(false);
        cuttedwireObject6.SetActive(false);

        //clearObject.SetActive(false);

        num = Random.Range(0, 20);
        wireColor(num, newColor);

    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            if (Input.GetMouseButton(0))
            {
                if (cursorManager.GetCursorObject() == wireObject1)
                {
                    if (wireObject1.activeSelf)
                    {
                        audioSource.PlayOneShot(AC_cut);
                        wireObject1.SetActive(false);
                        cuttedwireObject1.SetActive(true);
                        playeranswer = 1;
                        Answercheck();
                    }
                }
                else if (cursorManager.GetCursorObject() == wireObject2)
                {
                    if (wireObject2.activeSelf)
                    {
                        audioSource.PlayOneShot(AC_cut);
                        wireObject2.SetActive(false);
                        cuttedwireObject2.SetActive(true);
                        playeranswer = 2;
                        Answercheck();
                    }
                }
                else if (cursorManager.GetCursorObject() == wireObject3)
                {
                    if (wireObject3.activeSelf)
                    {
                        audioSource.PlayOneShot(AC_cut);
                        wireObject3.SetActive(false);
                        cuttedwireObject3.SetActive(true);
                        playeranswer = 3;
                        Answercheck();
                    }
                }
                else if (cursorManager.GetCursorObject() == wireObject4)
                {
                    if (wireObject4.activeSelf)
                    {
                        audioSource.PlayOneShot(AC_cut);
                        wireObject4.SetActive(false);
                        cuttedwireObject4.SetActive(true);
                        playeranswer = 4;
                        Answercheck();
                    }

                }
                else if (cursorManager.GetCursorObject() == wireObject5)
                {
                    if (wireObject5.activeSelf)
                    {
                        audioSource.PlayOneShot(AC_cut);
                        wireObject5.SetActive(false);
                        cuttedwireObject5.SetActive(true);
                        playeranswer = 5;
                        Answercheck();
                    }
                }
                else if (cursorManager.GetCursorObject() == wireObject6)
                {
                    if (wireObject6.activeSelf)
                    {
                        audioSource.PlayOneShot(AC_cut);
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
    void wireColor(int num, Color pink)
    {
        if (num == 0)
        {
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
        }
        else if (num == 1)
        {
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
        }
        else if (num == 2)
        {
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
        }
        else if (num == 3)
        {
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
        }
        else if (num == 4)
        {
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
        }
        else if (num == 5)
        {
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
        }
        else if (num == 6)
        {
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
        }
        else if (num == 7)
        {
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
        }
        else if (num == 8)
        {
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
        }
        else if (num == 9)
        {
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
        }
        else if (num == 10)
        {
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
        }
        else if (num == 11)
        {
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
        }
        else if (num == 12)
        {
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
        }
        else if (num == 13)
        {
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
        }
        else if (num == 14)
        {
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
        }
        else if (num == 15)
        {
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
        }
        else if (num == 16)
        {
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
        }
        else if (num == 17)
        {
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
        }
        else if (num == 18)
        {
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
        }
        else if (num == 19)
        {
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

    void Answercheck()
    {
        if (answernum == playeranswer)
        {
            //Debug.Log(" Clear !! ");
            completed = true;
            completedManager.completedDisplaying(true);
        }
        else
        {
            strikesManager.CountStrike();
            //Debug.Log(" Bomb !! ");
        }
    }

}


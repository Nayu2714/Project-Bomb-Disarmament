using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMaster : MonoBehaviour
{
    public float rotate = 1.0f;
    public GameObject bomb;
    public GameObject bsObj;
    public Color bsColor = new Color(0f, 0f, 0f, 0f);
    private float speed = 1f;

    private bool start = false;

    public void Start()
    {
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographic = true;
        bsObj.GetComponent<Image>().color = bsColor;
        bsObj.SetActive(false);
        start = false;

    }
    public void Update()
    {
        bomb.transform.Rotate(new Vector3(rotate, 0, 0) * Time.deltaTime);

        if (start)
        {
            bsObj.SetActive(true);
            bsColor.a += speed * Time.deltaTime;
            bsObj.GetComponent<Image>().color = bsColor;
            if (bsColor.a >= 1f)
            {
                start = false;
                SceneManager.LoadScene("Main");
            }
        }

    }

    public void GameStart()
    {
        start = true;
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}

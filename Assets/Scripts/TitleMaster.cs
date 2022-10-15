using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMaster : MonoBehaviour
{
    public float rotate = 1.0f;
    public GameObject bomb;

    public void Start()
    {
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographic = true;
    }
    public void Update()
    {
        bomb.transform.Rotate(new Vector3(rotate, 0, 0) * Time.deltaTime);
    }

    public void GameStart()
    {
        FadeManager.Instance.LoadScene("Main", 3.0f);
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

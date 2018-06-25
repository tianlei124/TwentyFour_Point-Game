using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>

/// …

/// 退出事件触发
　　　/// </summary>
/// <param name=”Yes”>用于判断是否退出</param>

/// <returns></returns>

public class End : MonoBehaviour
{
    private Button Yes;
    // Use this for initialization
    void Start()
    {
    }
    void OnDestory()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onPlayClick()
    {
        //点击切换
        SceneManager.LoadScene("End", LoadSceneMode.Single);
    }

}


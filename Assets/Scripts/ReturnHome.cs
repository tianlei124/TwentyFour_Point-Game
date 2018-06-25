using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>

/// …

///返回初始界面
/// </summary>
/// <param name=”bthPlay”>定义一个按钮</param>
/// <returns></returns>
public class ReturnHome : MonoBehaviour {

    private Button bthPlay;
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
    /// <summary>

    /// …

    ///跳转场景
    /// </summary>
    /// <returns></returns>
    public void onPlayClick()
    {
        SceneManager.LoadScene("Welcome", LoadSceneMode.Single);//点击场景之后开始切换
    }
    /// <summary>

    /// …

    ///清空当前分数
    /// </summary>
    /// <returns></returns>
    public void clearsc() {//清空yourscore

        GameObject.Find("UI").SendMessage("clearyourscore");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <summary>

/// …

//让音乐组件跨场景时不要销毁
/// </summary>
/// <param name=” SoundButton”>定义音乐按钮</param>
/// <param name=” SoundButton_UI”>音乐按钮的子物体UI</param>
/// <param name=” high_score ”>定义最高分</param>
///<param name=” your_score ”>定义当前分/param>
/// <returns></returns>

public class DonntDestory : MonoBehaviour {
    public GameObject SoundButton;
    public GameObject SoundButton_UI;
    public int high_score = 0;//
    public int your_score = 0;//分数
    GameObject clone1;
    GameObject clone2;                  // 用来接收预制的克隆体  
    static bool isHaveClone = false;   // 静态变量，所有脚本共用，也就是保证预制只能被克隆一次，不会出现多个角色  

    // Use this for initialization  
    void Start()
    {
        if (!isHaveClone)
        {
            clone1 = (GameObject)GameObject.Instantiate(SoundButton);
            clone2 = (GameObject)GameObject.Instantiate(SoundButton_UI);
            isHaveClone = true;
        
             DontDestroyOnLoad(SoundButton);
          //   DontDestroyOnLoad(SoundButton_UI);//如果父物体被销毁，子物体一定被销毁，所以有父级的话子物体，要先保证父级的存在
        }
        SceneManager.LoadScene("Welcome", LoadSceneMode.Single);//点击场景之后开始切换

    }

    /// <summary>

    /// …

    //分数增加
    /// </summary>
    public void  yourscore() {
        your_score = your_score + 10;
        print(your_score);
    }
    /// <summary>

    /// …

    //判断最高分的取值
    /// </summary>
    public void highscore() {
        if (your_score > high_score)
            high_score = your_score;
    }
    /// <summary>

    /// …

    //清空最高分
    /// </summary>
    public void clearyourscore() {
        your_score = 0;
    }
    void Update() {
      
    }
    }

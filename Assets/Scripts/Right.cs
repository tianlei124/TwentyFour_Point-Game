using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// …

/// 点击正确弹窗之后触发的事件
/// </summary>
/// <param name=”failure”>//只要不成功，就弹出来失败的框</param>
/// <returns></returns>

public class Right : MonoBehaviour {
    public bool failure=true;//只要不成功，就弹出来失败的框
	// Use this for initialization
	void Start () {
    
    }

    /// <summary>

    /// …

    ///确认点击
    /// </summary>
    /// <param name=”flag_result ”>把判断结果是不是等于24的布尔值重置</param>
    /// <param name=”flag_numberofCard ”>把判断是不是给定的四张牌的布尔值重置</param>
    /// <param name=”flag_symbol”>把判断是否输入非法字符的布尔值重置</param>
    /// <returns></returns>

    public void checkright(){
      
        bool flag_result = GameObject.Find("InputCheck").GetComponent<InputCheck>().result;
        bool flag_numberofCard = GameObject.Find("InputCheck").GetComponent<InputCheck>().number_ofCard;
        bool flag_symbol = GameObject.Find("InputCheck").GetComponent<InputCheck>().symbol;  //三个布尔值，用来接受从InputCheck发送过来的

        if (flag_result == true && flag_symbol == true && flag_numberofCard == true)
        {

            gameObject.SetActive(true);//显示窗口,如果三个都为true，则这个窗口设置为活跃
            failure = false;

        }
        
    }
    public void Right_Buttonclick() {
        GameObject.Find("InputCheck").GetComponent<InputCheck>().result = false;
        GameObject.Find("InputCheck").GetComponent<InputCheck>().number_ofCard=true;
        GameObject.Find("InputCheck").GetComponent<InputCheck>().symbol=true;//重置三个判断的布尔值
        failure = true;//重置关于失败框的判定
        gameObject.SetActive(false);//窗口隐藏

    }
	// Update is called once per frame
	void Update () {
		
	}
}

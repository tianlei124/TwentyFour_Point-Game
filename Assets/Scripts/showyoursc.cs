using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>

/// …

//显示当前分数
/// </summary>
/// <param name=” yoursc”>当前分数的数字形式</param>
/// <param name=” text_yoursc”>当前分数的字符串形式</param>
/// <returns></returns>

public class showyoursc : MonoBehaviour {
    public int yoursc;
    string text_yoursc;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    /// <summary>

    /// …

    //对分数进行赋值
    /// </summary>
    /// <returns></returns>

    void Update () {
        yoursc = GameObject.Find("UI").GetComponent<DonntDestory>().your_score;
        text_yoursc = yoursc.ToString();
        this.gameObject.GetComponent<Text>().text = text_yoursc;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>

/// …

///控制最高分
/// </summary>
/// <returns></returns>
public class High_score : MonoBehaviour {
    public int a;

	// Use this for initialization
	void Start () {
      
    }
    /// <summary>

    /// …

    ///调用加分的函数
    /// </summary>
    /// <returns></returns>
    public void addscore() {
        GameObject.Find("UI").SendMessage("yourscore");
        GameObject.Find("UI").SendMessage("highscore");
    }
    // Update is called once per frame
    void Update () {
       
	}
}

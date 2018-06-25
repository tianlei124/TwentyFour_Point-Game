using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ask_Quit : MonoBehaviour {
    /// <summary>

    /// …

    ///询问框的显示控制
    /// </summary>
    /// <returns></returns>
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    /// <summary>

    /// …

    ///询问框设置为显示
    /// </summary>
    /// <returns></returns>
    public void SetActive() {

        gameObject.SetActive(true);//显示物体
    }
    /// <summary>

    /// …

    ///询问框设置为不显示
    /// </summary>
    /// <returns></returns>
    public void SetInactive()
    {
        gameObject.SetActive(false);//隐藏物体
    }
}

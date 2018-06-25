using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour {
    private int b;
	// 使用此方法初始化
	void Start () {
        b = GameObject.Find("Cube").GetComponent<test>().a;
    }
	
	//更新方法每帧调用一次
	void Update () {
     
        print(b);
	}
}

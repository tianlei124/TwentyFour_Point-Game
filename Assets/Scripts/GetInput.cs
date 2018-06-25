using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




/// <summary>

/// …

///接受用户输入
/// </summary>
/// <param name=”formula”>用这个字符串接受用户的输出</param>
/// <param name=” ifAccout ”>unity定义的输入框</param>
/// <returns></returns>
public class GetInput : MonoBehaviour {
    public string formula;//用来接收输入的字符串
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {       
        InputField ifAccout = GameObject.Find("InputField").GetComponent<InputField>();//定义一个InputField对象      
        formula = ifAccout.text;//把ifAccout的text赋值给formula，传给InputCheck        
    }
}

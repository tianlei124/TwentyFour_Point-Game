using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour {
    private int b;
	// Use this for initialization
	void Start () {
        b = GameObject.Find("Cube").GetComponent<test>().a;
    }
	
	// Update is called once per frame
	void Update () {
     
        print(b);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Inactive", 0.02f);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
    void Inactive() {
        gameObject.SetActive(false);//隐藏物体
    }

}

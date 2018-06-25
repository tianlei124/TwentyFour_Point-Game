using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>

/// …

/// 加载场景
　　　/// </summary>

/// <returns></returns>
public class LoadPlaying : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
	}
    void OnDestory() {
       
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void onPlayClick() {
        SceneManager.LoadScene("Playing", LoadSceneMode.Single);//点击场景之后开始切换
    }

    }


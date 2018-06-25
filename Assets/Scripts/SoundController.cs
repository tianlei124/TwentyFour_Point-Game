using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SoundController : MonoBehaviour {

    // Use this for initialization
    private Button btnPlay;
    private Button btnSound;//定义一个button
    private AudioSource audioSourceBG;//定义一个BGM
    public Sprite[] soundSprites;//定义一个数组，用来存放播放和静音两个状态的图片
    private Image imgSound;//这个是用来放两张喇叭图片的背景图片
    
    void Start () {
        getComponents();
        
        btnSound.onClick.AddListener(onSoundClick);//定义监听
	}
 
public  void OnDestorySoundListener() {
       
        btnSound.onClick.RemoveListener(onSoundClick);//结束监听
    }
  

    private void getComponents() {//寻找组件

        btnSound = transform.Find("btnSound").GetComponent<Button>();
        audioSourceBG = transform.Find("btnSound").GetComponent<AudioSource>();
        imgSound = transform.Find("btnSound").GetComponent<Image>();
    }
	// Update is called once per frame
	void Update () {
     
    }

    void onSoundClick() {
        if (audioSourceBG.isPlaying)
        {
            audioSourceBG.Pause();
            imgSound.sprite = soundSprites[1];//暂停时候用的图片
        }
        else {
            audioSourceBG.Play();
            imgSound.sprite = soundSprites[0];//播放时候用的图片
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showhighscore : MonoBehaviour {
    public int highsc;
    string text_highsc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highsc = GameObject.Find("UI").GetComponent<DonntDestory>().high_score;
        text_highsc = highsc.ToString();
        this.gameObject.GetComponent<Text>().text = text_highsc;

    }
}

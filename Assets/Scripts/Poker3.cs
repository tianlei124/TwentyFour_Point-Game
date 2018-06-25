using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Poker3 : MonoBehaviour
{

    public Sprite[] PokerSprites;//定义一个数组，用来存放13张扑克
    private Image imgPoker;//这个是显示的poker图片 
    public int randPoker3;//用来随机生成的种子                      
    void Start()
    {
        getComponents();//获得图片组建
        rand();//生成随机数
    }
    public void getComponents()
    {//寻找图片组件
        imgPoker = transform.gameObject.GetComponent<Image>();
    }
    public void rand()
    {//给随机种子赋值
        randPoker3 = Random.Range(0, 13);
    }
    public void randagain()
    {//这个函数作为点击fine和cool的触发事件，判定之后点击fine或者cool的时候，调用这个函数使得重新生成扑克牌
        getComponents();//获得图片组建
        rand();//生成随机数
    }
    // Update is called once per frame
    void Update()
    {
        imgPoker.sprite = PokerSprites[randPoker3];//显示的扑克图片
    }
}

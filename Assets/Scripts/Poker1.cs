using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>

/// …

/// 控制扑克的生成
///  <param name=”PokerSprites”>用来存放13张扑克的数组</param>
///   <param name=”imgPoke”>当前要显示的图片</param>
///   <param name=”randPoker1”>随机生成的牌的值</param>

/// </summary>

/// <returns></returns>

public class Poker1 : MonoBehaviour {
    public Sprite[] PokerSprites;//定义一个数组，用来存放13张扑克
    private Image imgPoker;//这个是显示的poker图片 
    public  int randPoker1;//随机生成的牌的数值                     
    void Start () {
        getComponents();//获得图片组建
        rand();//生成随机数
    }
    /// <summary>

    /// …

    ///获得图片组件

    /// </summary>

    /// <returns></returns>
    public void getComponents()
    {//寻找图片组件
        imgPoker = transform.gameObject.GetComponent<Image>();
    }
    /// <summary>

    /// …

    ///给随机数赋值

    /// </summary>

    /// <returns></returns>
    public void rand()
    {//给随机种子赋值
        randPoker1= Random.Range(0, 13);
    }
    /// <summary>

    /// …

    ///当点击fine，重新生成

    /// </summary>

    /// <returns></returns>
    public void randagain()
    {//这个函数作为点击fine和cool的触发事件，判定之后点击fine或者cool的时候，调用这个函数使得重新生成扑克牌
        getComponents();//获得图片组建
        rand();//生成随机数
    }
    // Update is called once per frame
    void Update () {
        imgPoker.sprite =PokerSprites[randPoker1];//显示的扑克图片
        
    }
}

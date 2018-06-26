using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour {
    public int Card1, Card2, Card3, Card4;//定义四张牌
    public bool Resulted = true;//用来判定有无解
	// Use this for initialization
     string s = "";
	void Start () {
     
    }
   public void GetCard()//把四张牌的值赋给四个变量，+1是因为索引是从0开始,这个函数要在Update里面使用，因为这四个值随时变化
    {
        Card1 = GameObject.Find("Poker1").GetComponent<Poker1>().randPoker1 + 1;
        Card2 = GameObject.Find("Poker2").GetComponent<Poker2>().randPoker2 + 1;
        Card3 = GameObject.Find("Poker3").GetComponent<Poker3>().randPoker3 + 1;
        Card4 = GameObject.Find("Poker4").GetComponent<Poker4>().randPoker4 + 1;
    }
	// Update is called once per frame
	void Update () {
        GetCard();
        Jugde(ref s);
        // print(Card1+"  "+Card2+"  "+Card3+"  "+Card4);//把结果打印出来
        if (Resulted == false)//如果无解就要重新生成
            SendtoPoker();//调用Poker里面的函数让它重新生成
      //  print(Resulted);
    }
    void SendtoPoker()//如果无解，就要把函数返回给Poker,让Poker重新生成
    {
        GameObject.Find("Poker1").GetComponent<Poker1>().randagain();
        GameObject.Find("Poker2").GetComponent<Poker2>().randagain();
        GameObject.Find("Poker3").GetComponent<Poker3>().randagain();
        GameObject.Find("Poker4").GetComponent<Poker4>().randagain();
    }
    //下面是24点核心算法
    void Jugde(ref string exp) {
        Resulted = Try24(Card1, Card2, Card3, Card4, ref exp);

    }
    private static bool Try24(int a, int b, int c, int d, ref string expression)
    {
        //a字头
        if (TryEach(a, b, c, d, ref expression)) return true;
        if (TryEach(a, b, d, c, ref expression)) return true;
        if (TryEach(a, c, b, d, ref expression)) return true;
        if (TryEach(a, c, d, b, ref expression)) return true;
        if (TryEach(a, d, b, c, ref expression)) return true;
        if (TryEach(a, d, c, b, ref expression)) return true;
        //b字头
        if (TryEach(b, a, c, d, ref expression)) return true;
        if (TryEach(b, a, d, c, ref expression)) return true;
        if (TryEach(b, c, a, d, ref expression)) return true;
        if (TryEach(b, c, d, a, ref expression)) return true;
        if (TryEach(b, d, a, c, ref expression)) return true;
        if (TryEach(b, d, c, a, ref expression)) return true;
        //c字头
        if (TryEach(c, a, b, d, ref expression)) return true;
        if (TryEach(c, a, d, b, ref expression)) return true;
        if (TryEach(c, b, a, d, ref expression)) return true;
        if (TryEach(c, b, d, a, ref expression)) return true;
        if (TryEach(c, d, a, b, ref expression)) return true;
        if (TryEach(c, d, b, a, ref expression)) return true;
        //d字头
        if (TryEach(d, a, b, c, ref expression)) return true;
        if (TryEach(d, a, c, b, ref expression)) return true;
        if (TryEach(d, b, a, c, ref expression)) return true;
        if (TryEach(d, b, c, a, ref expression)) return true;
        if (TryEach(d, c, a, b, ref expression)) return true;
        if (TryEach(d, c, b, a, ref expression)) return true;
        return false;
    }
    /// <summary>
    /// 判断指定顺序的四个数abcd进行任意四则运算后能不能得出24，每个数字只能用一次
    /// <param name="a">数字1</param>
    /// <param name="b">数字2</param>
    /// <param name="c">数字3</param>
    /// <param name="d">数字4</param>
    /// <param name="expression"></param>
    private static bool TryEach(int a, int b, int c, int d, ref string expression)
    {
        expression = "";
        //两个数可以做6种运算：加、减、被减、乘以、除以、除
        //四个数共可以进行6*6*6=216种不同次序的四则运算
        //初始化数组
        for (int i = 0; i < 6 * 6 * 6; i++)
        {
            //a与b间的运算符：i / 36
            //b与c间的运算符：i % 36 / 6
            //c与d间的运算符：i % 6
            //1.运算顺序：a和b，再和c，再和d
            {
                string expression1 = "", expression2 = "";
                int temp1 = ResultOf(a, b, i / 36, ref expression1);
                int temp2 = ResultOf(temp1, c, i % 36 / 6, ref expression2, expression1);
                int result = ResultOf(temp2, d, i % 6, ref expression, expression2);
                if (result == 24) return true;
            }
            //2.运算顺序：a和b，c和d，前面部分和后面部分
            {
                string expression1 = "", expression2 = "";
                int temp1 = ResultOf(a, b, i / 36, ref expression1);
                int temp2 = ResultOf(c, d, i % 6, ref expression2);
                int result = ResultOf(temp1, temp2, i % 36 / 6,
                 ref expression, expression1, expression2);
                if (result == 24) return true;
            }
            //3.运算顺序：b和c运算，再与a运算，再与d运算
            {
                string expression1 = "", expression2 = "";
                int temp1 = ResultOf(b, c, i % 36 / 6, ref expression1);
                int temp2 = ResultOf(a, temp1, i / 36, ref expression2, "", expression1);
                int result = ResultOf(temp2, d, i % 6, ref expression, expression2);
                if (result == 24) return true;
            }
            //4.运算顺序：b和c运算，再与d运算，再与a运算
            {
                string expression1 = "", expression2 = "";
                int temp1 = ResultOf(b, c, i % 36 / 6, ref expression1);
                int temp2 = ResultOf(temp1, d, i % 6, ref expression2, expression1);
                int result = ResultOf(a, temp2, i / 36, ref expression, "", expression2);
                if (result == 24) return true;
            }
            //5.运算顺序：c和d运算，再和b运算，再和a运算
            {
                string expression1 = "", expression2 = "";
                int temp1 = ResultOf(c, d, i % 6, ref expression1);
                int temp2 = ResultOf(b, temp1, i % 36 / 6, ref expression2, "", expression1);
                int result = ResultOf(a, temp2, i / 36, ref expression, "", expression2);
                if (result == 24) return true;
            }
        }
        expression = "Abandoned";
        return false;
    }
    /// <summary>
    /// 求两数进行某一四则运算后的结果
    /// <param name="x">数字1</param>
    /// <param name="y">数字2</param>
    /// <param name="method">（0-5分别代表：加、减、被减、乘以、除以、除）</param>
    /// <param name="expression">返回的表达式</param>
    /// <param name="expressionLeft">数字1表达式</param>
    /// <param name="expressionRight">数字2表达式</param>
    private static int ResultOf(int x, int y, int method,
     ref string expression, string expressionLeft = "", string expressionRight = "")
    {
        //左右表达式之前被判定为无效则不计算，除数为0时不计算
        if (expressionLeft == "Abandoned" || expressionRight == "Abandoned" ||
         (x == 0 && method == 5) || (y == 0 && method == 4))
        {
            expression = "Abandoned";
            return -1;
        }
        int result = 0;
        switch (method)
        {
            case 0:
                {
                    //加
                    result = x + y;
                    expression = string.Format("{0}+{1}",
                     expressionLeft == "" ? x.ToString() : expressionLeft,
                     expressionRight == "" ? y.ToString() : expressionRight);
                }
                break;
            case 1:
                {
                    //减
                    result = x - y;
                    expression = string.Format("{0}-{1}",
                     expressionLeft == "" ? x.ToString() : expressionLeft,
                     expressionRight == "" ? y.ToString() : expressionRight);
                }
                break;
            case 2:
                {
                    //被减
                    result = y - x;
                    expression = string.Format("{1}-{0}",
                     expressionLeft == "" ? x.ToString() : expressionLeft,
                     expressionRight == "" ? y.ToString() : expressionRight);
                }
                break;
            case 3:
                {
                    //乘以
                    result = x * y;
                    expression = string.Format("({0})*({1})",
                     expressionLeft == "" ? x.ToString() : expressionLeft,
                     expressionRight == "" ? y.ToString() : expressionRight);
                }
                break;
            case 4:
                {
                    //除以
                    if (x % y == 0)
                    {
                        result = x / y;
                        expression = string.Format("({0})/({1})",
                         expressionLeft == "" ? x.ToString() : expressionLeft,
                         expressionRight == "" ? y.ToString() : expressionRight);
                    }
                    else
                    {
                        expression = "Abandoned";
                    }
                }
                break;
            case 5:
                {
                    //除
                    if (y % x == 0)
                    {
                        result = y / x;
                        expression = string.Format("({1})/({0})",
                         expressionLeft == "" ? x.ToString() : expressionLeft,
                         expressionRight == "" ? y.ToString() : expressionRight);
                    }
                    else
                    {
                        expression = "Abandoned";
                    }
                }
                break;
        }
        //运算不合法，则返回-1，表达式为Abandoned，
        if (expression == "Abandoned")
        {
            return -1;
        }
        return result;
    }
}

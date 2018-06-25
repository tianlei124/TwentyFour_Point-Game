using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System;
using System.Text.RegularExpressions;

public class InputCheck : MonoBehaviour {

    public string expression;//用于存放算式的字符串
    public  string calculate_Result_string;//计算的结果string类型
    public int calculate_Result_int;//计算的结果int类型
    public bool result;//用于判定结果的对错
    public bool number_ofCard ;//用于判定是不是用的给的四张扑克牌
    public bool symbol;//用于判定是不是只用了加减乘除
    // Use this for initialization
    void Start () {
        result = false;
        symbol = true;
        number_ofCard = true;//把三个用于判断输入是否符合标准的bool变量初始化
    }
   public void Check() {//点击submit之后调用这个函数
        expression = GameObject.Find("InputField").GetComponent<GetInput>().formula;//读取输入的值

        //判定是不是等于24
        calculate_Result_string = Convert.ToString(EvaluateExpression.Calculate(expression));
        calculate_Result_int = Convert.ToInt32(calculate_Result_string);//把结果转成int类型
        if (calculate_Result_int == 24)
            result = true;


        //判定是不是只有数字和加减乘除和#
       
        for (int i = 0;i < expression.Length;i++)
        {
            if ((expression[i] <48 || expression[i]>57))
                if(expression[i]!='+'&& expression[i] != '-' && expression[i] != '*' && 
                    expression[i] != '/' && expression[i] != '#' && expression[i] != '(' &&
                    expression[i]!=')'&& expression[i] != '（' && expression[i] != '）')
                symbol = false;
        }

        //判断是不是只用了给定的四个数
        givenCard();


    }

    void givenCard()    //判断是不是只用了给定的四个数
    {
   
        string a = expression;
        int[] poker = { 0, 0, 0, 0 };//用来接受四张牌的值
        int[] number = { 0, 0, 0, 0 };     //初始化四个数，用它来接受输入的四个数
        int cout_num = 0;//用于在for循环里面使number的索引递增
        bool match_card = true;  //用于判断是否与扑克匹配
        for (int i = 0; i < a.Length; i++)//把四个数抽出来
        {
            if (i < a.Length - 1)
            {
                if ((a[i] >= 48 && a[i] <= 57) && (a[i + 1]) < 48 || a[i + 1] > 57)
                {
                    number[cout_num] = a[i] - 48;
                    cout_num++;
                }
                if ((a[i] >= 48 && a[i] <= 57) && (a[i + 1] >= 48 && a[i + 1] <= 57))
                {
                    number[cout_num] = 10 * (a[i] - 48) + (a[i + 1] - 48);
                    cout_num++;
                    i++;
                }
            }
        }
        poker[0] = GameObject.Find("Poker1").GetComponent<Poker1>().randPoker1+1;
        poker[1] = GameObject.Find("Poker2").GetComponent<Poker2>().randPoker2 + 1;
        poker[2] = GameObject.Find("Poker3").GetComponent<Poker3>().randPoker3 + 1;
        poker[3] = GameObject.Find("Poker4").GetComponent<Poker4>().randPoker4+ 1;//把四张扑克牌的值接受过来

        for (int i = 0; i < 4; i++)//把四个number和四个个扑克的值进行比较，如果相同，则把当前的扑克牌的值置为0
        {
            for (int j = 0; j < 4; j++)
            {
                if (number[i] == poker[j])
                    poker[j] = 0;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (poker[i] != 0)
                match_card = false;//如果poker[i]全都为0则匹配成功，不全为0则匹配失败
        }
        number_ofCard = match_card;
    }


    // Update is called once per frame
    void Update () {
       
         
       
    }
    class EvaluateExpression
    {
        private static string Precede(string t1, string t2)    //根据表3.1，判断两符号的优先关系 
        {
            string f = string.Empty;
            switch (t2)
            {
                case "+":
                case "-":
                    if (t1 == "(" || t1 == "#")
                        f = "<";
                    else
                        f = ">";
                    break;

                case "*":
                case "/":
                    if (t1 == "*" || t1 == "/" || t1 == ")")
                        f = ">";
                    else
                        f = "<";
                    break;
                case "(":
                    if (t1 == ")")
                        throw new ArgumentOutOfRangeException("表达式错误");
                    else
                        f = "<";
                    break;
                case ")":
                    switch (t1)
                    {
                        case "(": f = "="; break;
                        case "#": throw new ArgumentOutOfRangeException("表达式错误");
                        default: f = ">"; break;
                    }
                    break;
                case "#":
                    switch (t1)
                    {
                        case "#": f = "="; break;
                        case "(": throw new ArgumentOutOfRangeException("表达式错误");
                        default: f = ">"; break;
                    }
                    break;
            }
            return f;
        }
        private static bool In(string c)    //判断c是否为运算符 
        {
            switch (c)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "(":
                case ")":
                case "#": return true;
                default: return false;
            }

        }

        private static int Operate(int a, string oper, int b)
        {
            int c = 0;
            switch (oper)
            {
                case "+": c = a + b; break;
                case "-": c = a - b; break;
                case "*": c = a * b; break;
                case "/": c = a / b; break;
            }
            return c;

        }

        public static int Calculate(string exp)   //算术表达式求值的算符优先算法。设OPTR和OPND分别为运算符栈和运算数栈 
        {

            expr S = new expr(exp);      //将传过来的表达式打包成一个类对象,便于计算
            string C = string.Empty;
            int oper1, oper2;
            string theta = string.Empty;

            Stack OPTR = new Stack();
            OPTR.Push("#");
            Stack OPND = new Stack();
            C = S.GetS();                 //取表达式里的分量    
            while (C != "#" || OPTR.Peek().ToString() != "#")
            {
                if (!In(C))       //不是运算符则进栈
                {
                    OPND.Push(C);
                    C = S.GetS();
                }
                else
                    switch (Precede(OPTR.Peek().ToString(), C))
                    {
                        case "<":         //栈顶元素优先权低
                            OPTR.Push(C);
                            C = S.GetS();
                            break;
                        case "=":       //脱括号并接收下一个字符
                            OPTR.Pop();
                            C = S.GetS();
                            break;
                        case ">":    //退栈并将运算结果入栈
                            theta = OPTR.Pop().ToString();
                            oper2 = Convert.ToInt32(OPND.Pop());
                            oper1 = Convert.ToInt32(OPND.Pop());
                            OPND.Push(Operate(oper1, theta, oper2).ToString());
                            break;
                    }//switch
            }//while
            return Convert.ToInt32(OPND.Peek());

        }

        private class expr       //表达式类, 用于取表达式里的各个分量
        {

            //成员
            private string exp;
            private int length;  //为GetS()方法服务

            //构造器

            public expr(string exp)
            {
                this.exp = exp;
                length = exp.Length;
                if (!IsRight()) { Console.WriteLine("表达式有错"); return; }
            }

            //方法
            public string GetS()          //取表达式里的字符串
            {
                string ch, token, f;
                ch = token = f = string.Empty;

                if (length == 0)
                    throw new ArgumentOutOfRangeException("表达式取完");

                while (length != 0)
                {
                    ch = exp.Substring(exp.Length - length, 1);


                    if (IsNumeric(ch))   //是数字   : 说明第一次取的就是数字
                    {
                        token += ch;
                        length--;

                    }
                    else                //不是数字
                    {
                        if (IsNumeric(token))
                        {
                            f = token;
                            break;
                        }
                        else                       //说明第一次取的就不是数字
                        {
                            if (ch == " ")
                            {
                                length--;
                                continue;
                            }

                            length--;             //如取的是非数字
                            f = ch;
                            break;
                        }
                    }

                }

                return f;
            }//GetS
            private bool IsRight()  //判断表达式是否合法: (1)两数字中间是否有空格
            {

                bool f = true;
                string ch = string.Empty;
                int i = 0;
                int j = 0;
                for (int p = 0; p < exp.Length; p++)
                {
                    ch = exp.Substring(p, 1);

                    if (IsNumeric(ch))
                    {
                        if (j == 1) return false;
                        i = 1;
                        continue;
                    }
                    if (ch == " ")
                    {
                        if (i == 1) j = 1; continue;
                    }

                    i = j = 0;


                }
                return f;


            }
            private bool IsNumeric(string input)         //判断字符串是否为数
            {
                bool flag = true;
                string pattern = (@"^\d+$");
                Regex validate = new Regex(pattern);
                if (!validate.IsMatch(input))
                {
                    flag = false;
                }
                return flag;

            }

        }//class:expr

    }//计算表达式的类，是一个中缀表达式转后缀表达式的过程。这一个地方做了好几个小时，狗的一批
}

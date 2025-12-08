using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class TT : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("AA");
    }

    public string Anumber;
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Cal(Anumber);
            Debug.Log("Q key was pressed");
        }

        /*                 if (Keyboard.current.wKey.wasPressedThisFrame)
                        {
                            int cmd = 123;
                            // 使用 StringBuilder 來構建字符串(這啥炫技的寫法==)
                            Debug.Log(new StringBuilder("Reserved CMD Cannot Be Used: ").Append(cmd).ToString());


                            Debug.Log("w key was pressed");
                        }  */
    }
    
    public void Cal(string number)
    {
        var numberList = Split(number);
        var numberList1 = FirstMulandDiv(numberList);
        double result = lastAddandSub(numberList1);
        Debug.LogError(result);
    }


    public List<string> Split(string number)
    {
        //因為-和*都有特殊意義，所以在前面加/確保符號意義
        string pattern = @"([+\-\*/])";
        string[] result = Regex.Split(number, pattern);

        return result.ToList();
    }

    public List<string> FirstMulandDiv(List<string> stringList)
    {
        var newStringList = new List<string>();

        bool isExistsMul = stringList.Contains("*");
        bool isExistsDiv = stringList.Contains("/");
        //判斷有沒有乘除
        while (isExistsMul || isExistsDiv)
        {
            for (int i = 0; i < stringList.Count; i++)
            {
                if (stringList[i] == "*" || stringList[i] == "/")
                {
                    //把他上一個和下一個做運算
                    var One = double.Parse(stringList[i - 1]);
                    var two = double.Parse(stringList[i + 1]);
                    //做一個結果
                    double three = 0;
                    if (stringList[i] == "*")
                    {
                        three = One * two;
                        stringList.Remove("*");
                    }
                    else
                    {
                        three = One / two;
                        stringList.Remove("/");
                    }
                    //插入結果
                    stringList.Insert(i - 1, three.ToString());
                    //不要原本的算術那2個
                    stringList.Remove(One.ToString());
                    stringList.Remove(two.ToString());
                    break;
                }
            }
            //檢查還有沒有
            isExistsMul = stringList.Contains("*");
            isExistsDiv = stringList.Contains("/");
        }

        return newStringList = stringList.ToList();
    }

    public double lastAddandSub(List<string> stringList)
    {
        double result = double.Parse(stringList[0]); // 第一個數字當起點

        for (int i = 1; i < stringList.Count; i += 2) // 每兩個一組 (符號 + 數字)
        {
            string op = stringList[i]; // 取運算符
            double value = double.Parse(stringList[i + 1]); // 取數字

            if (op == "+")
                result += value;
            else
                result -= value;
        }

        return result; // 最終結果
    } 



    
    CancellationTokenSource cts = new CancellationTokenSource();    
    void Test()
    {
        CancellationToken token = cts.Token;

        Task task = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Debug.LogError($"現在是{i}次");
                Task.Delay(TimeSpan.FromSeconds(1));
            }
        });
    }

}

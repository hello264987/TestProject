using System;
using UnityEngine;

public class CC : MonoBehaviour
{
    static double Multiply(double param1, double param2)
    {
        return param1 * param2;
    }

    static double Divide(double param1, double param2)
    {
        return param1 / param2;
    }

    //當我們在定義委託時，相當於定義一個沒有函數體的函數(需要有返回值，需要有參數列表)
    //在定義委託，不需要有函數體(所以委託不是函數)，但還是要去定義返回值和參數列表
    delegate double MyDelegate(double param1, double param2);


    void Start()
    {
        //這個變量，必須指向一個函數才可使用(這個函數必須，與委託變量的參數列表和返回值一致)
        MyDelegate delegate1 = Multiply;

        Console.WriteLine(delegate1(2, 4));
    }
}

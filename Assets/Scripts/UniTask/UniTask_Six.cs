using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

//一些需要用到等待的unity對象提供GetAwaiter()功能，從而拿到Awaiter對象就可以進行await了。UniTask已經對各種各樣的Unity對象進行了GetAwaiter的擴展。
//1. Coroutine 的等待及與 UnitTask 的轉換
//2.AsyncOperation的等待 如場景異步加載 資源異步加載 網路請求
//3.UGUI的部分響應方法等待 如鼠標點擊事件
//4.MonoBehaviour的部分功能可以等待 如觸發器
//5.部分插件的擴展 DoTween

public class UniTask_Six : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(CoroutineTest());

        //await CoroutineTest();

        StartCoroutine(CoroutineTest());
    }

    IEnumerator CoroutineTest()
    {
        Debug.Log($"Start " + Time.time);
        yield return new WaitForSeconds(1f);
        Debug.Log($"End " + Time.time);
    }

    IEnumerator CoroutineTest1()
    {
        Debug.Log($"Start " + Time.time);
        yield return UniTask.Delay(TimeSpan.FromSeconds(1)).ToCoroutine();

        Debug.Log($"End " + Time.time);
    }
}

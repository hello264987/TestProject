using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UniTask_Six : MonoBehaviour
{
    async void Start()
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

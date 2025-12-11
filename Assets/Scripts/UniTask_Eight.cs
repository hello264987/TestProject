using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UniTask_Eight : MonoBehaviour
{
    public GameObject OB;
    public Button btn1;
    public Button btn2;

    public CancellationTokenSource cts;
    public CancellationToken token;

    void Start()
    {
        cts = new CancellationTokenSource();
        token = cts.Token;
        btn1.onClick.AddListener(() => click1());
        btn2.onClick.AddListener(() => click2());
    }

    //要將token作為一個變量放入
    public async UniTask<int> Move()
    {
        float currentTime = 0;
        float targetTime = 5f;
        Vector3 temp = Vector3.zero;
        while (currentTime < targetTime)
        {
            currentTime += Time.deltaTime;
            temp += new Vector3(10, 0, 0) * Time.deltaTime;
            OB.GetComponent<RectTransform>().localPosition = temp;

            await UniTask.NextFrame(token);
        }
        Debug.LogError("跳出");

        return 1;
    }

    public async void click1()
    {
        try
        {
            await Move();
        }
        catch (OperationCanceledException)
        {
            Debug.LogError("取消操作");
        }
    }

    public async void click2()
    {
        cts.Cancel();
        cts.Dispose();

        cts = new CancellationTokenSource();
    }
}
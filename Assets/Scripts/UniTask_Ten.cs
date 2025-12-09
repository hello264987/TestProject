using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UniTask_Ten : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public string url1 = "https://www.baidu.com/";
    public string url2 = "https://www.google.com/";

    //Forget方法 UniTask提供 同步方法中調用異步方法 不想await 又不想有警告 可用Forget
    void Start()
    {
        btn1.onClick.AddListener(() => onClickTest(url1, text1).Forget());
        btn2.onClick.AddListener(() => onClickTest(url2, text2).Forget());
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Application.OpenURL(url2);
            Debug.Log("跳轉");
        }
    }

    public async UniTask<string> visitWeb(string url, float timeout)
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        //在指定任務後取消任務
        cts.CancelAfterSlim(TimeSpan.FromSeconds(timeout));
        //沒有拋出異常 通過返回值判斷任務是否取消
        //返回值 bool T
        //SuppressCancellationThrow拋出異常的第二種方式
        //發送網路請求 並且會有一個取消異常
        //返回值 第一個參數bool 是否取消 第二個參數結果  <bool IsCanceled, UnityWebRequest Result>
        var (failed, result) = await UnityWebRequest.Get(url).SendWebRequest().WithCancellation(cts.Token).SuppressCancellationThrow();

        if (!failed)
        {
            return result.downloadHandler.text.Substring(0, 20);
        }

        //如果等到指定時間任務取消了  說明等待時間內沒連上
        return "超時";
    }

    public async UniTaskVoid onClickTest(string url, TextMeshProUGUI _text)
    {
        var res = await visitWeb(url, 1f);
        _text.text = res;
    }
}
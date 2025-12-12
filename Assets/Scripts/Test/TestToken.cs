using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestToken : MonoBehaviour
{
    public Button btn1;
    public Button bt2;


    void Start()
    {
        Run();
        Run2();
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Scene1");
        }
    }


    void Run()
    {
        btn1.onClick.AddListener(async () =>
        {
            Debug.Log("開始等待5秒(No Token)");
            await UniTask.Delay(TimeSpan.FromSeconds(5f));
            Debug.LogError("❗ NoToken：等待結束，即使場景已被切換！");
        });
    }

   //Unity 的 Button.onClick 只能接受「void 回傳」的委派
    void Run2()
    {
        var token = this.GetCancellationTokenOnDestroy();

        bt2.onClick.AddListener(async () =>
        {
            Debug.Log("開始等待 5 秒 (With Token)");

            try
            {
                await UniTask.Delay(5000, cancellationToken: token);
                Debug.LogError("⭕ WithToken：等待結束");
            }
            catch (System.OperationCanceledException)
            {
                Debug.LogWarning("⚡ WithToken：等待被取消（因為物件被 Destroy 或場景切換）");
            }
        });
    }
}
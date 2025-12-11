using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UniTask_Twelve : MonoBehaviour
{
    public Button btn1;
    public Button btn2;

    void Start()
    {
        ClickN().Forget();
        ClickNA(this.GetCancellationTokenOnDestroy()).Forget();
    }

    public async UniTaskVoid ClickN()
    {
        while (true)
        {
            var task = btn1.OnClickAsync();
            Debug.LogError("1234");
            await task;
            Debug.LogError("!");
        }
    }

    public async UniTaskVoid ClickNA(CancellationToken cts)
    {
        while (true)
        {
            var task = btn2.OnClickAsync(cts);
            Debug.LogWarning("CCT");
            await task;
            Debug.LogError("!");
        }
    }

}


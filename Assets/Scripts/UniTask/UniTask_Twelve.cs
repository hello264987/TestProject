using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

//按鈕點擊事件轉換為異步的OnClickAsync 其他UI組件類似
//UniTask 提供的方法 GetCancellationTokenOnDestory()
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
            await task;
            Debug.LogError("!");
        }
    }

    //不斷監測按鈕是否被點擊，每次點擊時輸出當前的時間
    public async UniTaskVoid ClickNA(CancellationToken cts)
    {
        while (true)
        {
            var task = btn2.OnClickAsync(cts);

            //等待點擊事件完成
            //token是透過CancelationTokenOnDestory 方法獲取的
            //新的token對象是在每次調用ClickNA方法創建的, 用於取消之前的任務
            await task;
            Debug.LogError("!");
        }
    }

}


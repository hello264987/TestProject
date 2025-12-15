using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UniTask_Thirteen : MonoBehaviour
{
    public Button button;
    public float lastClick;

    void Start()
    {
        //lastClick = Time.realtimeSinceStartup;

        //button.onClick.AddListener(() => NormalClick());
        ChcekclickInternal(this.GetCancellationTokenOnDestroy()).Forget();
        
    }

    private void NormalClick()
    {
        if (Time.realtimeSinceStartup - lastClick > 1f)
        {
            Debug.Log("時間間隔超過1");
            lastClick = Time.realtimeSinceStartup;
        }
        else
        {
            Debug.Log("時間間隔不超過1");
        }
        lastClick = Time.realtimeSinceStartup;
    }


    public async UniTaskVoid ChcekclickInternal(CancellationToken token)
    {
        var FirstClick = button.OnClickAsync(token);
        await FirstClick;

        Debug.Log("按下第一次");


        var SecondClick = button.OnClickAsync(token);


        var Delay = UniTask.Delay(TimeSpan.FromSeconds(3f));

        int index = await UniTask.WhenAny(SecondClick, Delay);
        if (index == 0)
        {
            Debug.LogError("按下第二次");
        }
        else
        {
            Debug.LogError("等待3秒");
        }
    }
}

using Cysharp.Threading.Tasks;
using UnityEngine;

//UniTask 不能await兩次

//UniTask.Void 參數異步委託    直接啟動一個異步委託，不需考慮其等待 無須加await
//UniTask.Defer 用異步委託快速生成返回UniTask的異步方法 必須加await才能執行
public class UniTask_Five : MonoBehaviour
{
    async void Start()
    {

        UniTask.Void(async () =>
        {
            Debug.Log("Start：" + Time.frameCount);

            await UniTask.NextFrame();
            Debug.Log("End" + Time.frameCount);
        }); 
        

        await UniTask.Defer(async () =>
        {
            Debug.Log("Start：" + Time.frameCount);

            await UniTask.NextFrame();
            Debug.Log("End" + Time.frameCount);
        });
    }
}
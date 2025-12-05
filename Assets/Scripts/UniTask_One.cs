using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class UniTask_One : MonoBehaviour
{
    //基礎用法
    //延時操作
    //UniTask.Delay 延遲幾秒：注意方法的重載及參數作用，是否受時間縮放影響
    //UniTask.DelayFrame 延遲幾幀
    //UniTask.NextFrame 等待一幀

    //底下先不用管，涉及到其他操作
    //UniTask.Yield 等待一幀 用於處理調回主線程用 可以用於將處理調回主線程用。 例如yield之前是在其他線程跑，yield之後回到主線程跑
    //默認是update循環。通過變更loop的類型，能切換之後代碼的運行時機

    async void Start()
    {
        Debug.Log("Start " + Time.frameCount);

        //await UniTask.DelayFrame(100);
        await UniTask.NextFrame();

        Debug.Log("End " + Time.frameCount);
    }

    async Task<int> DealyTest()
    {
        Debug.Log("Task Start" + Time.time);
        await Task.Delay(1000);
        Debug.Log("Task End" + Time.time);
        return 1;
    }
}
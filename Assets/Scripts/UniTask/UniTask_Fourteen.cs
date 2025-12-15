using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UniTask_Fourteen : MonoBehaviour
{
    void Start()
    {
        TripleClick().Forget();
    }

    public Button button;
    async UniTask TripleClick()
    {
        await button.OnClickAsAsyncEnumerable().Take(3).ForEachAsync((_,index) =>
        {
            if (index == 0)
            {
                Debug.Log("1");
            }
            else if (index == 1)
            {
                Debug.Log("2");
            }
            else
            {
                Debug.Log("3");
            }
        });
        Debug.Log("Three times clicked, complete");
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UniTask_Nine : MonoBehaviour
{
    CancellationTokenSource cts;
    void Start()
    {
        cts = new CancellationTokenSource();

        CountStart();
        cts.CancelAfter(TimeSpan.FromSeconds(3));
    }


    async UniTask<int> Count(CancellationToken token)
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log($"working....{i + 1}");
            await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        }
        return 0;
    }

    async UniTaskVoid CountStart()
    {
        try
        {
            await Count(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Debug.LogError("停止");
        }
    }
}
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using NUnit.Framework.Internal;
using UnityEngine;

public class UniTask_Fifteen : MonoBehaviour
{
    public GameObject ball;

    void Start()
    {
        TestClick().Forget();
    }

    void Update()
    {
        ball.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
    }

    public async UniTaskVoid TestCol()
    {
        var col = ball.GetAsyncCollisionEnterTrigger();
        await col.OnCollisionEnterAsync();
        Debug.Log("撞到了");
    }
    
    public async UniTaskVoid TestClick()
    {
        var click = ball.GetAsyncMouseDownTrigger();
        await click.OnMouseDownAsync();
        Debug.Log("MouseDown");
    }
}

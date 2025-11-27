using Cysharp.Threading.Tasks;
using UnityEngine;


//WhenAll 等待條件 全部滿足執行
public class UniTask_Three : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;


    void Start()
    {
        TestWhenAll();
    }

    void Update()
    {
        ball1.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
        ball2.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 0.5f);
    }

    async void TestWhenAll()
    {
        //相當於監聽，檢測條件滿足執行
        UniTask task1 = UniTask.WaitUntil(() => ball1.transform.position.x > 1);
        //相當於監聽，檢測條件滿足執行
        UniTask task2 = UniTask.WaitUntil(() => ball2.transform.position.x > 1);

        //等待條件滿足才執行
        await UniTask.WhenAll(task1, task2);

        //後續代碼等任務全部滿足條件執行
        string str = $"ball1 {ball1.transform.position}  ball2 {ball2.transform.position}";
        Debug.Log(str);
    }
}
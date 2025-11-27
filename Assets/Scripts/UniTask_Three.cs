using Cysharp.Threading.Tasks;
using UnityEngine;

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
        UniTask Uni1 = UniTask.WaitUntil(() => ball1.transform.position.x > 1);
        UniTask Uni2 = UniTask.WaitUntil(() => ball2.transform.position.x > 1);

        
        await UniTask.WhenAll(Uni1, Uni2);
        string str = $"ball1 {ball1.transform.position}  ball2 {ball2.transform.position}";
        Debug.Log(str);
    }



}

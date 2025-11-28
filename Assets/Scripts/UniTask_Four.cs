using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UniTask_Four : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    public bool isClick1;
    public bool isClick2;
    void Start()
    {
        btn1.onClick.AddListener(() => click1());
        btn2.onClick.AddListener(() => click2());
        AllBtnClick();
        AnyBtnClick();
    }

    public void click1()
    {
        isClick1 = true;
    }
    public void click2()
    {
        isClick2 = true;
    }

    async void AllBtnClick()
    {
        UniTask task1 = UniTask.WaitUntil(() => isClick1);
        UniTask task2 = UniTask.WaitUntil(() => isClick2);

        await UniTask.WhenAll(task1, task2);

        Debug.Log("都點擊了");
    }
    
    async void AnyBtnClick()
    {
        UniTask task1 = UniTask.WaitUntil(() => isClick1);
        UniTask task2 = UniTask.WaitUntil(() => isClick2);

        await UniTask.WhenAny(task1, task2);

        Debug.Log("一個點擊了");
    }
}

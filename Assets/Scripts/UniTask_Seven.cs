using System.Collections;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//AsynOperation的Awaiter
//Unity本身自帶的一些異步方法，也可以用await了
//舉例：資源異步加載
public class UniTask_Seven : MonoBehaviour
{
    public Button btn1, btn2;
    public TextMeshProUGUI text1, text2;

    void Start()
    {
        btn1.onClick.AddListener(() => StartCoroutine(ResNormal()));
        btn2.onClick.AddListener(() => ResUniTask());
    }

    public IEnumerator ResNormal()
    {
        ResourceRequest res = Resources.LoadAsync<TextAsset>("1");

        while (!res.isDone)
        {
            yield return null;
        }

        if (res.asset != null)
        {
            text1.text = ((TextAsset)res.asset).text;
        }
    }

    public async void ResUniTask()
    {
        ResourceRequest res = Resources.LoadAsync<TextAsset>("1");

        var source = await res;

        text2.text = ((TextAsset)source).text;
    }
}

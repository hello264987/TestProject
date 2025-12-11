using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UniTask_Eleven : MonoBehaviour
{
    public Button btn1;
    public Image img1;

    public Button btn2;
    public Image img2;

    public string url = "https://media.9game.cn/gamebase/ieu-gdc-pre-process/images/20231012/3/19/0be9fbe5a74a313ce6fc2e47a672d3af.jpg";
    void Start()
    {
        //StartCoroutine(Normal());
        btn2.onClick.AddListener(() => UniTaskImg().Forget());
    }

    public IEnumerator Normal()
    {
        using (var webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                var texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;

                Sprite sprite = Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(texture.width, texture.height)), new Vector2(0.5f, 0.25f));

                img1.sprite = sprite;
                img1.preserveAspect = true;
            }

        }
    }

    CancellationTokenSource cts = new CancellationTokenSource();
    private async UniTask UniTaskImg()
    {
        var webRequest = UnityWebRequestTexture.GetTexture(url);
        var (failed, result) = await webRequest.SendWebRequest().WithCancellation(cts.Token).SuppressCancellationThrow();
        if (!failed)
        {
            Debug.LogError("失敗了");
            return;
        }
        else
        {
            var texture = ((DownloadHandlerTexture)result.downloadHandler).texture;

            Sprite sprite=Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(texture.width, texture.height)), new Vector2(0.5f, 0.25f));
            img2.sprite = sprite;
            img2.preserveAspect = true;
        }
    }
}
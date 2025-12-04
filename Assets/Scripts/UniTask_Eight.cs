using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UniTask_Eight : MonoBehaviour
{
    public GameObject OB;

    public Button btn1;
    public Button btn2;


    void Start()
    {
        btn1.onClick.AddListener(() => Move());
        Move();
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            OB.transform.localPosition = new Vector3(10, 10, 10);
            Debug.LogError("A");
        }
    }

    public async void Move()
    {
        float currentTime = 0;
        float targetTime = 5f;
        Vector3 temp = Vector3.zero;
        while (currentTime < targetTime)
        {
            currentTime += Time.deltaTime;
            temp += new Vector3(10, 0, 0) * Time.deltaTime;
            OB.GetComponent<RectTransform>().localPosition = temp;

            Debug.LogError(OB.transform.localPosition.x);

            await UniTask.NextFrame();
        }
        Debug.LogError("跳出");
    }


}

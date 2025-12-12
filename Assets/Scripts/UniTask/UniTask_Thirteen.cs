using UnityEngine;
using UnityEngine.UI;

public class UniTask_Thirteen : MonoBehaviour
{
    public Button button;
    public float lastClick;

    void Start()
    {
        lastClick = Time.realtimeSinceStartup;

        button.onClick.AddListener(() => NormalClick());
    }

    private void NormalClick()
    {
        if (Time.realtimeSinceStartup - lastClick > 1f)
        {
            Debug.Log("123");
            lastClick = Time.realtimeSinceStartup;
        }
        else
        {
            
        }

    }
}

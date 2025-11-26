using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class TT : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Debug.Log("Q key was pressed");
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            int cmd = 123;
            // 使用 StringBuilder 來構建字符串(這啥炫技的寫法==)
            Debug.Log(new StringBuilder("Reserved CMD Cannot Be Used: ").Append(cmd).ToString());


            Debug.Log("w key was pressed");
        }
    }
}

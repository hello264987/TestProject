using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class TT : MonoBehaviour
{

    void Start()
    {
        //Debug.Log("AA");
    }

    void  Update()
    {
        Test();


        /*         if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    Debug.Log("Q key was pressed");
                }

                if (Keyboard.current.wKey.wasPressedThisFrame)
                {
                    int cmd = 123;
                    // 使用 StringBuilder 來構建字符串(這啥炫技的寫法==)
                    Debug.Log(new StringBuilder("Reserved CMD Cannot Be Used: ").Append(cmd).ToString());


                    Debug.Log("w key was pressed");
                } */
    }
    
    CancellationTokenSource cts = new CancellationTokenSource();    
    void Test()
    {
        CancellationToken token = cts.Token;

        Task task = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Debug.LogError($"現在是{i}次");
                Task.Delay(TimeSpan.FromSeconds(1));
            }
        });
    }

}

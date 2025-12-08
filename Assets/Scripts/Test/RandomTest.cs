using UnityEngine;
using UnityEngine.InputSystem;

public class RandomTest : MonoBehaviour
{
    public Random.State savedState;

    int AA
    {
        get
        {
            return 10;  //別人拿到的
        }
        set
        {
            value = 0;
        }
    }

    void Start()
    {
        int mySeed = 1337;
        Random.InitState(mySeed);

        savedState = Random.state;
        int num1 = Random.Range(1, 101); // 1 到 100 之間的整數（含頭尾）
        Debug.LogError($"隨機生成{num1}");
    }


    void Replay(Random.State stateToRestore)
    {
        Random.state = stateToRestore;
        int num1 = Random.Range(1, 101); // 1 到 100 之間的整數（含頭尾）
        Debug.LogError($"依靠State復刻{num1}");
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            //Replay(this.savedState);

            Debug.LogWarning("SAVE");
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            AA = 10000;
            Debug.LogError(AA);
        }
    }
}
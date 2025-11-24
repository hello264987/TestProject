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
    }
}

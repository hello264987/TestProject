using Cysharp.Threading.Tasks;
using UnityEngine;

public class UniTask_Two : MonoBehaviour
{
    public GameObject ball;
    void Start()
    {
        WaitUntilTest();
    }

    void Update()
    {
        ball.transform.Translate(new Vector3(1, 0, 0)*Time.deltaTime);
    }

    async void WaitUntilTest()
    {
        Debug.Log("Start " + Time.time);
        await UniTask.WaitUntil(() => isFrameThanOne());

        await UniTask.WaitUntilValueChanged(ball.transform, x => x.transform.position);

        Debug.Log("End " + Time.time);
        ball.GetComponent<Renderer>().material.color = Color.red;
    }


    public bool isFrameThanOne()
    {
        if (ball.transform.position.x > 1)
        {
            return true;
        }
        return false;
    }
}

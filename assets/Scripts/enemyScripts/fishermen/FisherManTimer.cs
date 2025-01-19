using UnityEngine;

public class FisherManTimer : MonoBehaviour
{
    float timer = 6f;
    public Animator fisherman;
    public Animator fisherman2;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0)
        {
            timer = 6f;
        }

        fisherman.SetFloat("timer", timer);
        fisherman2.SetFloat("timer", timer);
    }
}

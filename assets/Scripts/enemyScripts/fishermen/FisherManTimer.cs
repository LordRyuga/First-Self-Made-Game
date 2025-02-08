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


        //  Timer is a float present on the animator on the fisherman, and we are checking if it is less than or greater than 5 in order to
        // transistion from the fishing-idle to the fishing star animations.

    }
}

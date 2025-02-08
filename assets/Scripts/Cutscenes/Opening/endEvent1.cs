using UnityEngine;

public class endEvent1 : MonoBehaviour
{
    [SerializeField] openingTextAnimation opa;

    // This was supposed to be part of the original method to implement the first cutscene but doing so for every cutscene would be tedious
    // So I searched for better methods and found out about timeline.
    // This method is no longer being used

    // refer script named openingTextAnimation for more detail

    public void SetAnim2()
    {
        opa.StartAnim2 = true;
    }
}

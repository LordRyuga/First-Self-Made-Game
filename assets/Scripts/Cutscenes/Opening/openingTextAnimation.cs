using UnityEngine;

public class openingTextAnimation : MonoBehaviour
{
    // A messy method to achieve the cutscenes with text fading and appearing one after another.

    // The scripts endEvent1 and endEvent2 in cutscenes folder are a part of this messy method.

    [HideInInspector] public bool StartAnim2;
    [HideInInspector] public bool StartAnim3;
    [SerializeField] Animator animation1;
    [SerializeField] Animator animation2;
    [SerializeField] Animator animation3;


    // This was supposed to be the original method to implement the first cutscene but doing so for every cutscene would be tedious
    // So I searched for better methods and found out about timeline.
    // This method is no longer being used

    // I would call the animation through an animator with parameters as startAnimx and using these methods.

    //public void SetAnim2()
    //{ 
    //    StartAnim2 = true;
    //}
    //public void SetAnim3()
    //{
    //    StartAnim3 = true;
    //}

    //private void Update()
    //{

    //    animation2.SetBool("StartAnim2", StartAnim2);
    //    animation3.SetBool("StartAnim3", StartAnim3);
    //}
}

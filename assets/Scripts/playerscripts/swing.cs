using System;
using UnityEngine;

public class swing : MonoBehaviour
{
    public gameManager manager;
    public Animation swinging;
    public Animation Block;
    public Animation unblock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            swinging.Play("sword swing");
        }
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Block.Play("block");
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            unblock.Play("unblock");
        }
    }
}

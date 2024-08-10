using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40;

    float horizontalMove = 0;
    bool jump = false;

    public enum JumpDir
    {
        left, right
    }
    JumpDir jumpDir;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("JumpLeft"))
        {
            jumpDir = JumpDir.left;
            jump = true;
        }
        else if (Input.GetButtonDown("JumpRight"))
        {
            jumpDir = JumpDir.right;
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jumpDir);
        jump = false;
    }
}
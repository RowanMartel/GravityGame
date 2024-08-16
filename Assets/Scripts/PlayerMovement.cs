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
    {/*
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
        }*/
        switch (GravityManager.instance.gravityDir)
        {
            case GravityManager.GravityDir.down:
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

                if (Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    jumpDir = JumpDir.left;
                    jump = true;
                }
                else if (Input.GetKeyDown(KeyCode.JoystickButton2))
                {
                    jumpDir = JumpDir.right;
                    jump = true;
                }
                break;
            case GravityManager.GravityDir.up:
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

                if (Input.GetKeyDown(KeyCode.JoystickButton2))
                {
                    jumpDir = JumpDir.left;
                    jump = true;
                }
                else if (Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    jumpDir = JumpDir.right;
                    jump = true;
                }
                break;
            case GravityManager.GravityDir.left:
                horizontalMove = Input.GetAxisRaw("Vertical") * runSpeed;

                if (Input.GetKeyDown(KeyCode.JoystickButton3))
                {
                    jumpDir = JumpDir.left;
                    jump = true;
                }
                else if (Input.GetKeyDown(KeyCode.JoystickButton1))
                {
                    jumpDir = JumpDir.right;
                    jump = true;
                }
                break;
            case GravityManager.GravityDir.right:
                horizontalMove = Input.GetAxisRaw("Vertical") * runSpeed;

                if (Input.GetKeyDown(KeyCode.JoystickButton1))
                {
                    jumpDir = JumpDir.left;
                    jump = true;
                }
                else if (Input.GetKeyDown(KeyCode.JoystickButton3))
                {
                    jumpDir = JumpDir.right;
                    jump = true;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, jumpDir);
        jump = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool leftDown;
    bool rightDown;
    bool jumpLeft;
    bool jumpRight;

    bool grounded;

    public float speed;

    Rigidbody2D rb;

    enum GravityDir
    {
        left,
        right,
        up,
        down
    }
    GravityDir gravityDir = GravityDir.down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // grounded check
        switch (gravityDir)
        {
            case GravityDir.left:
                grounded = Physics.Raycast(transform.position, Vector2.left, .5f);
                break;
            case GravityDir.right:
                grounded = Physics.Raycast(transform.position, Vector2.right, .5f);
                break;
            case GravityDir.up:
                grounded = Physics.Raycast(transform.position, Vector2.up, .5f);
                break;
            case GravityDir.down:
                grounded = Physics.Raycast(transform.position, Vector2.down, .5f);
                break;
        }

        // move left check
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            leftDown = true;
        else leftDown = false;

        // move right check
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rightDown = true;
        else rightDown = false;

        // jump checks
        if (grounded && Input.GetKeyDown(KeyCode.Q))
            jumpLeft = true;
        if (grounded && Input.GetKeyDown(KeyCode.E))
            jumpRight = true;
        // make grounded work puppy
    }

    private void FixedUpdate()
    {
        if (leftDown && !rightDown)
        {
            Debug.Log("moving left");
            switch (gravityDir)
            {
                case GravityDir.left:
                    rb.AddForce(Vector2.up * speed);
                    break;
                case GravityDir.right:
                    rb.AddForce(Vector2.down * speed);
                    break;
                case GravityDir.up:
                    rb.AddForce(Vector2.right * speed);
                    break;
                case GravityDir.down:
                    rb.AddForce(Vector2.left * speed);
                    break;
            }
        }
        else if (!leftDown && rightDown)
        {
            Debug.Log("moving right");
            switch (gravityDir)
            {
                case GravityDir.left:
                    rb.AddForce(Vector2.down * speed);
                    break;
                case GravityDir.right:
                    rb.AddForce(Vector2.up * speed);
                    break;
                case GravityDir.up:
                    rb.AddForce(Vector2.left * speed);
                    break;
                case GravityDir.down:
                    rb.AddForce(Vector2.right * speed);
                    break;
            }
        }

        // if trying to jump in both ways, negate both
        if (jumpLeft && jumpRight)
        {
            jumpLeft = false;
            jumpRight = false;
        }

        if (jumpLeft)
        {
            Debug.Log("jumping left");
            jumpLeft = false;
            switch(gravityDir)
            {
                case GravityDir.left:
                    Physics.gravity = new Vector3(0, 9.81f, 0);
                    gravityDir = GravityDir.up;
                    break;
                case GravityDir.right:
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                    gravityDir = GravityDir.down;
                    break;
                case GravityDir.up:
                    Physics.gravity = new Vector3(9.81f, 0, 0);
                    gravityDir = GravityDir.right;
                    break;
                case GravityDir.down:
                    Physics.gravity = new Vector3(-9.81f, 0, 0);
                    gravityDir = GravityDir.left;
                    break;
            }
        }
        else if (jumpRight)
        {
            Debug.Log("jumping right");
            jumpRight = false;
            switch (gravityDir)
            {
                case GravityDir.left:
                    Physics.gravity = new Vector3(0, -9.81f, 0);
                    gravityDir = GravityDir.up;
                    break;
                case GravityDir.right:
                    Physics.gravity = new Vector3(0, 9.81f, 0);
                    gravityDir = GravityDir.down;
                    break;
                case GravityDir.up:
                    Physics.gravity = new Vector3(-9.81f, 0, 0);
                    gravityDir = GravityDir.right;
                    break;
                case GravityDir.down:
                    Physics.gravity = new Vector3(9.81f, 0, 0);
                    gravityDir = GravityDir.left;
                    break;
            }
        }
    }
}
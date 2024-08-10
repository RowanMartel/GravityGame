using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public static GravityManager instance;

    public enum GravityDir
    {
        up, down, left, right
    }
    static public GravityDir down = GravityDir.down;
    static public GravityDir left = GravityDir.left;
    static public GravityDir right = GravityDir.right;
    static public GravityDir up = GravityDir.up;

    public GravityDir gravityDir;

    Vector2 gravVectorUp = new Vector2(0, 9.81f);
    Vector2 gravVectorDown = new Vector2(0, -9.81f);
    Vector2 gravVectorRight = new Vector2(9.81f, 0);
    Vector2 gravVectorLeft = new Vector2(-9.81f, 0);

    private void Awake()
    {
        instance = this;
        gravityDir = down;
    }

    public void ShiftGravLeft()
    {
        switch (gravityDir)
        {
            case GravityDir.up: gravityDir = left; Physics2D.gravity = gravVectorLeft; break;
            case GravityDir.down: gravityDir = left; Physics2D.gravity = gravVectorLeft; break;
            case GravityDir.left: gravityDir = up; Physics2D.gravity = gravVectorUp; break;
            case GravityDir.right: gravityDir = down; Physics2D.gravity = gravVectorDown; break;
        }

        Debug.Log(Physics2D.gravity);
    }
    public void ShiftGravRight()
    {
        switch (gravityDir)
        {
            case GravityDir.up: gravityDir = right; Physics2D.gravity = gravVectorRight; break;
            case GravityDir.down: gravityDir = right; Physics2D.gravity = gravVectorRight; break;
            case GravityDir.left: gravityDir = down; Physics2D.gravity = gravVectorDown; break;
            case GravityDir.right: gravityDir = up; Physics2D.gravity = gravVectorUp; break;
        }

        Debug.Log(Physics2D.gravity);
    }
}
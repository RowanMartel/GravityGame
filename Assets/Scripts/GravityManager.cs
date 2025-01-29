using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public static GravityManager Instance;

    public enum GravityDir
    {
        up, down, left, right
    }
    static public GravityDir down = GravityDir.down;
    static public GravityDir left = GravityDir.left;
    static public GravityDir right = GravityDir.right;
    static public GravityDir up = GravityDir.up;

    public GravityDir gravityDir;

    Vector2 gravVectorUp = new Vector2(0, 2 * 9.81f);
    Vector2 gravVectorDown = new Vector2(0, 2 * -9.81f);
    Vector2 gravVectorRight = new Vector2(2 * 9.81f, 0);
    Vector2 gravVectorLeft = new Vector2(2 * -9.81f, 0);

    private void Awake()
    {
        Instance = this;

        switch (gravityDir)
        {
            case GravityDir.up:
                Physics2D.gravity = gravVectorUp;
                break;
            case GravityDir.down:
                Physics2D.gravity = gravVectorDown;
                break;
            case GravityDir.left:
                Physics2D.gravity = gravVectorLeft;
                break;
            case GravityDir.right:
                Physics2D.gravity = gravVectorRight;
                break;
        }
    }

    public void ChangeGrav(GravityDir gravityDir)
    {
        this.gravityDir = gravityDir;
        switch (gravityDir)
        {
            case GravityDir.up:
                Physics2D.gravity = gravVectorUp;
                break;
            case GravityDir.down:
                Physics2D.gravity = gravVectorDown;
                break;
            case GravityDir.left:
                Physics2D.gravity = gravVectorLeft;
                break;
            case GravityDir.right:
                Physics2D.gravity = gravVectorRight;
                break;
        }
    }
}
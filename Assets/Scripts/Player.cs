using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    PauseMenu pauseMenu;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pauseMenu = PauseMenu.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) pauseMenu.ResetScene();

        if (rb.velocity.magnitude > 0.01f) return;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            GravityManager.Instance.ChangeGrav(GravityManager.GravityDir.up);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            GravityManager.Instance.ChangeGrav(GravityManager.GravityDir.down);
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            GravityManager.Instance.ChangeGrav(GravityManager.GravityDir.left);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            GravityManager.Instance.ChangeGrav(GravityManager.GravityDir.right);
    }
}
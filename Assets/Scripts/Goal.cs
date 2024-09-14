using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] float rotatingSpeed = .5f;
    [SerializeField] float bobbingSpeed = 5f;
    [SerializeField] float bobbingHeight = .5f;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight + pos.y;
        //set the objectÅfs Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(new Vector3(0, 0, rotatingSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        GameManager.currentLevel++;
        SceneManager.LoadScene(GameManager.currentLevel);
    }
}
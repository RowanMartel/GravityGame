using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPageArrow : MonoBehaviour
{
    [SerializeField] int levelReq;

    void Start()
    {
        if (GameManager.furthestLevel < levelReq)
            gameObject.SetActive(false);
    }
}
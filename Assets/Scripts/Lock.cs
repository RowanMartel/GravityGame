using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] int levelReq;

    void Start()
    {
        if (GameManager.furthestLevel >= levelReq)
            gameObject.SetActive(false);
    }
}
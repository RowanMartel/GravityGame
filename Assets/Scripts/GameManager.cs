using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int furthestLevel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (furthestLevel !> 1) furthestLevel = 1;
    }
}
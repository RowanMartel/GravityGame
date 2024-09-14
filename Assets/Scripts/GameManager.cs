using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int furthestLevel;
    public static int currentLevel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (furthestLevel < 2) furthestLevel = 1;
    }
}
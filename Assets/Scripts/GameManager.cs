using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static int furthestLevel;
    public static int currentLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (furthestLevel < 2) furthestLevel = 1;
    }
}
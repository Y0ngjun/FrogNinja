using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    public UIManager uiManager;
    public bool IsGameOver { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        IsGameOver = false;
    }

    public void GameOver()
    {
        if (!IsGameOver)
        {
            IsGameOver = true;
            uiManager.ShowGameOverUI(true);
            Destroy(player);
        }
    }

    public void GameClear()
    {
        if (!IsGameOver)
        {
            IsGameOver = true;
            uiManager.ShowGameClearUI(true);
            Destroy(player);
        }
    }
}

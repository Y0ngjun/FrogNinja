using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    void Start()
    {
        ShowGameOverUI(false);
        ShowGameClearUI(false);
    }

    public void ShowGameOverUI(bool show)
    {
        gameOverUI.SetActive(show);
    }

    public void ShowGameClearUI(bool show)
    {
        gameClearUI.SetActive(show);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Human player;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        player.OnHpEnded.AddListener(ShowGameOverScreen);
        player.OnAmmoEnded.AddListener(ShowGameOverScreen);
        exitButton.onClick.AddListener(ExitApp);
        restartButton.onClick.AddListener(RestartLevel);
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    private void ExitApp()
    {
        Application.Quit();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

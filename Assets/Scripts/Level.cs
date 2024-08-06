using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Human player;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private ZombiesSpawner zombiesSpawner;
    [SerializeField] private UIAmmoCounter uIAmmoCounter;
    [SerializeField] private ProjectilesPoolManager projectilesPoolManager;

    private void Awake()
    {
        player.OnHpEnded.AddListener(ShowGameOverScreen);
        player.OnAmmoEnded.AddListener(ShowGameOverScreen);
        exitButton.onClick.AddListener(ExitApp);
        restartButton.onClick.AddListener(RestartLevel);
        zombiesSpawner.Init(player.transform);
        uIAmmoCounter.Init(player);
        player.Init(projectilesPoolManager);
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

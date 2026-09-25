using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject mainMenuPanel;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        // Hide pause UI
        pausePanel.SetActive(false);
        pauseButton.SetActive(false);

        // Show the main menu
        mainMenuPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }
}
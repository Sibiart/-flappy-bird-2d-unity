using UnityEngine;

public class MAINMENU : MonoBehaviour
{
    public GameObject Mainmenupanel;
    public GameObject PauseButton;
    public GameObject PausePanel;
    public static bool skipMainMenu = false;

    void Start()
    {
        if (skipMainMenu)
        {
            skipMainMenu = false;

            Mainmenupanel.SetActive(false);
            PauseButton.SetActive(true);
            PausePanel.SetActive(false);

            Time.timeScale = 1f;
            return;
        }

        Time.timeScale = 0f;
        Mainmenupanel.SetActive(true);
        PauseButton.SetActive(false);
        PausePanel.SetActive(false);
    }

    public void StartGame()
    {
        Mainmenupanel.SetActive(false);

        PauseButton.SetActive(true);
        PausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void ToggleMusic()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
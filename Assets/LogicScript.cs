using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    public GameObject Gameoverscreen;
    public AudioSource bgMusic;
    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        Debug.Log("AddScore called, current score: " + playerScore);
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void restartgame()
    {
        MAINMENU.skipMainMenu = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameover()
    {
        Debug.Log("Game Over Called");
        bgMusic.Stop();
        Gameoverscreen.SetActive(true);
        Time.timeScale = 0f;

    }
}
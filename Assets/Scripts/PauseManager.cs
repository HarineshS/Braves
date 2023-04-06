using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public Button resumeButton;
    public Button quitButton;

    void Start()
    {
        // Hide the pause panel at the start of the game
        pausePanel.SetActive(false);

        // Add event listeners to the resume and quit buttons
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        // Check if the Escape key was pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the pause panel is already open, close it
            if (pausePanel.activeSelf)
            {
                ResumeGame();
                Cursor.visible = false;
            }
            // Otherwise, open the pause panel
            else
            {
                PauseGame();
                Cursor.visible = true;
            }
        }
    }

    void PauseGame()
    {
        // Show the pause panel and pause the game
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    void ResumeGame()
    {
        // Hide the pause panel and resume the game
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void QuitGame()
    {
        // Quit the game (only works in standalone builds)
        Application.Quit();
    }
}

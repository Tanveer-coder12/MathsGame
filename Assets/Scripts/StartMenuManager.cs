
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel;

    public LevelSelectButton[] levelButtons;

    private void Start()
    {
        ShowMainMenu();
        RefreshLevelButtons();
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelSelectionPanel.SetActive(false);
    }

    public void OpenLevelSelection()
    {
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);

        RefreshLevelButtons();
    }

    public void RefreshLevelButtons()
    {
        foreach (LevelSelectButton levelButton
                 in levelButtons)
        {
            if (levelButton != null)
                levelButton.RefreshButton();
        }
    }

    // Start Game continues from saved progress.
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Called by each level selection button.
    public void PlayLevel(int levelNumber)
    {
        if (!ProgressManager.IsUnlocked(levelNumber))
            return;

        ProgressManager.CurrentLevel = levelNumber;
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}

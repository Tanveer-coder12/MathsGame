
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MathsLevel
{
    [TextArea(3, 5)]
    public string question;

    public int correctAnswer;
}

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text questionText;
    public TMP_Text levelText;
    public Numpad numpad;

    [Header("Level Questions")]
    public MathsLevel[] levels = new MathsLevel[30];

    [Header("Panels")]
    public GameObject levelCompletePanel;

    [Header("Completion Sound")]
    public AudioSource audioSource;
    public AudioClip levelCompleteSound;

    private int currentLevel;
    private bool waitingForNextLevel;
    private bool gameFinished;
    public GameObject GameComplete;
    private void Start()
    {
        currentLevel = ProgressManager.CurrentLevel - 1;

        levelCompletePanel.SetActive(false);
        LoadLevel();
        GameComplete.SetActive(false);
    }

    public void LoadLevel()
    {
        if (currentLevel < 0 ||
            currentLevel >= levels.Length)
            return;

        questionText.text = levels[currentLevel].question;
        levelText.text = "Level " + (currentLevel + 1);

        numpad.gameObject.SetActive(true);
        numpad.ResetInput();

        numpad.SetCorrectAnswer(
            levels[currentLevel].correctAnswer);
    }

    public void CheckAnswer(int playerAnswer)
    {
        if (waitingForNextLevel || gameFinished)
            return;

        if (playerAnswer == levels[currentLevel].correctAnswer)
        {
            waitingForNextLevel = true;

            // Save completion immediately.
            ProgressManager.CompleteLevel(currentLevel + 1);

            levelCompletePanel.SetActive(true);

            if (audioSource != null && levelCompleteSound != null)
            {
                audioSource.PlayOneShot(levelCompleteSound);
            }
        }
        else
        {
            Debug.Log("Wrong answer! Try again.");
        }

        numpad.ResetInput();
    }
  
    public void NextLevel()
    {
        if (!waitingForNextLevel || gameFinished)
            return;

        levelCompletePanel.SetActive(false);
        waitingForNextLevel = false;

        if (currentLevel < levels.Length - 1)
        {
            currentLevel++;

            // Also save the next level before loading it.
                ProgressManager.CurrentLevel = currentLevel + 1;

            LoadLevel();
        }
        else
        {
            gameFinished = true;
            GameComplete.SetActive(true);


            levelText.text =
                levels.Length + " / " + levels.Length;

            numpad.gameObject.SetActive(false);
        }
    }
public void HomeButton()
{
    SceneManager.LoadScene("StartScene");
}
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectButton : MonoBehaviour
{
    public int levelNumber = 1;

    public StartMenuManager menuManager;
    public Button button;
    public Text buttonText;
    public Image buttonImage;

    public Color unlockedColor = new Color(0.12f, 0.55f, 1f);

    public Color completedColor = new Color(0.15f, 0.75f, 0.3f);

    public Color lockedColor = new Color(0.35f, 0.38f, 0.45f);

    public void RefreshButton()
    {
        bool unlocked =
            ProgressManager.IsUnlocked(levelNumber);

        bool completed =
            ProgressManager.IsCompleted(levelNumber);

        button.interactable = unlocked;

        if (buttonText != null)
        {
            if (completed)
                buttonText.text = levelNumber + " ✓";
            else if (unlocked)
                buttonText.text = levelNumber.ToString();
            else
                buttonText.text = levelNumber + " 🔒";
        }

        if (buttonImage != null)
        {
            buttonImage.color = completed
                ? completedColor
                : unlocked
                    ? unlockedColor
                    : lockedColor;
        }
    }

    public void OnClick()
    {
        menuManager.PlayLevel(levelNumber);
    }
}

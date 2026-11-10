
using UnityEngine;

public static class ProgressManager
{
    public const int TotalLevels = 30;

    private const string CurrentLevelKey = "Math_CurrentLevel";
    private const string CompletedPrefix = "Math_Completed_";

    // Saved levels use 1 to 30.
    // The default starting level is 1.
    public static int CurrentLevel
    {
        get
        {
            return Mathf.Clamp( PlayerPrefs.GetInt(CurrentLevelKey, 1),1, TotalLevels);
        }
        set
        {
            PlayerPrefs.SetInt( CurrentLevelKey,Mathf.Clamp(value, 1, TotalLevels));

            PlayerPrefs.Save();
        }
    }

    public static bool IsCompleted(int level)
    {
        return PlayerPrefs.GetInt(
            CompletedPrefix + level, 0) == 1;
    }

    public static bool IsUnlocked(int level)
    {
        if (level < 1 || level > TotalLevels)
            return false;

        // Level 1 is always unlocked.
        if (level == 1)
            return true;

        // Completed levels remain replayable.
        if (IsCompleted(level))
            return true;

        // The next level unlocks after completing
        // the previous level.
        return IsCompleted(level - 1);
    }

    public static void CompleteLevel(int level)
    {
        PlayerPrefs.SetInt(CompletedPrefix + level, 1);

        // Move progress to the next level if possible.
        if (level < TotalLevels)
        {
            CurrentLevel = Mathf.Max( CurrentLevel, level + 1);
        }

        PlayerPrefs.Save();
    }
    public static void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}

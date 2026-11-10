using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI coinText;

    private int levelCoins;
    private int totalCoins;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        ResetRun();

        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        levelCoins += amount;
        totalCoins += amount;

        PlayerPrefs.SetInt("RunCoins", levelCoins);

        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = totalCoins.ToString();
    }

    public int GetRunCoins()
    {
        return PlayerPrefs.GetInt("RunCoins", 0);
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public void ResetRun()
    {
        levelCoins = 0;

        PlayerPrefs.SetInt("RunCoins", 0);
        PlayerPrefs.Save();
    }
}
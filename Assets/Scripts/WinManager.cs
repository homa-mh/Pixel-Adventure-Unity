using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public TextMeshProUGUI totalCoinText;

    void Start()
    {
        Time.timeScale = 1f;

        int totalCoins = PlayerPrefs.GetInt("RunCoins", 0);

        totalCoinText.text = "Total Coins : " + totalCoins;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
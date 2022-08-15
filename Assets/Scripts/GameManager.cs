using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Main UI handler
public class GameManager : MonoBehaviour
{
    /*
     * Have a score for gold held on the player
     * Have a score for gold stored in the pirate base
     * Helped with scrips from Merchant, GoldCollision, PirateBaseCollision, maybe Enemy
     */

    public int score; // public for PirateBase
    private int bank; // the bank is the true score, where score is saved!
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bankText;
    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI nameAndBestScoreText; // for MainManager

    public bool isGameActive;
    public Button restartButton;
    public Button backToMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        UpdateBank(0);
        isGameActive = true;

        // passes Name from MainManager to GameManager
        if (MainManager.Instance != null)
        {
            nameAndBestScoreText.text = MainManager.Instance.bestScoreName + " : " + MainManager.Instance.bestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when player collides with objects representing Gold
    public void UpdateScore(int scoreToAdd) // make this public
    {
        score += scoreToAdd;
        scoreText.text = "Stash: " + score;
    }

    // add score to bank
    // called when player collides with PirateBase
    public void UpdateBank(int scoreToAdd)
    {
        bank += scoreToAdd;
        score = 0;
        scoreText.text = "Stash: " + score;
        bankText.text = "Bank: " + bank;
    }

    // keep track of latest best score
    // called when an enemy collides with the player
    // which is the only way to lose (as of now).
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        backToMenuButton.gameObject.SetActive(true);

        UpdateBestScore(bank);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        bank = 0;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // we need to save the highest score between scenes!
    // and the player's name
    // Saves player's name and highscore to MainManager
    public int UpdateBestScore(int currentScore)
    {
        // checks if current player's score is greater than the best score
        if (currentScore > MainManager.Instance.bestScore)
        {
            MainManager.Instance.bestScore = currentScore;
            MainManager.Instance.bestScoreName = MainManager.Instance.Name;
            MainManager.Instance.SaveBestScore();
        }
        return currentScore;
    }

}

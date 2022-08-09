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
    private int hoard;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hoardText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI nameText; // for MainManager
    public bool isGameActive;

    public Button restartButton;
    public Button backToMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        UpdateBank(0);
        isGameActive = true;
        nameText.text = MainManager.Instance.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd) // make this public
    {
        score += scoreToAdd;
        scoreText.text = "Stash: " + score;
    }

    // add score to bank
    public void UpdateBank(int scoreToAdd)
    {
        hoard += scoreToAdd;
        score = 0;
        scoreText.text = "Stash: " + score;
        hoardText.text = "Hoard: " + hoard;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        backToMenuButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        hoard = 0;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required for InputField
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    // not relevant to start method code
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI bestScoreText;

    // taken from unity answers
    public TMP_InputField enterName;
    
    // for non-TMP inputfield
    //public InputField input;

    // Start is called before the first frame update
    void Start()
    {

    }
    // called when the script instance is being loaded
    void Awake()
    {
        UpdateMenu();
    }

    public void UpdateMenu()
    {
        bestScoreText.text = "Best Score: " + MainManager.Instance.bestScoreName + " : " + MainManager.Instance.bestScore;
        //dead code
        enterName.text = MainManager.Instance.bestScoreName;
    }

    // called by StartButton
    // WARNING: this overrides any name previously entered, so names with highscores can be overwritten
    // best player's name is now saved in a separate data field to avoid the above issue.
    public void SubmitName()
    {
        // can set Name = enterName.text to avoid mistakes
        MainManager.Instance.Name = nameText.text;
    }

    // called by StartButton
    public void StartNew()
    {
        // Load SampleScene
        SceneManager.LoadScene(1);
    }

    // called by Exit button
    public void Exit()
    {
#if UNITY_EDITOR
EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        MainManager.Instance.SaveName();
    }

    // we need to save the previous Name between scenes!
    public void SaveNameInput()
    {

    }

    public void LoadNameInput()
    {

    }

    // use with CAUTION! For testing only
    // needs button, may not work properly
    public void DeleteBestScore()
    {
        MainManager.Instance.bestScore = 0;
    }
}

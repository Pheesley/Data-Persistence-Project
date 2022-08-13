using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; // required for InputField
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

    // Start is called before the first frame update
    void Start()
    {
        // taken from StackOverflow
        /*
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
        */

        // or use the line below
        //input.onEndEdit.AddListener(SubmitName); // this also works
    }
    // called when the script instance is being loaded
    void Awake()
    {
        UpdateMenu();
    }

    public void UpdateMenu()
    {
        bestScoreText.text = "Best Score: " + MainManager.Instance.Name + " : " + MainManager.Instance.bestScore;
    }

    // called by StartButton
    public void SubmitName(string arg0)
    {
        // string parameter is unnecessary, but useful for testing
        Debug.Log(arg0);
        MainManager.Instance.Name = nameText.text;
    }

    // called by StartButton
    public void StartNew()
    {
        // Load SampleScene
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        MainManager.Instance.SaveName();
    }

    // we need to save the previous Name betweens scenes!
    public void SaveNameInput()
    {

    }

    public void LoadNameInput()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInputField;
    public Button startButton;
    public Button quitButton;

    private string highScoreName;
    private int highScoreValue;

    public string userName;

    private void Start()
    {
        scoreText.text = "HighScore: " + GameManager.Instance.highScore.UserScore;
    }
    public void StartGame()
    {
        GameManager.Instance.score.UserName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}

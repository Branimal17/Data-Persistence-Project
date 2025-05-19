using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody BallPrefab;
    private Rigidbody ballInstance;

    public string userName;
    public Text ScoreText;

    //highsore variables
    private string highScoreName;
    private int currentHighScore;
    public Text highScoreText;

    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    
    private bool m_GameOver = false;
    
    
    // Start is called before the first frame update
    void Start()
    {

        currentHighScore = GameManager.Instance.highScore.UserScore;
        highScoreName = GameManager.Instance.highScore.UserName;
            
        userName = GameManager.Instance.score.UserName;

        ScoreText.text = $"Score : {userName} : {m_Points}";

        highScoreText.text = $"High Score: {highScoreName} : {currentHighScore}";

        StartGame();
    }

    private void Update()
    {
        if (!m_Started && ballInstance != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                ballInstance.transform.SetParent(null);
                ballInstance.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                StartGame();
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {userName} : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        m_Started = false;
        GameOverText.SetActive(true);
        UpdateHighScore();

    }
    public void UpdateHighScore()
    {
        if (currentHighScore < m_Points)
        {
            currentHighScore = m_Points;
            highScoreText.text = $"High Score: {userName} : {currentHighScore}";
            GameManager.Instance.SaveScore(userName, m_Points);
        }
    }

    void StartGame()
    {
        m_Started = false;
        m_GameOver = false;
        m_Points = 0;

        ScoreText.text = $"Score : {userName} : {m_Points}";
        GameOverText.SetActive(false);

        SpawnBall();

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };

        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }
    void SpawnBall()
    {
        if (ballInstance != null)
        {
            Destroy(ballInstance.gameObject);
        }

        ballInstance = Instantiate(BallPrefab, new Vector3(0, 1.0f, 0), Quaternion.identity);
    }
}

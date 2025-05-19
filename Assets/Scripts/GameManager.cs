using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Score score = new Score();
    public Score highScore;

    // Start is called before the first frame update
    void Awake()
    {
        highScore = LoadScore();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveScore(string name, int score)
    {
        highScore = new Score(name, score);
        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(Application.persistentDataPath + "/scoreinfo.json", json);


    }
    public Score LoadScore()
    {
        string path = Application.persistentDataPath + "/scoreinfo.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            highScore = JsonUtility.FromJson<Score>(json);

        }
        else
        {
            highScore = new Score("No score Yet", 0);
        }
        return highScore;
    }

}

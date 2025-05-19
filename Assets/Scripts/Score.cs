using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[System.Serializable]
public class Score
{
    public string UserName;
    public int UserScore;

    public Score()
    {
      
    }

    public Score(string userName, int userScore)
    {
        UserName = userName;
        UserScore = userScore;
    }   
}



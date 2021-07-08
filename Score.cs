using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    static int _currentHighScore;
    static int _currentScore;
    static string _highscoreKey = "SDB23D_HighScore";
    TMP_Text score;
    TMP_Text highscore;
    
    void Start()
    {
        _currentHighScore = PlayerPrefs.GetInt(_highscoreKey, 100);
        _currentScore = 0;
        
        var tmpTexts = FindObjectsOfType<TMP_Text>();
        foreach (var tmpText in tmpTexts)
        {
            if (tmpText.name == "Highscore")
            {
                highscore = tmpText;
            }

            if (tmpText.name == "Score")
            {
                score = tmpText;
            }
        }
        highscore.SetText($"<incr>{_currentHighScore}</incr>");
        score.SetText($"<rainb>{_currentScore}</rainb>");
    }

    public void AddScore(int value)
    {
        _currentScore += value;
        if (_currentScore > _currentHighScore)
        {
            _currentHighScore = _currentScore;
            highscore.SetText($"<rainb>{_currentHighScore}</rainb>");
        }
        score.SetText($"<rainb>{_currentScore}</rainb>");
    }
    
    static public void SaveOutNewHighscore()
    {
        if (_currentScore == _currentHighScore)
            PlayerPrefs.SetInt(_highscoreKey,_currentHighScore);
    }
    
}

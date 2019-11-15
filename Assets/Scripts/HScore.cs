using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HScore : MonoBehaviour
{
    public Text highScore;

    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
    }
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
 
}
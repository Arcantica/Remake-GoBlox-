using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float totalScore;
    private float currentScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highest;

    private void Start()
    {
        currentScore = PlayerPrefs.GetFloat("currentScore");
    }
    public void SetScore()
    {
        ++totalScore;
        PlayerPrefs.SetFloat("totalScore", totalScore);
        if(totalScore > currentScore)
        {
            currentScore = totalScore;
            PlayerPrefs.SetFloat("currentScore", currentScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        highest.text = "Highest: " + PlayerPrefs.GetFloat("currentScore").ToString();
        score.text = "Score: " + PlayerPrefs.GetFloat("totalScore").ToString();
        Debug.Log("score changed");
    }
}

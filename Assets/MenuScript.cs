using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuScript : MonoBehaviour
{
    public ScoreObject scoreObject;
    public TMP_Text scoreText;

    public void LoadScene(){
        SceneManager.LoadScene("GameScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void quitgame(){
        Application.Quit();
    }

    public void DisplayScore(){
        if (scoreText != null && scoreObject != null)
            scoreText.text = "Score: " + scoreObject.score;
    }
}

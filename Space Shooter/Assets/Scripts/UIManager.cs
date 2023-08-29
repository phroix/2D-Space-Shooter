using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Image livesImg;
    [SerializeField]
    private Sprite[] liveSprites;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text restartText;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: " +0;
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayScore(int playerScore)
    {
        text.text = "Score: " + playerScore.ToString();
    }

    public void UpddateLives(int currentLives)
    {
        livesImg.sprite = liveSprites[currentLives];

        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        levelManager.GameOver();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(.5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UI : MonoBehaviour
{
    public static UI Instance {get; private set;}
    [SerializeField]private TMP_Text scoreUI;
    [SerializeField]private TMP_Text finalscoreUI;
    [SerializeField]private GameObject gameOverUI;
    private int _score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    void Start()
    {
        scoreUI.text = "Score : 0";
        Locator.Instance.Player.playerScored += AddPoint;
        Locator.Instance.Player.playerDied += GameOver;
    }

    public void AddPoint()
    {
        Debug.Log("AddPoint()");
        _score += 1;
        scoreUI.text = "Score : " + _score;
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
        finalscoreUI.text = "Your Final Score: " + _score;
        scoreUI.gameObject.SetActive(false);
    }


}

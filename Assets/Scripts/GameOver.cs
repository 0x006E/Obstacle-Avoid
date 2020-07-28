using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;

    public Text secondsSurvived;

    private bool _gameOver;
    // Start is called before the first frame update
    private void Start()
    {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(0);
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvived.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        _gameOver = true;
    }
}

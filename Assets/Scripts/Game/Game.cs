using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public GameObject LevelInterface;
    public SnakeHeadMove SnakeHeadMove;
    public BreakBarrier BreakBarrier;
    public GameObject Score;

    private int _topScore;
    private int _bottomScore;
    private int _intermediateScore;
    private int _highestLevel;
    public enum State
    { 
        Playing,
        Loss,
        Won,
    }
    public State CurrentState { get; private set; }

    private void Awake()
    {
        _topScore = PlayerPrefs.GetInt("TopScore");
    }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        SnakeHeadMove.enabled = false;
        ScreenOfLose();
        _intermediateScore = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("intermediateScore", _intermediateScore);
        _bottomScore = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", 0);
        TopScore();

        Debug.Log("You Loss");
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        SnakeHeadMove.enabled = false;
        StopAllCoroutines();
        ScreenOfWin();
        _highestLevel++;
        _intermediateScore = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("intermediateScore", _intermediateScore);
        _bottomScore = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("HighestLevel", _highestLevel);
        TopScore();

        Debug.Log("You Won");
        
    }
    public void ScreenOfLose()
    {
        LoseScreen.SetActive(true);
    }
    public void ScreenOfWin()
    {
        WinScreen.SetActive(true);
    }
    public void TopScore()
    {
        if (_topScore<_bottomScore)
        {
            PlayerPrefs.SetInt("TopScore", _bottomScore);
        }
    }

}
    

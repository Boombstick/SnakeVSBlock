using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public GameObject MainMenu;
    public GameObject LevelInterface;
    public SnakeHeadMove SnakeHeadMove;
    public BreakBarrier BreakBarrier;
    public enum State
    { 
        Playing,
        Loss,
        Won,
    }
    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        SnakeHeadMove.enabled = false;
        BreakBarrier.enabled = false;
        ScreenOfLose();
        Debug.Log("You Loss");
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        SnakeHeadMove.enabled = false;
        BreakBarrier.enabled = false;
        StopAllCoroutines();
        ScreenOfWin();
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

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        LevelInterface.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void NextLevel()
    {
       
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    

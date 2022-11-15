using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
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
        Debug.Log("You Loss");
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        SnakeHeadMove.enabled = false;
        BreakBarrier.enabled = false;
        Debug.Log("You Won");
        
    }


}
    

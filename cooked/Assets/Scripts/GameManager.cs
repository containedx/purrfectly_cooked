using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }

    public event EventHandler OnStateChanged;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    private State _state;
    private State state
    {
        get => _state;
        set
        {
            _state = value;

            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    [SerializeField] private float gamePlayingTimer = 10f;
    private float gamePlayingTimerLeft = 10f;


    private void Awake()
    {
        state = State.WaitingToStart;
        Instance = this;
        gamePlayingTimerLeft = gamePlayingTimer;
    }


    private void Update()
    {
        switch(state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if( waitingToStartTimer < 0f )
                {
                    state = State.CountdownToStart;
                }
                break;

            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if( countdownToStartTimer < 0f )
                {
                    state = State.GamePlaying;
                }
                break;

            case State.GamePlaying:
                gamePlayingTimerLeft -= Time.deltaTime;
                if( gamePlayingTimerLeft < 0f )
                {
                    state = State.GameOver;
                }
                break;

            case State.GameOver:
                break;
        }
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountdownActive()
    {
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public float GetGamePLayingTimerNormalized()
    {
        return 1 - (gamePlayingTimerLeft/gamePlayingTimer);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    private Ball _ball;
    private bool _isStarted;

    #endregion
    
    #region Events

    public event Action OnGameOver;

    #endregion


    #region Unity Lifecycle

    protected override void Awake()
    {
        base.Awake();

        _ball = FindObjectOfType<Ball>();
    }

    private void Start()
    {
        LevelManager.Instance.OnAllBlocksDestroyed += PerformWin;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnAllBlocksDestroyed -= PerformWin;
    }

    private void Update()
    {

        if (_isStarted)
            return;

        _ball.MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion


    #region Public Methods

    public void LoseLife()
    {
        _isStarted = false;
        _ball.RestartBall();
        Statistics.Instance.Attempt++;
        Statistics.Instance.NextImage();
        CheckGameOver();
        //CheckWin();
    }

    #endregion


    #region Private Methods

    private void CheckWin()
    {
        throw new NotImplementedException();
    }

    private void CheckGameOver()
    {
        if (Statistics.Instance.HPCount == 0)
        {
            OnGameOver?.Invoke();
        }
            
    }

    private void PerformGameOver()
    {
        
    }

    private void PerformWin()
    {
        SceneLoader.Instance.LoadNextLevel();
    }

    private void StartBall()
    {
        _isStarted = true;
        _ball.StartMove();
    }
    

    #endregion
}
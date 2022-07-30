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
    

    #endregion
    
    #region Events

    public event Action OnGameOver;
    public event Action OnGameWinn; 

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

    #endregion


    #region Public Methods

    public void LoseLife()
    {
        FindObjectOfType<Ball>().RestartBall();
        _ball.RestartBall();
        Statistics.Instance.Attempt++;
        Statistics.Instance.NextImage();
        CheckGameOver();
        
    }

    #endregion


    #region Private Methods

  

    private void CheckGameOver()
    {
        if (Statistics.Instance.HPCount == 0)
        {
            OnGameOver?.Invoke();
        }
            
    }

    private void PerformWin()
    {
        OnGameWinn?.Invoke();
    }

  
    

    #endregion
}
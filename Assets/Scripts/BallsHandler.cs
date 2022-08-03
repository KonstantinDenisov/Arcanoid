using System;
using System.Collections.Generic;
using UnityEngine;

public class BallsHandler : SingletonMonoBehaviour<BallsHandler>
{
    #region Properties

    public int BallCount { get; private set; }

    public List<Ball> AllBalls { get; private set; } = new List<Ball>();

    #endregion


    #region Events

    public event Action OnAllBallsDestroyed;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        
       // Ball.OnBallCreated += BallCreated;
    }

    #endregion


    #region Public methods

    public void BallCreate()
    {
        BallCount++;
    }

    public void BallDestroy()
    {
        BallCount--;
        if (BallCount == 0)
        {
            OnAllBallsDestroyed?.Invoke();
        }
    }

    #endregion


    #region Private methods

    private void BallCreated()
    {
        
    }

    #endregion
}
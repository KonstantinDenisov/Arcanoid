using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Ball _ball;
    [SerializeField] private TextMeshProUGUI _statisticsLabel;
    private bool _isStarted;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        LevelManager.Instance.OnAllBlocksDestroyed += PerdormWin;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnAllBlocksDestroyed -= PerdormWin;
    }

    private void PerdormWin()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        SetStatisticsLabel();
        
        if (_isStarted)
            return;

        _ball.MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion


    #region Private Methods

    private void StartBall()
    {
        _isStarted = true;
        _ball.StartMove();
    }

    private void SetStatisticsLabel()
    {
        _statisticsLabel.text = $"Score - {Statistics.Instance.Points}. Attempt - {Statistics.Instance.Attempt}.";
    }

    #endregion
}
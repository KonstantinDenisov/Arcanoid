using System;
using TMPro;
using UnityEngine;

public class GameOverLabel : MonoBehaviour
{
    #region Variables
    [SerializeField] private UnityEngine.UI.Image _gameOverLabel;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        GameManager.Instance.OnGameOver += GameOver;

    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= GameOver;
    }

   

    private void Update()
    {
        
   
    }

    #endregion


    #region Private Methods
    
    private void GameOver()
    {
        PauseManager.Instance.StopTime();
        _gameOverLabel.gameObject.SetActive(true);
    }

   

    #endregion
}
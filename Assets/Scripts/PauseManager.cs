using UnityEngine;
using UnityEngine.Serialization;
using System;

public class PauseManager : SingletonMonoBehaviour<PauseManager>

{
    #region Events

    public event Action<bool> OnPaused;

    #endregion
    
    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
    #endregion


    #region Public Methods

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    #endregion


    #region Private Methods

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        OnPaused?.Invoke(IsPaused);
    }



    #endregion

    
}

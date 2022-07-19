using UnityEngine;
using UnityEngine.Serialization;

public class PauseManager : SingletonMonoBehaviour<PauseManager>

{
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


    #region Private Methods

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion

    
}

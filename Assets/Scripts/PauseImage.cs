using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseImage : SingletonMonoBehaviour<PauseImage>
{
    #region Variable

    [SerializeField] private Image _pauseImage;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (PauseManager.Instance.IsPaused)
            _pauseImage.gameObject.SetActive(true);
        else
        {
            _pauseImage.gameObject.SetActive(false);
        }

        //  PauseManager.Instance.IsPaused == true ? _pauseImage.gameObject.SetActive(true) : _pauseImage.gameObject.SetActive(false);
    }

    #endregion

}
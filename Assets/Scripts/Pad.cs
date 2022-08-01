using System;
using Unity.VisualScripting;
using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    public bool IsPadCatcher;

    #endregion
    #region Unity Lifecycle

    private void Update()
    {
        if (PauseManager.Instance.IsPaused == true)
            return;
        
            Vector3 mousePositionInPixels = Input.mousePosition;
            Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);

            Vector3 currentPosition = transform.position;
            currentPosition.x = mousePositionInUnits.x;
            transform.position = currentPosition;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (IsPadCatcher)
            if (col.gameObject.CompareTag(Tags.Ball))
            {
                var ball = col.gameObject.GetComponent<Ball>();
                ball.RestartBall();
            }
    }

    #endregion


    #region Public Methods

    public void CatchBall()
    {
        
    }

    #endregion
}
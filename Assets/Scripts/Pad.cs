using System;
using UnityEngine;

public class Pad : MonoBehaviour
{
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

    #endregion
}
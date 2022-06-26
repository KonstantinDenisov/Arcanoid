using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   #region Variables

   [SerializeField] private Ball _ball;
   private bool _isStarted;

   #endregion
   #region Unity Lifecycle

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


   private void StartBall()
   {
      _isStarted = true;
      _ball.StartMove();
   }
}

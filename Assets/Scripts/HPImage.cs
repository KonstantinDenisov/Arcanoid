using System;
using TMPro;
using UnityEngine;

public class HPImage : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private SpriteRenderer _hpSpriteRenderer;
    public Sprite[] HP;

    #endregion


    #region Unity Lifecycle
    
    private void Update()
    {
       if (HP.Length >= Statistics.Instance.HPCount - 1)
           _hpSpriteRenderer.sprite = HP[Statistics.Instance.HPCount - 1];
       else
       {
           return;
       }
    }

    #endregion


    #region Private Methods
    
   

   

    #endregion
}
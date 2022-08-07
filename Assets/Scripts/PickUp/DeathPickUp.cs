﻿
    using UnityEngine;

    public class DeathPickUp: PickUpBase
    {
        #region Variables

        [SerializeField] private int _score;

        #endregion
        
        protected override void ApplyEffect(Collision2D col)
        {
            Statistics.Instance.HPCount--;
            AudioPlayer.Instance.AddNegativePickUpAudioClip();
            Statistics.Instance.ChangeScore(_score);
        }
    }

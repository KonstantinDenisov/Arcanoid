using UnityEngine;

public class ScoreChangePickUp : PickUpBase
{
    #region Variables
    
    [Header(nameof(ScoreChangePickUp))]
    [SerializeField] private int _score;

    #endregion


    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        Statistics.Instance.ChangeScore(_score);
        AudioPlayer.Instance.AddPositivePickUpAudioClip();
    }
    
    #endregion
}
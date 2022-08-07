using UnityEngine;

public class ExplosiveBallPickUp : PickUpBase
{
    #region Variables

    [SerializeField] private int _score;

    #endregion
    
    
    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ExplosiveBall();
        AudioPlayer.Instance.AddPositivePickUpAudioClip();
        Statistics.Instance.ChangeScore(_score);
    }

    #endregion
}
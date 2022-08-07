using UnityEngine;

public class CatcherPickUP : PickUpBase
{
    #region Variables

    [SerializeField] private int _score;

    #endregion
    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Pad>().IsPadCatcher = true;
        AudioPlayer.Instance.AddPositivePickUpAudioClip();
        Statistics.Instance.ChangeScore(_score);
    }

    #endregion
}
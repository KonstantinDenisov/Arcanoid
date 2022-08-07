
    using UnityEngine;

    public class ChangeScalePadPickUP : PickUpBase
    {

        #region Variables

        [SerializeField] private float _multiplier;
        [SerializeField] private int _score;

        #endregion
        
        protected override void ApplyEffect(Collision2D col)
        {
            FindObjectOfType<Pad>().ChangeScale(_multiplier);
            AudioPlayer.Instance.AddPositivePickUpAudioClip();
            Statistics.Instance.ChangeScore(_score);
        }
        
    }
    
    

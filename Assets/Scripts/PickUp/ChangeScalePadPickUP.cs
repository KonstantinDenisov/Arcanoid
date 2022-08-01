
    using UnityEngine;

    public class ChangeScalePadPickUP : PickUpBase
    {

        #region Variables

        [SerializeField] private float _multiplier;

        #endregion
        protected override void ApplyEffect(Collision2D col)
        {
            FindObjectOfType<Pad>().ChangeScale(_multiplier);
        }
    }

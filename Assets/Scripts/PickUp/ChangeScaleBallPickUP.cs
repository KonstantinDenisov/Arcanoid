using UnityEngine;

public class ChangeScaleBallPickUP : PickUpBase
{
    #region Variables

    [SerializeField] private float _multiplier;

    #endregion


    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeScale(_multiplier);
    }

    #endregion
}
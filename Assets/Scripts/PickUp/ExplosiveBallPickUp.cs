using UnityEngine;

public class ExplosiveBallPickUp : PickUpBase
{
    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ExplosiveBall();
    }

    #endregion
}
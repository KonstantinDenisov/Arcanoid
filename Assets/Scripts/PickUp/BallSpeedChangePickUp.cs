using UnityEngine;

public class BallSpeedChangePickUp : PickUpBase
{
    #region Variables

    [Header(nameof(BallSpeedChangePickUp))]
    [SerializeField] private float _speedMultiplier = 2f;

    #endregion


    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeSpeed(_speedMultiplier);
    }

    #endregion
}
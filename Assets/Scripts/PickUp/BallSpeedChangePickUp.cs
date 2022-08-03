using UnityEngine;

public class BallSpeedChangePickUp : PickUpBase
{
    #region Variables

    [Header(nameof(BallSpeedChangePickUp))]
    [SerializeField] private float _speedMultiplier;

    #endregion


    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            ball.ChangeSpeed(_speedMultiplier);
        }
    }

    #endregion
}
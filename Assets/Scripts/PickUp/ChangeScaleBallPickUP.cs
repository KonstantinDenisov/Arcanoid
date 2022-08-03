using UnityEngine;

public class ChangeScaleBallPickUP : PickUpBase
{
    #region Variables

    [SerializeField] private float _multiplier;

    #endregion


    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            ball.ChangeScale(_multiplier);
        }
    }

    #endregion
    
    
}
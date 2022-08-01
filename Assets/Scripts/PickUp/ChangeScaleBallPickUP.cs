using UnityEngine;

public class ChangeScaleBallPickUP : PickUpBase
{

    #region Variables

    [SerializeField] private float _multiplier;

    #endregion
    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeScale(_multiplier);
    }
}
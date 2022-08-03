using UnityEngine;

public class CatcherPickUP : PickUpBase
{
    #region Protected Methods

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Pad>().IsPadCatcher = true;
    }

    #endregion
}
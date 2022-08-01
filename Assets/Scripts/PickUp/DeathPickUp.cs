
    using UnityEngine;

    public class DeathPickUp: PickUpBase
    {
        protected override void ApplyEffect(Collision2D col)
        {
            Statistics.Instance.HPCount--;
        }
    }

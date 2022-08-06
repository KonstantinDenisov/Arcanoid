using UnityEngine;

public class ExplosiveBlock : Block
{
    #region Variables

    [Header(nameof(ExplosiveBlock))]
    [SerializeField] private float _explosiveRadius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _drop;

    #endregion


    #region Unity lifecycle

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosiveRadius);
    }

    #endregion


    #region Public methods

    public override void DestroyBlock()
    {
        base.DestroyBlock();
        Explode();
        if (_drop != null)
        {
            Instantiate(_drop, transform.position, Quaternion.identity);
        }
    }

    #endregion


    #region Private methods

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosiveRadius, _layerMask);

        foreach (Collider2D collider1 in colliders)
        {
            Block blockToExplode = collider1.GetComponent<Block>();
            blockToExplode.DestroyBlock();
        }
    }

    #endregion
}
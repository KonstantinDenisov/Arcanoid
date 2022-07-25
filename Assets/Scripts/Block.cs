using System;
using System.Net.Mime;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Block : MonoBehaviour
{
    #region Events
    public static event Action <Block> OnDestroyed;

    public static event Action<Block> OnCreated; 

    #endregion
    
    #region Variables

    [SerializeField] protected int _hp;
    [SerializeField] protected int _points;
    [SerializeField] protected Sprite[] _images;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected int _iterator = 1;

    protected int _spriteIndex;

    #endregion


    #region Unity Lifecycle

    protected virtual void Start()
    {
        OnCreated?.Invoke(this);
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        Statistics.Instance.Points += _points;
        _hp--;
        if (_hp == 0)
            Destroy(gameObject);

        _spriteRenderer.sprite = _images[_images.Length - _iterator];
        _iterator++;
        _points--;
    }

    protected void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    #endregion


   
}
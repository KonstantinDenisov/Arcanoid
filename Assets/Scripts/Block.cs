using System;
using System.Net.Mime;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Block : MonoBehaviour
{
   
    
    #region Variables

    [SerializeField] protected int _hp;
    [SerializeField] protected int _points;
    [SerializeField] protected Sprite[] _images;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected int Iterator = 1;

    

    #endregion
    
    #region Events
    public static event Action <Block> OnDestroyed;

    public static event Action<Block> OnCreated; 

    #endregion


    #region Unity Lifecycle

    protected virtual void Start()
    {
        OnCreated?.Invoke(this);
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        ApplyDamage();
    }

    protected void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    #endregion


    #region Protected Methods

    protected virtual void ApplyDamage()
    {
        Statistics.Instance.Points += _points;
        _hp--;
        if (_hp == 0)
            Destroy(gameObject);
        
        if (_images.Length - Iterator >=0)
            _spriteRenderer.sprite = _images[_images.Length - Iterator];
        
        Iterator++;
        _points--;
    }

    #endregion


   
}
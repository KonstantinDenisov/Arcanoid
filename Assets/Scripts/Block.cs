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

    [SerializeField] private int _hp;
    [SerializeField] private int _points;
    [SerializeField] private Sprite[] _images;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private int _iterator = 1;

    private int _spriteIndex;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        OnCreated?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Statistics.Instance.Points += _points;
        _hp--;
        if (_hp == 0)
            Destroy(gameObject);

        _spriteRenderer.sprite = _images[_images.Length - _iterator];
        _iterator++;
        _points--;
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    #endregion


   
}
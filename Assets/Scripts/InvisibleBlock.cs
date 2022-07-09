using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : Block
{
    #region Variables

    [SerializeField] private int _hp;
    [SerializeField] private int _points;
    [SerializeField] private Sprite[] _images;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private int _iterator = 1;

    private int _spriteIndex;

    private Color _startColor;

    #endregion


    #region Unity Lifecycle

    private void Start()
    {
        //_spriteRenderer.color.a = 0f;
        
        Color spriteRendererColor = _spriteRenderer.color;
        spriteRendererColor.a = 0;
        _spriteRenderer.color = spriteRendererColor;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Color spriteRendererColor = _spriteRenderer.color;
        spriteRendererColor.a = 1;
        _spriteRenderer.color = spriteRendererColor;
        
        Statistics.Instance.Points += _points;
        _hp--;
        if (_hp == 0)
            Destroy(gameObject);

        _spriteRenderer.sprite = _images[_images.Length - _iterator];
        _iterator++;
        _points--;
        
        
        
    }

    #endregion
}

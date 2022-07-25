using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : Block
{
    #region Variables

    #endregion


    #region Unity Lifecycle

    protected override void Start()
    {
        Color spriteRendererColor = _spriteRenderer.color;
        spriteRendererColor.a = 0;
        _spriteRenderer.color = spriteRendererColor;
    }

    protected void OnCollisionEnter2D(Collision2D col)
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

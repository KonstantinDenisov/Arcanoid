using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : Block
{
    #region Variables

    private bool _isVisible;

    #endregion


    #region Unity Lifecycle

    protected override void Start()
    {
        base.Start();
       SetAlpha(0f);
    }

    #endregion
    
    #region Protected Methods

    protected override void ApplyDamage()
    {
        SetAlpha(1f);
        
        if (_isVisible)
            base.ApplyDamage();

        _isVisible = true;

    }

    #endregion


    #region Private Methods

    private void SetAlpha(float alpha)
    {
        Color spriteRendererColor = _spriteRenderer.color;
        spriteRendererColor.a = alpha;
        _spriteRenderer.color = spriteRendererColor; 
    }

    #endregion
}

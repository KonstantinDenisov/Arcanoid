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

    [Header("UI")]
    [SerializeField] private int _hp;
    [SerializeField] private int _points;
    [SerializeField] private Sprite[] _images;
    private int _iterator = 1;

    private int _spriteIndex;

    #endregion


    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        Statistics.Instance.Points += _points;
        _hp--;
        if (_hp == 0)
            Destroy(gameObject);

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _images[_images.Length - _iterator];
        _iterator++;
        _points--;


    }

    #endregion
}
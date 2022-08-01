using System;
using System.Net.Mime;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
   
    
    #region Variables

    [Header("Block")]
    [SerializeField] protected int _hp;
    [SerializeField] protected int _points;
    [SerializeField] protected Sprite[] _images;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    protected int Iterator = 1;

    [Header("PickUp")]
    [SerializeField] private GameObject [] _pickUpPrefab;

    [Range(0f, 1f)]
    [SerializeField] private float _pickUpSpawnChance = 0.5f;
    

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
        SpawnPickUp();
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


    #region PrivateMethods

    private void SpawnPickUp()
    {
        if (_pickUpPrefab.Length == 0)
            return;
        
        float random = Random.Range(0f, 1f);
        if (random <= _pickUpSpawnChance)
        {
            int random2 = Random.Range(0, _pickUpPrefab.Length);
            Instantiate(_pickUpPrefab[random2], transform.position, Quaternion.identity);
        }
    }

    #endregion


   
}
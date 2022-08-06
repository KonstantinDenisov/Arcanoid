using System;
using UnityEngine;
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
    [Range(0f, 1f)]
    [SerializeField] private float _pickUpSpawnChance;
    [SerializeField] private PickUpInfo[] _pickUpInfoArray;

    [Header("Music")]
    [SerializeField] private AudioClip _audioClip;

    #endregion


    #region Events

    public static event Action<Block> OnDestroyed;

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
        { 
            DestroyBlock();
        }
            

        if (_images.Length - Iterator >= 0)
            _spriteRenderer.sprite = _images[_images.Length - Iterator];

        Iterator++;
        _points--;
    }
    #endregion


    #region PrivateMethods

    private void SpawnPickUp()
    {
        if (_pickUpInfoArray == null || _pickUpInfoArray.Length == 0)
            return;

        float random = Random.Range(0f, 1f);
        if (random > _pickUpSpawnChance)
            return;

        int chanceSum = 0;

        foreach (PickUpInfo pickUpInfo in _pickUpInfoArray)
        {
            chanceSum += pickUpInfo.SpawnChance;
        }

        int randomChance = Random.Range(0, chanceSum);
        int currentChance = 0;
        int currentIndex = 0;

        for (int i = 0; i < _pickUpInfoArray.Length; i++)
        {
            PickUpInfo pickUpInfo = _pickUpInfoArray[i];
            currentChance += pickUpInfo.SpawnChance;

            if (currentChance >= randomChance)
            {
                currentIndex = i;
                break;
            }
        }

        PickUpBase pickUpPrefab = _pickUpInfoArray[currentIndex].PickUpPrefab;
        Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
    }

    #endregion


    #region Public Methods

    public virtual void DestroyBlock()
    {
        AudioPlayer.Instance.PlaySound(_audioClip);
        SpawnPickUp();
        Destroy(gameObject); 
    }

    #endregion
}
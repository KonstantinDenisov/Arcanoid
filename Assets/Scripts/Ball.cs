﻿using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(SpriteRenderer))]

public class Ball : MonoBehaviour

{
    #region Variables

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Pad _pad;

    [FormerlySerializedAs("_speed")] [SerializeField] private float _startSpeed = 5f;
    
    [Range(-1,1)]
    [SerializeField] private float _xMin;
    
    [Range(-1,1)]
    [SerializeField] private float _xMax;
    
    [Range(0.3f,1)]
    [SerializeField] private float _yMin;
    
    [Range(0.3f,1)]
    [SerializeField] private float _yMax;

    [SerializeField] private Transform _transform;
    
    [Range(1f,5f)]
    [SerializeField] private float _minSpeed = 5;
    
    [Range(10f,50f)]
    [SerializeField] private float _maxSpeed = 20;
    
    
    [SerializeField] private Vector3 _minScale = Vector3.one;
    
    [Range(5f,10f)]
    [SerializeField] private Vector3 _maxScale;

    private float _currentSpeed;
    
    private Vector2 _startDirection;

    private Vector2 _startPosition;
    
    [FormerlySerializedAs("_isStarted")] public bool IsStarted;

    private bool _isNewBall;
    private BallsHandler _ballsHandler;
    
    [Header("Music")]
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private float _explosiveRadius;
    [SerializeField] private LayerMask _layerMask;
    public bool IsExplosiveBall;

    [SerializeField] private Sprite _startSprite;
    [SerializeField] private Sprite _explosiveSprite;
    

    [Header("TrailRenderer")]
    [SerializeField] private TrailRenderer _trailRenderer;

    #endregion


    #region Events

    public event Action OnBallCreated;
    public event Action OnBallFell;
    public event Action OnExplosiveBall;

    #endregion
    


    #region Unity LifeCycle

    private void OnEnable()
    {
        _trailRenderer.enabled = false;
        OnExplosiveBall += ChangeImage;
    }

    private void Start()
    {
        if (_isNewBall)
        {
            return;
        }
        RestartBall();
    }
    

    private void Awake()
    {
        _startPosition = transform.position;
        CalculateDirection();
  
    }

    private void Update()
    {
        if (IsStarted)
            return;

        MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _audioSource.Play();
        if (IsExplosiveBall)
        {
            Explode();
        }
            
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosiveRadius);
    }

    #endregion


    #region Public Methods

    public void ExplosiveBall()
    {
        IsExplosiveBall = true;
        OnExplosiveBall?.Invoke();
        _trailRenderer.enabled = true;
        _spriteRenderer.sprite = _explosiveSprite;

    }

    public void RestartBall()
    {
        IsStarted = false;
        _rb.velocity = Vector2.zero;
        transform.position = _startPosition;
        _transform.localScale = _minScale;
        _currentSpeed = _startSpeed;
        _pad.IsPadCatcher = false;
        MoveWithPad();
        IsExplosiveBall = false;
        _trailRenderer.enabled = false;
        _spriteRenderer.sprite = _startSprite;
    }

    public void StartMove()
    {
        _rb.velocity = _startDirection;
    }

    public void MoveWithPad()
    {
        Vector3 padPosition = _pad.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = padPosition.x;
        transform.position = currentPosition;
    }
    
    public void ChangeSpeed(float speedMultiplier)
    {
        Vector2 velocity = _rb.velocity;
        float velocityMagnitude = velocity.magnitude;
        velocityMagnitude *= speedMultiplier;

        if (velocityMagnitude < _minSpeed)
            velocityMagnitude = _minSpeed;

        _rb.velocity = velocity.normalized * velocityMagnitude;
    }

    public void Copy (Ball ball)
    {
        _startSpeed = ball._startSpeed;
        _isNewBall = true;
        IsStarted = true;
        StartMove();
    }

    public void ChangeScale(float multiplier)
    {
        Vector3 currentScale = transform.localScale;
        currentScale *= multiplier;
        
        if (currentScale.magnitude > _maxScale.magnitude)
        {
            currentScale = _maxScale;
        }

        if (currentScale.magnitude < _minScale.magnitude)
        {
            currentScale = _minScale;
        }
        
        transform.localScale = currentScale;

    }
    
    public void OnBallFall()
    {
        OnBallFell?.Invoke();
        if (_ballsHandler.BallCount == 0)
        {
            RestartBall();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private Methods
    
    private void ChangeImage()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _startDirection);

        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) _rb.velocity);
    }

    private void CalculateDirection()
    {
        Vector2 randomDirection = new Vector2(Random.Range(_xMin, _xMax), Random.Range(_yMin, _yMax));
        _startDirection = randomDirection.normalized * _startSpeed; 
    }

    private void StartBall()
    {
        IsStarted = true;
        StartMove();
    }
    
    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosiveRadius, _layerMask);

        foreach (Collider2D collider1 in colliders)
        {
            Block blockToExplode = collider1.GetComponent<Block>();
            if (blockToExplode != null)
            {
                blockToExplode.DestroyBlock();
            }
        }
    }

    #endregion
    
}
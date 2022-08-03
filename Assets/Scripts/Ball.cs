using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour

{
    #region Variables

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

    #endregion


    #region Events

    public event Action OnBallCreated;
    public event Action OnBallFell;

    #endregion
    


    #region Unity LifeCycle
    
    private void Start()
    {
        if (_isNewBall)
        {
            return;
        }
        _currentSpeed = _startSpeed;
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

    #endregion


    #region Public Methods

    public void RestartBall()
    {
        IsStarted = false;
        _rb.velocity = Vector2.zero;
        transform.position = _startPosition;

        transform.localScale = _minScale;
        _currentSpeed = _startSpeed;
        MoveWithPad();
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

    #endregion
    
}
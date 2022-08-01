using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour

{
    #region Variables

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Pad _pad;

    [SerializeField] private float _speed = 5f;
    
    [Range(-1,1)]
    [SerializeField] private float _xMin;
    
    [Range(-1,1)]
    [SerializeField] private float _xMax;
    
    [Range(0.3f,1)]
    [SerializeField] private float _yMin;
    
    [Range(0.3f,1)]
    [SerializeField] private float _yMax;

    [SerializeField] private Transform _transform;
    
    [SerializeField] private float _minSpeed = 1;
    
    
    private Vector2 _startDirection;

    private Vector2 _startPosition;
    
    private bool _isStarted;

    [SerializeField] private Ball _newBall;
    
    #endregion
    


    #region Unity LifeCycle

    private void Start()
    {
        
    }

    private void Awake()
    {
        _startPosition = transform.position;
        CalculateDirection();
  
    }

    private void Update()
    {
        if (_isStarted)
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
        _isStarted = false;
        _rb.velocity = Vector2.zero;
        transform.position = _startPosition;
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

    public void AddBall()
    {
        Instantiate(_newBall, transform.position, Quaternion.identity);
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
        _startDirection = randomDirection.normalized * _speed; 
    }
    
    private void StartBall()
    {
        _isStarted = true;
        StartMove();
    }

    #endregion


   
}
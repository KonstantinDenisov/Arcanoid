using System.Drawing;
using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    public bool IsPadCatcher;

    [SerializeField] private Vector3 _minScale = Vector3.one;
    [SerializeField] private Vector3 _maxScale;
    [SerializeField] private Ball _ball;
    private Point _contactPoint;

    #endregion


    #region Unity Lifecycle

    private void Update()
    {
        if (PauseManager.Instance.IsPaused)
            return;
        
        if (GameManager.Instance.IneedAutoPlay)
        {
            MoveWithBall();
        }
        
        else
        {
            Vector3 mousePositionInPixels = Input.mousePosition;
            Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
            Vector3 currentPosition = transform.position;
            currentPosition.x = mousePositionInUnits.x;
            transform.position = currentPosition; 
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (IsPadCatcher & col.gameObject.CompareTag(Tags.Ball))
        {
            Ball ball = col.gameObject.GetComponent<Ball>();
            ball.RestartBall();

           // _contactPoint = transform.position - col.GetContact(0).point;
           // ball.IsStarted = false;
           // ball.transform.position = _contactPoint;
        }
    }
    
    private void MoveWithBall()
    {
        Vector3 ballPositionInUnits = _ball.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = ballPositionInUnits.x;
        transform.position = currentPosition;
    }

    #endregion


    #region Public Methods

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

    #endregion
}
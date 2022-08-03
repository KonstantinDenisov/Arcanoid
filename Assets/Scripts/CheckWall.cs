using UnityEngine;
using UnityEngine.SceneManagement;

    

public class CheckWall : MonoBehaviour
{
    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Ball))
        {
            //Ball ball = col.gameObject.GetComponent<Ball>();
            //ball.OnBallFall();
            GameManager.Instance.LoseLife();
        }
        else
        {
            Destroy(col.gameObject);
        }
    }

    #endregion
}
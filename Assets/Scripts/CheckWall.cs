using UnityEngine;
using UnityEngine.SceneManagement;

    

public class CheckWall : MonoBehaviour
{
    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.Instance.LoseLife();
    }

    #endregion
}
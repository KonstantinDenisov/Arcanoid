using UnityEngine;
using UnityEngine.SceneManagement;

    public class CheckWall : SingletonMonoBehaviour<CheckWall>

//public class CheckWall : MonoBehaviour
{
    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        Statistics.Instance.Attempt++;
        Statistics.Instance.NextImage();
        SceneLoader.Instance.ReloadScene();
    }

    #endregion
}
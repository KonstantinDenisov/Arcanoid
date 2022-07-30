using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject _gameWinScreen;
    [SerializeField] private GameObject _gameOverLabel;
    [SerializeField] private GameObject _pauseImage;

    private void Awake()
    {
        _gameWinScreen.SetActive(false);
        _gameOverLabel.SetActive(false);
        _pauseImage.SetActive(false);
    }

    private void Start()
    {
        PauseManager.Instance.OnPaused += Paused;
        GameManager.Instance.OnGameOver += GameOver;
        GameManager.Instance.OnGameWinn += GameWin;
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPaused -= Paused;
        GameManager.Instance.OnGameOver -= GameOver;
        GameManager.Instance.OnGameWinn -= GameWin;
    }

    private void Paused(bool isPaused)
    {
        _pauseImage.SetActive(isPaused);
    }


    private void GameWin()
    {
        _gameWinScreen.SetActive(true);  
    }


    private void GameOver()
    { 
        _gameOverLabel.SetActive(true);
    }
        
}
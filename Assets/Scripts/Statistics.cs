using System;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : SingletonMonoBehaviour<Statistics>
{
    #region Variables

    public int Points;
    public int Attempt = 1;
    public Sprite[] HP;
    [SerializeField] private SpriteRenderer _hpSR;
    public int Iterator = 1;
    private int _hp = 3;

    #endregion


    #region Unity LifeCycle

    private void Start()
    {
        LevelManager.Instance.OnAllBlocksDestroyed += PerformWinn;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnAllBlocksDestroyed -= PerformWinn;
    }

    #endregion
    
    #region Public Methods

    public void NextImage()
    {
        _hpSR.sprite = HP[HP.Length - Iterator];
        Iterator++;
        _hp--;
        CheckGameOver();
        
    }

    #endregion


    #region Private Methods

    private void CheckGameOver()
    {
        //if (_hp ==0)
            
    }

    private void PerformWinn()
    {
        
    }

    #endregion
}
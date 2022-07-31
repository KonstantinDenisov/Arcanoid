using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class Statistics : SingletonMonoBehaviour<Statistics>
{
    #region Variables

    
    public int Points;
    public int Attempt = 1;
    // public Sprite[] HP;
   // [SerializeField] private SpriteRenderer _hpSR;
    public int Iterator = 1;
    [FormerlySerializedAs("_hp")] [SerializeField] public int HPCount = 4;

    #endregion


    #region Events

    

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
        //if (HP.Length - Iterator >=0)
          //_hpSR.sprite = HP[HP.Length - Iterator];
        Iterator++;
        HPCount--;
    }
    
    public void ChangeScore(int score)
    {
        Points += score;
    }

    #endregion


    #region Private Methods

   

    private void PerformWinn()
    {
        
    }

    #endregion
}
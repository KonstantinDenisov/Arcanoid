using System;
using UnityEngine;
public class LevelManager : SingletonMonoBehaviour<LevelManager>
    {

        #region Variables
        
        private int _blocksCount;

        #endregion
        
        #region Unity lifecycle

        private void Start()
        {
            Block[] blocks = FindObjectsOfType<Block>();
            _blocksCount = blocks.Length;

            foreach (Block block in blocks)
            {
                block.OnDestroyed += BlockDestroyed;
            }
        }

      

        #endregion


        #region Private Methods

        private void BlockDestroyed()
        {
            _blocksCount--;
            
            if (_blocksCount == 0)
            {
                SceneLoader.Instance.LoadScene(1);
            }
        }

        #endregion
    }

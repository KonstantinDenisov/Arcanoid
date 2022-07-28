using System;
using UnityEngine;
public class LevelManager : SingletonMonoBehaviour<LevelManager>
    {

        #region Variables
        
        private int _blocksCount;

        public event Action OnAllBlocksDestroyed;

        #endregion
        
        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();
            
            Block.OnDestroyed += BlockDestroyed;
            Block.OnCreated += BlockCreated;
        }

        private void OnDestroy()
        {
            Block.OnDestroyed -= BlockDestroyed;
            Block.OnCreated -= BlockCreated;
        }

        #endregion


        #region Private Methods

        private void BlockCreated(Block obj)
        {
            _blocksCount++;
        }

        private void BlockDestroyed(Block block)
        {
            _blocksCount--;
            
            if (_blocksCount == 0)
            {
                OnAllBlocksDestroyed?.Invoke();
            }
        }

        #endregion
    }

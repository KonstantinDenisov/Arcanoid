

    using UnityEngine;

    public class VFXBlock : Block
    {
        #region Protected Methods

        protected override void ApplyDamage()
        {
            Statistics.Instance.Points += _points;
            _hp--;
            if (_hp == 0)
            {
                _spriteRenderer.enabled = false; 
                GetComponent<BoxCollider2D>().enabled = false; 
                GetComponent<ParticleSystem>().Play();
            }
                
            


            if (_images.Length - Iterator >=0)
                _spriteRenderer.sprite = _images[_images.Length - Iterator];
        
            Iterator++;
            _points--;
        }

        #endregion
    }

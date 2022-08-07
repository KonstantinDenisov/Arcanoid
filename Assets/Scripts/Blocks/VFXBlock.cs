using UnityEngine;

    public class VFXBlock : Block
    {
        #region Variables

        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private BlockDestroyVFXConfig _config;
        [SerializeField] private Transform _transform;

        #endregion

        #region Protected Methods
        
        protected override void Start()
        {
            base.Start();
            SetVFXSettings();
        }

        protected override void ApplyDamage()
        {
            Statistics.Instance.Points += _points;
            _hp--;
            if (_hp == 0)
            {
                _spriteRenderer.enabled = false; 
                GetComponent<BoxCollider2D>().enabled = false; 
                _particleSystem.Play();
            }

            if (_images.Length - Iterator >=0)
                _spriteRenderer.sprite = _images[_images.Length - Iterator];
        
            Iterator++;
            _points--;
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            SpawnPickUp();
        }

        #endregion


        #region Private methods

        private void SetVFXSettings()
        {
            _particleSystem.startLifetime = _config.StartLifetime;
            _particleSystem.startSpeed = _config.StartSpeed;
            _particleSystem.maxParticles = _config.MaxParticles;
            ParticleSystem.EmissionModule particleSystemEmission = _particleSystem.emission;
            particleSystemEmission.rateOverTime = new ParticleSystem.MinMaxCurve(_config.RateOverTimeMin, _config.RateOverTimeMax);
            _particleSystem.gravityModifier = _config.GravityModifier;
            ParticleSystem.ShapeModule particleSystemShape = _particleSystem.shape;
            particleSystemShape.radius = _config.ShapeRadius;
            _particleSystem.playOnAwake = _config.PlayOnAwake;
            ParticleSystem.SizeOverLifetimeModule particleSystemSizeOverLifetime = _particleSystem.sizeOverLifetime;
            particleSystemSizeOverLifetime.separateAxes = _config.SizeOverLifetimeSeparateAxes;
            _particleSystem.startSize = _config.StartSize;
            Quaternion transformRotation = transform.rotation;
            transformRotation.y = _config.TransformRotationY;


            //_particleSystem.duration = 0.5f;
            //_particleSystem.renderer.material
            //_particleSystem.stopAction = destroy
            // ParticleSystemShapeType.Sphere;
            // Emission.rateOverTime = 0
        }

        #endregion
    }

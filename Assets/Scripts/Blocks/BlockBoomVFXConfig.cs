using UnityEngine;
[CreateAssetMenu(fileName = nameof(BlockBoomVFXConfig), menuName = "Configs/Block")]
    public class BlockBoomVFXConfig : ScriptableObject
    {
        #region Variables

        [SerializeField] private float _startLifetime = 1f;
        [SerializeField] private float _startSpeed = 100f;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private int _maxParticles = 100;
        [SerializeField] private float _rateOverTimeMin = 0f;
        [SerializeField] private float _rateOverTimeMax = 0f;
        [SerializeField] private float _gravityModifier = 0f;
        [SerializeField] private float _ShapeRadius = 0.2f;
        [SerializeField] private bool _playOnAwake = false;
        [SerializeField] private bool _sizeOverLifetimeSeparateAxes = false;
        [SerializeField] private float _startSize = 0.5f;
        [SerializeField] private int _transformRotationY = 180;
        [SerializeField] private float _multiplierscal = 0.02f;

        //_particleSystem.duration = 1f;
        //_particleSystem.renderer.material
        //_particleSystem.stopAction = destroy
        // ParticleSystemShapeType.Sphere;
        // Emission.rateOverTime = 0

        #endregion


        #region Propertis

        public float Multiplierscal
        {
            get => _multiplierscal;
        }

        public int TransformRotationY
        {
            get => _transformRotationY;
        }

        public float StartSize
        {
            get => _startSize;
        }

        public bool SizeOverLifetimeSeparateAxes
        {
            get => _sizeOverLifetimeSeparateAxes;
        }

        public float StartLifetime
        {
            get => _startLifetime;
        }

        public float StartSpeed
        {
            get => _startSpeed;
        }

        public float Duration
        {
            get => _duration;
        }

        public int MaxParticles
        {
            get => _maxParticles;
        }

        public float RateOverTimeMin
        {
            get => _rateOverTimeMin;
        }

        public float RateOverTimeMax
        {
            get => _rateOverTimeMax;
        }

        public float GravityModifier
        {
            get => _gravityModifier;
        }

        public float ShapeRadius
        {
            get => _ShapeRadius;
        }

        public bool PlayOnAwake
        {
            get => _playOnAwake;
        }

        #endregion
       
    }

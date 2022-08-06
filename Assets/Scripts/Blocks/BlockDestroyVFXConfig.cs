using UnityEngine;
[CreateAssetMenu(fileName = nameof(BlockDestroyVFXConfig), menuName = "Configs/Block")]
    public class BlockDestroyVFXConfig : ScriptableObject
    {
        #region Variables

        [SerializeField] private float _startLifetime = 1f;
        [SerializeField] private float _startSpeed = 2f;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private int _maxParticles = 10;
        [SerializeField] private float _rateOverTimeMin = 0f;
        [SerializeField] private float _rateOverTimeMax = 0f;
        [SerializeField] private float _gravityModifier = 0.5f;
        [SerializeField] private float _ShapeRadius = 0.2f;
        [SerializeField] private bool _playOnAwake = false;
        [SerializeField] private bool _sizeOverLifetimeSeparateAxes = false;
        [SerializeField] private float _startSize = 0.5f;
        [SerializeField] private int _transformRotationY = 180;

        //_particleSystem.duration = 0.5f;
        //_particleSystem.renderer.material
        //_particleSystem.stopAction = destroy
        // ParticleSystemShapeType.Sphere;
        // Emission.rateOverTime = 0

        #endregion


        #region Propertis

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

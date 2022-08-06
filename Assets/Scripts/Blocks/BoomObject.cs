using System;
using UnityEngine;
    public class BoomObject : MonoBehaviour
    {
        #region Variables

        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private BlockBoomVFXConfig _config;
        [SerializeField] private Transform _transform;

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            SetVFXSettings();
            _particleSystem.Play();
        }

        #endregion


        #region Private Methods

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
            Vector3 currentScale = _transform.localScale;
            currentScale *= _config.Multiplierscal;

            // Emission.rateOverTime = 0
        }

        #endregion

     
    }
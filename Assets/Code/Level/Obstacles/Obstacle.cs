using System;
using System.Security.Cryptography;
using Code.Level;
using EZ_Pooling;
using UnityEngine;

namespace Code.Obstackles
{
    public abstract class Obstacle : MonoBehaviour
    {
        [SerializeField] protected Transform _from;
        [SerializeField] protected Transform _to;
        [SerializeField] protected Transform _target;
        [SerializeField] protected ObstacleColliderHandler _colliderHandler;
        protected virtual void Start()
        {
            _colliderHandler.OnColliderEnter += OnCrash;
        }

        private void OnDestroy()
        {
            _colliderHandler.OnColliderEnter -= OnCrash;
        }

        protected virtual void OnCrash()
        {
            GameState.Instance.Die();
            Despawn();

        }

        protected void Despawn()
        {
            EZ_PoolManager.Despawn(transform);
        }
    }
}
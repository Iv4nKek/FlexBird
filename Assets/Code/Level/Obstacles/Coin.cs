using System;
using Code.Level;
using EZ_Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Obstackles
{
    public class Coin : Obstacle
    {
        protected override void OnCrash()
        {
            Despawn();
            GameState.Instance.CollectCoin();
            
        }
        
        protected override void Start()
        {
            base.Start();
            GameState.Instance.OnLevelStart += Despawn;
            GameState.Instance.OnDie += Despawn;
        }

        private void OnDestroy()
        {
            GameState.Instance.OnLevelStart -= Despawn;
            GameState.Instance.OnDie -= Despawn;
        }

        private void OnSpawned()
        {
            ResetPosition();
        }

        private void ResetPosition()
        {
            Vector2 positioin = Vector2.Lerp(_from.position, _to.position, Random.value);
            _target.position = positioin;
        }
    }
}
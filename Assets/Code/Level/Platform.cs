using System;
using EZ_Pooling;
using UnityEngine;

namespace Code.Level
{
    public class Platform : MonoBehaviour 
    {
        [SerializeField] private Collider2D _floorCollider;
        [SerializeField] private PlatformBanner _platformBanner;
        [SerializeField] private ObstacleSetup _obstacleSetup;
        [SerializeField] private CoinSetup _coinSetup;
        private void Enable()
        {
            _floorCollider.isTrigger = false;
            GameState.Instance.HandlePlatformActivation(this);
        }

        private void OnSpawned()
        {
            _floorCollider.isTrigger = true;
            _obstacleSetup.CreateObstacle();
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.position.y > transform.position.y)
            {
                Enable();
            }
        }
    }
}
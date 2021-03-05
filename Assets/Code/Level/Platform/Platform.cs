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

        private int _level;

        private bool _preactivated = true;

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                _platformBanner.SetLevel(_level);
                _obstacleSetup.CreateObstacle(_level);
           
                if (_level == 0)
                {
                    _floorCollider.isTrigger = false;
                }
            }
        }


        private void Enable()
        {
            _floorCollider.isTrigger = false;
            GameState.Instance.HandlePlatformActivation(this);
        }

        private void OnSpawned()
        {
            _coinSetup.CreateCoin();
            _floorCollider.isTrigger = true;
            
           
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
          
            if (other.GetComponent<Bird>() != null && other.transform.position.y < transform.position.y)
            {
                _preactivated = true;
            }
            if (other.GetComponent<Bird>() != null && other.transform.position.y > transform.position.y && _preactivated)
            {
                Enable();
                _preactivated = false;
            }
        }
    }
}
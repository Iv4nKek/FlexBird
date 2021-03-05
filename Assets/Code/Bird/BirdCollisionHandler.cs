using System;
using System.Collections.Generic;
using Code.Level;
using UnityEngine;

namespace Code
{
    public class BirdCollisionHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _platform;
        [SerializeField] private List<GameObject> _walls = new List<GameObject>();

        public event Action OnFloorCollision = delegate {  };
        public event Action OnWallCollision = delegate {  };

        private void Start()
        {
            GameState.Instance.OnPlatformActivation += ChangePlatform;
            GameState.Instance.OnLevelStart += Reset;
        }

        private void OnDestroy()
        {
            GameState.Instance.OnPlatformActivation -= ChangePlatform;
            GameState.Instance.OnLevelStart -= Reset;
        }

        private void Reset()
        {
            _platform = null;
        }

        private void ChangePlatform( Platform platform)
        {
            _platform = platform.gameObject;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == _platform || _platform == null)
            {
                OnFloorCollision();
            }

            if (_walls.Contains(other.gameObject))
            {
                OnWallCollision();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnWallCollision();
            }
        }
    }
}
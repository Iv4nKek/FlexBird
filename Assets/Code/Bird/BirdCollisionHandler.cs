using System;
using System.Collections.Generic;
using Code.Level;
using UnityEngine;

namespace Code
{
    public class BirdCollisionHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _floor;
        [SerializeField] private List<GameObject> _walls = new List<GameObject>();

        public event Action OnFloorCollision = delegate {  };
        public event Action OnWallCollision = delegate {  };

        private void Start()
        {
            GameState.Instance.OnPlatformActivation += ChangePlatform;
        }

        private void ChangePlatform( Platform platform)
        {
            _floor = platform.gameObject;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == _floor || _floor == null)
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
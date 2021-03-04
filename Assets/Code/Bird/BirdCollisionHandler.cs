using System;
using UnityEngine;

namespace Code
{
    public class BirdCollisionHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _floor;

        public event Action OnFloorCollision = delegate {  };
        public event Action OnWallCollision = delegate {  };

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == _floor)
            {
                OnFloorCollision();
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
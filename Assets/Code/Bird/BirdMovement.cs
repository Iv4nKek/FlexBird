using System;
using Code.Level;
using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMovement : MonoBehaviour
    {
        [SerializeField][Range(1,5)] private int _jumpsCount;
        [SerializeField] private float _sideSpeed;
        [SerializeField] private float _jumpPower;

        [SerializeField] private BirdController _controller;
        [SerializeField] private BirdCollisionHandler _collisionHandler;
        [SerializeField] private Rigidbody2D _rigidbody;

        private int _currentJumpCount = 0;
        private float _direction = 1;

        
        private void Start()
        {
            _controller.OnJump += TryToJump;
            _collisionHandler.OnFloorCollision += ResetJumpCount;
            GameState.Instance.OnPlatformActivation += OnPlatformActivated;
            GameState.Instance.OnLevelStart += ResetMovement;
            _collisionHandler.OnWallCollision += ChangeDirection;
        }

        private void OnDestroy()
        {
            _controller.OnJump -= TryToJump;
            _collisionHandler.OnFloorCollision -= ResetJumpCount;
            GameState.Instance.OnPlatformActivation -= OnPlatformActivated;
            GameState.Instance.OnLevelStart -= ResetMovement;
            _collisionHandler.OnWallCollision -= ChangeDirection;
        }

        public void ResetMovement()
        {
            _currentJumpCount = 0;
            _direction = 1;
            _rigidbody.velocity = new Vector2();
        }
        private void ResetJumpCount()
        {
            _currentJumpCount = 0;
        }

        private void ChangeDirection()
        {
            _direction *= -1;
        }

      

        private void OnPlatformActivated( Platform platform)
        {
            ResetJumpCount();
        }

        private void TryToJump()
        {
            if (_currentJumpCount < _jumpsCount)
            {
                Jump();
            }
        }

        private void Jump()
        {
            _rigidbody.velocity = new Vector2();
            _rigidbody.AddForce(new Vector2(0f,1f)*_jumpPower);
            _currentJumpCount++;
        }

        private void Move()
        {
            transform.Translate(new Vector3(_direction,0f,0f)*_sideSpeed * Time.deltaTime);
        }

        private void Update()
        {
            Move();
        }
    }
}
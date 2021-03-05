using System;
using Code.Level;
using UnityEngine;

namespace Code
{
    public class BirdController : MonoBehaviour
    {
        private bool _active;
        public event Action OnJump = delegate {  };

        private void Start()
        {
            GameState.Instance.OnLevelStart += Enable;
            GameState.Instance.OnDie+= Disable;
        }

        private void OnDestroy()
        {
            GameState.Instance.OnLevelStart -= Enable;
            GameState.Instance.OnDie -= Disable;
        }

        private void Enable()
        {
            _active = true;
        }
        private void Disable()
        {
            _active = false;
        }

        private void Update()
        {
            if (_active && Input.GetMouseButtonDown(0))
            {
                OnJump();
            }
        }
    }
}
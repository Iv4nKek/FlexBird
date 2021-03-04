using System;
using UnityEngine;

namespace Code.Level
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Collider2D _floorCollider;
        [SerializeField] private PlatformBanner _platformBanner;
        private void Enable()
        {
            _floorCollider.isTrigger = false;
            GameState.Instance.HandlePlatformActivation(this);
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
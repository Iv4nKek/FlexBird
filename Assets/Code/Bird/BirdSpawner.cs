using System;
using Code.Level;
using UnityEngine;

namespace Code
{
    public class BirdSpawner : MonoBehaviour
    {
        [SerializeField] private BirdMovement _bird;
        [SerializeField] private Transform _place;

        private void Start()
        {
            GameState.Instance.OnLevelStart += Respawn;
        }

        private void OnDestroy()
        {
            GameState.Instance.OnLevelStart -= Respawn;
        }

        private void Respawn()
        {
            _bird.transform.position = _place.position;
            _bird.ResetMovement();
        }
    }
}
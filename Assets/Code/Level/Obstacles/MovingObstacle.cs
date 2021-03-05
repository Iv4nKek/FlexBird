using System;
using System.Collections;
using DG.Tweening;
using EZ_Pooling;
using TMPro;
using UnityEngine;

namespace Code.Obstackles
{
    public class MovingObstacle : Obstacle
    {
        [SerializeField] private float _movingTime;
        [SerializeField] private SpriteRenderer _renderer;

        private Tween _current;
        
        private void OnSpawned()
        {
            MoveForward();
        }
        private void OnDespawned()
        {
            _current.Kill();
        }

        private void MoveForward()
        {
            _target.position = _from.position;
            _current = _target.DOMove(_to.position, _movingTime);
            _current.onComplete += MoveBackward;
            _renderer.flipX = false;
        }
        private void MoveBackward()
        {
            _target.position = _to.position;
            _current = _target.DOMove(_from.position, _movingTime);
            _current.onComplete += MoveForward;
            _renderer.flipX = true;
        }
      
   
      
    }
}
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Code.Obstackles
{
    public class HidingObstacle : Obstacle
    {
        [SerializeField] private GameObject _attention;
        [SerializeField] private float _delay;
        [SerializeField] private float _movingTime;
        [SerializeField] private DOTweenAnimation _animation;
        
        
        private void OnSpawned()
        {
            StartCoroutine(WaitForStart());
        }
        private void OnDeSpawner()
        {
            StopAllCoroutines();
        }
        
        IEnumerator WaitForStart()
        {
            ShowAttention();
            yield return new WaitForSeconds(_delay);
            StartActivity();
            HideAttention();
        }
        
        IEnumerator WaitAfterEnd()
        {
            yield return new WaitForSeconds(_delay);
            StartCoroutine(WaitForStart());
        }
        
        private void ShowAttention()
        {
            _attention.SetActive(true);
            _animation.DOPlay();
        }

        private void HideAttention()
        {
            _attention.SetActive(false);
        }

        private void StartActivity()
        {
            _target.position = _from.position;
            _target.DOMove(_to.position, _movingTime).onComplete+= OnMovingEnded;
        }

        private void OnMovingEnded()
        {
            if(gameObject.activeInHierarchy)
                StartCoroutine(WaitAfterEnd());
        }
    }
}
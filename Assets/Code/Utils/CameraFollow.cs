using System;
using Code.Level;
using UnityEngine;

namespace Code
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _lerp;
        [SerializeField] private Transform _target;

        private float _offset;
        private float _defaultHeight;

        private void Start()
        {
            _defaultHeight = transform.position.y;
            _offset = _target.position.y - transform.position.y;
            GameState.Instance.OnLevelStart += Reset;
        }

        private void Reset()
        {
            transform.position = new Vector3(0f, _defaultHeight, transform.position.z);
        }

        private void Update()
        {
            if (_target != null)
            {
                float height = Mathf.Lerp(transform.position.y, _target.position.y - _offset, _lerp * Time.deltaTime);
                transform.position = new Vector3(0f, height, -10f);
            }
        }
    }
}
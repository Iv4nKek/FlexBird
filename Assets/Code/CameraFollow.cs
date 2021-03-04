using System;
using UnityEngine;

namespace Code
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _lerp;
        [SerializeField] private Transform _target;

        private float _offset;

        private void Start()
        {
            _offset = _target.position.y - transform.position.y;
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
using UnityEngine;

namespace Code
{
    public class WallColliderCreator : MonoBehaviour
    {
        [SerializeField] private float _colDepth = 4f;
        [SerializeField] private float _zPosition = 0f;
        [SerializeField] private float _topPadding;
        [SerializeField] private float _botPadding;
        [SerializeField] private float _padding;
        
        private Vector2 _screenSize;
        [SerializeField]private Transform _leftCollider;
        [SerializeField]private Transform _rightCollider;

        private Vector3 _cameraPos;

        private void Start()
        {
            var camera = Camera.main;
            _cameraPos = Camera.main.transform.position;
            _screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)),
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -10))) * 0.5f;
            _screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)),
                Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height - _padding, -10))) * 0.5f;

            _rightCollider.localScale = new Vector3(_colDepth, _screenSize.y * 2, _colDepth);
            _rightCollider.position = new Vector3(_cameraPos.x + _screenSize.x + _rightCollider.localScale.x * 0.5f,
                _cameraPos.y, _zPosition);
            _leftCollider.localScale = new Vector3(_colDepth, _screenSize.y * 2, _colDepth);
            _leftCollider.position = new Vector3(_cameraPos.x - _screenSize.x - _leftCollider.localScale.x * 0.5f,
                _cameraPos.y, _zPosition);
        }
    }
}
using EZ_Pooling;
using UnityEngine;

namespace Code.Level
{
    public class CoinSetup : MonoBehaviour
    {
        [SerializeField][Range(0,1)] private float _chance;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Transform _parent;
        
        private Transform _createdCoin;
        public void CreateCoin()
        {
            CheckCoin();
            if (Random.value < _chance)
            {
                Vector3 presetPosition = _coinPrefab.transform.position;
                Vector3 position = presetPosition + _parent.transform.position;
                _createdCoin = EZ_PoolManager.Spawn(_coinPrefab.transform,position,new Quaternion());
                _createdCoin.parent = _parent;
                _createdCoin.transform.localPosition = presetPosition;
            }
        }
        private void CheckCoin()
        {
            if (_createdCoin != null)
            {
                EZ_PoolManager.Despawn(_createdCoin);
            }
        }
    }
}
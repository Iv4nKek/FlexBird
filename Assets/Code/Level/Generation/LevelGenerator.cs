using System;
using EZ_Pooling;
using UnityEngine;

namespace Code.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _platformPrefab;
        [SerializeField] private Transform _spawnStrt;
        [SerializeField] private int _generationLimit;
        [SerializeField] private float _height;
        private float _currentHeight;

        private void Start()
        {
            GameState.Instance.OnPlatformActivation += OnPlatformActivation;
            _currentHeight = _spawnStrt.position.y;
            GeneratePlatforms(_generationLimit);
            
        }

        private void OnPlatformActivation(Platform platform) => GeneratePlatform();
        private void GeneratePlatform()
        {
            EZ_PoolManager.Spawn(_platformPrefab.transform, new Vector3(0f, _currentHeight, 0f), new Quaternion());
            _currentHeight += _height;
        }

        private void GeneratePlatforms(int index)
        {
            for (int i = 0; i < index; i++)
            {
                GeneratePlatform();
            }
        }
    }
}
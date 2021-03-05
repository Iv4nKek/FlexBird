using System;
using System.Collections.Generic;
using EZ_Pooling;
using UnityEngine;

namespace Code.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _platformPrefab;
        [SerializeField] private Transform _spawnStart;
        [SerializeField] private int _startAmount;
        [SerializeField] private int _generationLimit;
        [SerializeField] private float _height;
        
        private float _currentHeight;
        private Queue<Transform> _platforms = new Queue<Transform>();
        private int _count;
        private int _level;

        private void Start()
        {
            GameState.Instance.OnPlatformActivation += OnPlatformActivation;
            GameState.Instance.OnDie += DeleteAll;
            GameState.Instance.OnLevelStart += CreateStartPlatforms;
        }

        private void OnDestroy()
        {
            GameState.Instance.OnPlatformActivation -= OnPlatformActivation;
            GameState.Instance.OnDie -= DeleteAll;
            GameState.Instance.OnLevelStart -= CreateStartPlatforms;
        }

        private void CreateStartPlatforms()
        {
            _level = 0;
            _currentHeight = _spawnStart.position.y;
            GeneratePlatforms(_startAmount);
        }

        private void DeleteAll()
        {
            foreach (var platform in _platforms)
            {
                EZ_PoolManager.Despawn(platform);
            }
        }

        private void OnPlatformActivation(Platform platform) => GeneratePlatform();
        private void GeneratePlatform()
        {
            Transform platform = EZ_PoolManager.Spawn(_platformPrefab.transform, new Vector3(0f, _currentHeight, 0f), new Quaternion());
            platform.GetComponent<Platform>().Level = _level;
            _level++;
            _platforms.Enqueue(platform);
            _count++;
            _currentHeight += _height;
            if (_count > _generationLimit)
            {
                DeleteFirst();
            }
        }

        private void DeleteFirst()
        {
            Transform platform = _platforms.Dequeue();
            EZ_PoolManager.Despawn(platform);
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
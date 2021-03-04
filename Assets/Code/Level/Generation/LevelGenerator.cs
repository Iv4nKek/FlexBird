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
        private int count;

        private void Start()
        {
            GameState.Instance.OnPlatformActivation += OnPlatformActivation;
            _currentHeight = _spawnStart.position.y;
            GeneratePlatforms(_startAmount);
            
        }

        private void OnPlatformActivation(Platform platform) => GeneratePlatform();
        private void GeneratePlatform()
        {
            Transform platform = EZ_PoolManager.Spawn(_platformPrefab.transform, new Vector3(0f, _currentHeight, 0f), new Quaternion());
            _platforms.Enqueue(platform);
            count++;
            _currentHeight += _height;
            if (count > _generationLimit)
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
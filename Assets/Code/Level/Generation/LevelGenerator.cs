using System;
using UnityEngine;

namespace Code.Level
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _platformPrefab;
        [SerializeField] private int _generationLimit;
        [SerializeField] private float _height;
        private float _currentHeight;

        private void Awake()
        {
            
        }

        private void GeneratePlatform()
        {
            
        }
    }
}
using System;
using UnityEngine;

namespace Code.Level
{
    public class GameState : MonoBehaviour
    {
        private int _currentLevel;
        private int _currentMoney;

        public event Action<Platform> OnPlatformActivation;
        
        
        
        
        private static GameState _instance;
        public static GameState Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void HandlePlatformActivation(Platform platform)
        {
            _currentLevel++;
        }
        
    }
}
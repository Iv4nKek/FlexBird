using System;
using Code.Obstackles;
using UnityEngine;

namespace Code.Level
{
    public class GameState : MonoBehaviour
    {
        private int _currentLevel;
        private int _currentMoney;

        public static int CurrentLevel => _instance._currentLevel;

        public int CurrentMoney => _currentMoney;

        public event Action<Platform> OnPlatformActivation = delegate(Platform platform) {  };
        public event Action<Obstacle> OnObstacleCrush = delegate(Obstacle obstacle) {  };
        
        
        
        
        private static GameState _instance;
        public static GameState Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

        public void HandlePlatformActivation(Platform platform)
        {
            _currentLevel++;
            OnPlatformActivation(platform);
        }
        public void HandleObstacleCrush(Obstacle obstacle)
        {
            OnObstacleCrush(obstacle);
        }
        
        
    }
}
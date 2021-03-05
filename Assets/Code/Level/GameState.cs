using System;
using Code.Obstackles;
using EZ_Pooling;
using UnityEngine;

namespace Code.Level
{
    public class GameState : MonoBehaviour
    {
        private int _currentLevel;
        private int _maxLevel;
        
        private int _currentMoney;
        private int _totalMoney;

        public int MaxLevel => _maxLevel;

        public int TotalMoney => _totalMoney;

        public int CurrentLevel => _currentLevel;

        public int CurrentMoney => _currentMoney;

        public event Action<Platform> OnPlatformActivation = delegate(Platform platform) {  };
        public event Action<Obstacle> OnObstacleCrush = delegate(Obstacle obstacle) {  };
        public event Action OnCoinCollected = delegate {  };
        public event Action OnDie = delegate {  };
        public event Action OnLevelStart = delegate {  };

        
        public void CollectCoin()
        {
            _currentMoney++;
            _totalMoney++;
            PlayerPrefs.SetInt("Money",_totalMoney);
            PlayerPrefs.Save();
            OnCoinCollected();
        }

        public void Die()
        {
            _currentLevel = 0;
            _currentMoney = 0;
            OnDie();
        }
        public void StartLevel()
        {
            _totalMoney = PlayerPrefs.GetInt("Money");
            _maxLevel = PlayerPrefs.GetInt("MaxLevel");
            OnLevelStart();
        }
        
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
            if (_currentLevel > _maxLevel)
            {
                _maxLevel = _currentLevel;
                PlayerPrefs.SetInt("MaxLevel",_maxLevel);
                PlayerPrefs.Save();
            }
            
            OnPlatformActivation(platform);
        }
        public void HandleObstacleCrush(Obstacle obstacle)
        {
            OnObstacleCrush(obstacle);
        }
        
        
    }
}
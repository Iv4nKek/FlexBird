using System;
using Code.Level;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _current;
        [SerializeField] private TMP_Text _best;
        private void Start()
        {
            GameState.Instance.OnLevelStart += UpdateBest;
            GameState.Instance.OnLevelStart += UpdateCurrent;
            GameState.Instance.OnPlatformActivation += OnLevelUp;
        }

        private void OnDestroy()
        {
            GameState.Instance.OnLevelStart -= UpdateBest;
            GameState.Instance.OnLevelStart -= UpdateCurrent;
            GameState.Instance.OnPlatformActivation -= OnLevelUp;
        }

        private void OnLevelUp(Platform platform)
        {
            UpdateCurrent();
            UpdateBest();
        }
        private void UpdateCurrent()
        {
            int current = GameState.Instance.CurrentLevel;
            _current.text = current.ToString();
        }

        private void UpdateBest()
        {
            int bestLevel = GameState.Instance.MaxLevel;
            _best.text = bestLevel.ToString();
        }
    }
}
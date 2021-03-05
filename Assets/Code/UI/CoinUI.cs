using System;
using Code.Level;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _current;
        [SerializeField] private TMP_Text _total;
        private void Start()
        {
            GameState.Instance.OnLevelStart += UpdateTotal;
            GameState.Instance.OnLevelStart += UpdateCurrent;
            GameState.Instance.OnCoinCollected += UpdateCurrent;
            GameState.Instance.OnCoinCollected += UpdateTotal;
        }

        private void OnDestroy()
        {
            GameState.Instance.OnLevelStart -= UpdateTotal;
            GameState.Instance.OnLevelStart -= UpdateCurrent;
            GameState.Instance.OnCoinCollected -= UpdateCurrent;
            GameState.Instance.OnCoinCollected -= UpdateTotal;
        }

        private void UpdateCurrent()
        {
            int current = GameState.Instance.CurrentMoney;
            _current.text = current.ToString();
        }

        private void UpdateTotal()
        {
            int totalMoney = GameState.Instance.TotalMoney;
            _total.text = totalMoney.ToString();
        }
    }
}
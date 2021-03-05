using System;
using Code.Level;
using UnityEngine;

namespace Code.UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private GameObject _DiedLabel;
        
        private bool _active = true;
        private void Start()
        {
            GameState.Instance.OnDie += ShowMenu;
            Time.timeScale = 0f;
        }

        private void ShowMenu()
        {
            Time.timeScale = 0f;
            _menu.SetActive(true);
            _active = true;
            _DiedLabel.SetActive(true);
        }

        public void CloseMenu()
        {
            if (_active)
            {
                Time.timeScale = 1f;
                _menu.SetActive(false);
                _active = false;
                GameState.Instance.StartLevel();
            }
            
        }
    }
}
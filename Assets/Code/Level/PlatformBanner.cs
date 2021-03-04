using TMPro;
using UnityEngine;

namespace Code.Level
{
    public class PlatformBanner : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLevel;
        [SerializeField] private Transform _record;
        [SerializeField] private Transform _lastScore;
    }
}
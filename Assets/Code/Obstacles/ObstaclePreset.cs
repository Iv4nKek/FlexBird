using System;
using Code.Level;
using UnityEngine;

namespace Code.Obstackles
{
    [Serializable]
    public class ObstaclePreset
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private AnimationCurve _probabilityPerLevel;

        public GameObject Prefab => _prefab;

        public AnimationCurve ProbabilityPerLevel => _probabilityPerLevel;
    }
} 
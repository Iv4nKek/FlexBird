using System.Collections.Generic;
using UnityEngine;

namespace Code.Obstackles
{
    [CreateAssetMenu]
    public class ObstacleContainer : ScriptableObject
    {
        [SerializeField] private List<ObstaclePreset> _obstacles;
        [SerializeField] private AnimationCurve _createProbability;


        public bool ShouldBeSpawned(int level)
        {
            return Random.value < _createProbability.Evaluate(level);
        }
        public ObstaclePreset GetRandomObstacle(int level)
        {
            ObstaclePreset result = null;
            float totalProbability = 0;
            Dictionary<ObstaclePreset, float> probabilities = new Dictionary<ObstaclePreset, float>();
            
            foreach (ObstaclePreset obstacle in _obstacles)
            {
                probabilities.Add(obstacle,totalProbability);
                totalProbability += obstacle.ProbabilityPerLevel.Evaluate(level);
                
            }
            
            float random = Random.Range(0, totalProbability);
            
            foreach (var probability in probabilities)
            {
                if (probability.Value < random)
                {
                    result = probability.Key;
                }
               
            }

            return result;
        }
    }
}
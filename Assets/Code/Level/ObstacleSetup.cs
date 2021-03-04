using Code.Obstackles;
using UnityEngine;

namespace Code.Level
{
    public class ObstacleSetup : MonoBehaviour
    {
        [SerializeField] private ObstacleContainer _container;

        public void CreateObstacle()
        {
            int level = GameState.CurrentLevel;
            ObstaclePreset preset = _container.GetRandomObstacle(level);
            if (preset != null)
            {
                GameObject createdObstacle = Instantiate(preset.Prefab, transform);
                Obstacle obstacle = createdObstacle.GetComponent<Obstacle>();
            }
        }
    }
}
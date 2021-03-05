using Code.Obstackles;
using EZ_Pooling;
using UnityEngine;

namespace Code.Level
{
    public class ObstacleSetup : MonoBehaviour
    {
        [SerializeField] private ObstacleContainer _container;
        [SerializeField] private Transform _parent;
        
        private Transform _createdObstacle;
        
        public void CreateObstacle( int level)
        {
            CheckObstacle();
            if (level>0 && _container.ShouldBeSpawned(level))
            {
                ObstaclePreset preset = _container.GetRandomObstacle(level);
                if (preset != null)
                {
                    Vector3 presetPosition = preset.Prefab.transform.position;
                    Vector3 position = presetPosition + _parent.transform.position;
                    _createdObstacle = EZ_PoolManager.Spawn(preset.Prefab.transform,position,new Quaternion());
                    _createdObstacle.parent = _parent;
                    _createdObstacle.transform.localPosition = presetPosition;
                }
            }
           
        }

        private void CheckObstacle()
        {
            if (_createdObstacle != null)
            {
                EZ_PoolManager.Despawn(_createdObstacle);
            }
        }
    }
}
using Code.Obstackles;
using EZ_Pooling;
using UnityEngine;

namespace Code.Level
{
    public class ObstacleSetup : MonoBehaviour
    {
        [SerializeField] private ObstacleContainer _container;
        [SerializeField] private Transform _parent;
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        private Transform _createdObstacle;
        public void CreateObstacle()
        {
            CheckObstacle();
            int level = GameState.CurrentLevel;
            if (_container.ShouldBeSpawned(level))
            {
                ObstaclePreset preset = _container.GetRandomObstacle(level);
                if (preset != null)
                {
                    _createdObstacle = EZ_PoolManager.Spawn(preset.Prefab.transform,new Vector3(),new Quaternion());
                    _createdObstacle.parent = _parent;
                    _createdObstacle.transform.position = preset.Prefab.transform.position;
                  //  var position = preset.Prefab.transform.position;
                   // position = new Vector3(0f, 0f, position.z);
                    _createdObstacle.transform.localPosition = preset.Prefab.transform.position;

                   
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
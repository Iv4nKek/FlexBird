using UnityEngine;

namespace Code.Obstackles
{
    public class FixedObstacle : Obstacle 
    {

        private void OnSpawned()
        {
            ResetPosition();
        }

        private void ResetPosition()
        {
            Vector2 positioin = Vector2.Lerp(_from.position, _to.position, Random.value);
            _target.position = positioin;
        }
    }
}
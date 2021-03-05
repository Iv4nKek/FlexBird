using System;
using UnityEngine;

namespace Code.Obstackles
{
    public class ObstacleColliderHandler : MonoBehaviour
    {
        public event Action OnColliderEnter  = delegate {  };

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.GetComponent<Bird>() != null)
                OnColliderEnter();
            
        }

       
    }
}
using System;
using UnityEngine;

namespace Code
{
    public class BirdController : MonoBehaviour
    {

        public event Action OnJump = delegate {  };

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnJump();
            }
        }
    }
}
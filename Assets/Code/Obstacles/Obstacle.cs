using UnityEngine;

namespace Code.Obstackles
{
    public abstract class Obstacle : MonoBehaviour
    {
        [SerializeField] protected Transform _from;
        [SerializeField] protected Transform _to;
        [SerializeField] protected Transform _target;
    }
}
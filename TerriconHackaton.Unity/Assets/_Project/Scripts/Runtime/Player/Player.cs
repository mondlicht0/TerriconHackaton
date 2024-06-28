using UnityEngine;

namespace Project.Player
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public Transform FollowTarget { get; private set; }
        [field: SerializeField] public Transform LookAtTarget { get; private set; }
    }
}
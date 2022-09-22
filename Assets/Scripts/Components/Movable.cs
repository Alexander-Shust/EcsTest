using UnityEngine;

namespace Components
{
    public struct Movable
    {
        public Transform Transform;
        public Vector3 Position;
        public Vector3 Destination;
        public float MoveSpeed;
    }
}
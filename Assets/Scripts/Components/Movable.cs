using UnityEngine;

namespace Components
{
    public struct Movable
    {
        public bool IsFrozen;
        public Transform Transform;
        public Vector3 Position;
        public Vector3 Destination;
        public Quaternion Rotation;
        public float MoveSpeed;
        public float RotateSpeed;
    }
}
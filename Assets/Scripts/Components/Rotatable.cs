using UnityEngine;

namespace Components
{
    public struct Rotatable
    {
        public Transform Transform;
        public Quaternion Rotation;
        public Quaternion TargetRotation;
        public float RotateSpeed;
    }
}
using UnityEngine;

namespace Components
{
    public struct Rotatable
    {
        public Quaternion Rotation;
        public Quaternion TargetRotation;
        public float RotateSpeed;
    }
}
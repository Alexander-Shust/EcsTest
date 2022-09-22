using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]
    private int _id;

    private CapsuleCollider _collider;

    public int Id => _id;
    public Vector3 Center => _collider.bounds.center;
    public float Radius => _collider.bounds.extents.x;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
    }
}
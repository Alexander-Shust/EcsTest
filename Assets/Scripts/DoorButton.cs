using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]
    private int _id;

    private CapsuleCollider _collider;

    public int Id => _id;

    public Vector3 Center => _collider.transform.position;
    public float Radius => _collider.radius;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
    }
}
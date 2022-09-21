using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private int _id;

    [SerializeField]
    private Transform _target;

    public int Id => _id;

    public Vector3 Target => _target.position;

    private void Awake()
    {
        if (_target == null)
        {
            _target = transform;
        }
    }
}
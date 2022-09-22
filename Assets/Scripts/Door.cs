using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private int _id;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _openTime = 5.0f;

    public int Id => _id;

    public Transform Target => _target;

    public float OpenTime => _openTime;

    private void Awake()
    {
        if (_target == null)
        {
            _target = transform;
        }
    }
}
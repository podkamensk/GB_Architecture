using System;
using UnityEngine;

    public sealed class EnemyProvider : MonoBehaviour, IEnemy
    {
        public event Action<int> OnTriggerEnterChange;
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;

    public Vector3 Coordinates => throw new NotImplementedException(); // TO be fixed

    public Transform Transform => throw new NotImplementedException(); //

    public float Mass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    Vector3 IUnit.Coordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    Transform IUnit.Transform { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public GameObject GameObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
        }

        public void Move(Vector3 point)
        {
            if ((_transform.localPosition - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - _transform.localPosition).normalized;
                _rigidbody2D.velocity = dir * _speed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID());
        }

    public void Execute(float deltaTime)
    {
        throw new NotImplementedException();
    }
}


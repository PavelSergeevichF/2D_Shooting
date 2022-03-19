using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;

    [Header("Settings")]
    [SerializeField] private float _walkSpeed = 1;
    [SerializeField] private float _animationsSpeed = 3;
    [SerializeField] private float _jampStartSpeed = 2;
    [SerializeField] private float _movingTresh = 0.1f;
    [SerializeField] private float _flyTresh = 0.3f;
    [SerializeField] private float _groundLevel = 0.1f;
    [SerializeField] private float _acceleration = -10f;
    [SerializeField] private bool _isDownButtonJamp;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public float PowerOfMovement => _walkSpeed; //PowerOfMovement
    public float AnimationsSpeed => _animationsSpeed;
    public float JampStartSpeed => _jampStartSpeed;
    public float MovingTresh => _movingTresh;
    public float FlyTresh => _flyTresh;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigidbody => _rigidbody;
}

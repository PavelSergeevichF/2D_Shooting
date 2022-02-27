using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [Header("Settings")]
    [SerializeField] private float _walkSpeed =1;
    [SerializeField] private float _animationsSpeed = 3;
    [SerializeField] private float _jampStartSpeed = 2;
    [SerializeField] private float _movingTresh = 0.1f;
    [SerializeField] private float _flyTresh = 0.3f;
    [SerializeField] private float _groundLevel = 0.1f;
    [SerializeField] private float _acceleration = -10f;
    [SerializeField] private bool  _isDownButtonJamp;
    public SpriteRenderer SpriteRenderer  => _spriteRenderer;

    public float WalkSpeed { get => _walkSpeed; }
    public float AnimationsSpeed { get => _animationsSpeed; }
    public float JampStartSpeed { get => _jampStartSpeed;  }
    public float MovingTresh { get => _movingTresh;  }
    public float FlyTresh { get => _flyTresh; }
    public float GroundLevel { get => _groundLevel;  }
    public float Acceleration { get => _acceleration; }
}
 
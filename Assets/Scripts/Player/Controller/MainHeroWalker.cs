using UnityEngine;

public class MainHeroWalker
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private float _yVelocity;
    private PlayerView _playerView;
    private SpriteAnimator _spriteAnimator;

    public MainHeroWalker(PlayerView playerView,SpriteAnimator spriteAnimator)
    {
        _playerView = playerView;
        _spriteAnimator = spriteAnimator;
    }
    public void Update()
    {
        var doJump = Input.GetAxis(Vertical) > 0;
        var xAxisInput = Input.GetAxis(Horizontal);

        var isGoSideWay = Mathf.Abs(xAxisInput) > _playerView.MovingTresh;
        if(isGoSideWay)
        {
            GoSideWay(xAxisInput);
        }
        if(IsGrounded())
        {
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, isGoSideWay ? Track.run : Track.idle, true, _playerView.AnimationsSpeed);
            if(doJump && Mathf.Approximately(_yVelocity, 0))
            {
                _yVelocity = _playerView.JampStartSpeed;
            }
            else if(_yVelocity<0)
            {
                _yVelocity = 0;
                MovementCharacter();
            }
            else 
            {
                _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.idle, true, _playerView.AnimationsSpeed);
            }
        }
        else
        {
            LandingCharater();
        }
    }

    private void LandingCharater()
    {
        _yVelocity += _playerView.Acceleration * Time.deltaTime;

        if (Mathf.Abs(_yVelocity) > _playerView.FlyTresh)
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.jump, true, _playerView.AnimationsSpeed);
        _playerView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
    }
    private void MovementCharacter()
    {
        _playerView.transform.position = _playerView.transform.position.Change(y: _playerView.GroundLevel);
    }
    private bool IsGrounded()
    {
        return _playerView.transform.position.y<= _playerView.GroundLevel;
    }
    private void GoSideWay(float xAxisInput)
    {
        Vector3 tmp= Vector3.right * (Time.deltaTime * _playerView.WalkSpeed * xAxisInput < 0 ? -1 : 1);
        Debug.Log($"position= {tmp} deltaTime {Time.deltaTime} WalkSpeed {_playerView.WalkSpeed} Vector3.right {Vector3.right}");
        _playerView.transform.position += tmp;
        tmp = _playerView.transform.position;
        if (_playerView.transform.position.x < -16.5f) { tmp.x = -16.5f; _playerView.transform.position = tmp;  }
        if (_playerView.transform.position.x > 24.5f) { tmp.x = 24.5f; _playerView.transform.position = tmp; }
        if (_playerView.transform.position.y < -4.0f) { tmp.y = -4.0f; _playerView.transform.position = tmp; }
        if (_playerView.transform.position.y > 6f) { tmp.y = 6f; _playerView.transform.position = tmp; }
        _playerView.SpriteRenderer.flipX = xAxisInput > 0;
    }
}

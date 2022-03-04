using UnityEngine;

public class MainHeroWalker
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const float _BorderLeft = -16.5f;
    private const float _BorderRight = 24.5f;
    private const float _BorderTop = 6.0f;
    private const float _BorderDowne = -4.0f;

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
            if (isGoSideWay)  StartAnimation(Track.run, 3); 
            else StartAnimation(Track.idle, 1); 
            if(doJump && Mathf.Approximately(_yVelocity, 0))
            {
                _yVelocity = _playerView.JampStartSpeed;
            }
            else if(_yVelocity<0)
            {
                _yVelocity = 0;
                MovementCharacter();
            }
        }
        else
        {
            LandingCharater();
        }
    }
    private void StartAnimation(Track track, float cof)
    {
        _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, track, true, _playerView.AnimationsSpeed* cof);
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
        Vector3 offsetPosition = Vector3.right * (Time.deltaTime * _playerView.PowerOfMovement * (xAxisInput < 0 ? -1 : 1));
        _playerView.transform.position += offsetPosition;
        offsetPosition = _playerView.transform.position;
        if (_playerView.transform.position.x < _BorderLeft) { offsetPosition.x = _BorderLeft; _playerView.transform.position = offsetPosition;  }
        if (_playerView.transform.position.x > _BorderRight) { offsetPosition.x = _BorderRight; _playerView.transform.position = offsetPosition; }
        if (_playerView.transform.position.y < -_BorderDowne) { offsetPosition.y = -_BorderDowne; _playerView.transform.position = offsetPosition; }
        if (_playerView.transform.position.y > _BorderTop) { offsetPosition.y = _BorderTop; _playerView.transform.position = offsetPosition; }
        _playerView.SpriteRenderer.flipX = xAxisInput > 0;
    }
}

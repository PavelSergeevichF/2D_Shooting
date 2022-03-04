using UnityEngine;

public class MainHeroPhysicWalker
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const float _BorderLeft = -16.5f;
    private const float _BorderRight = 24.5f;
    private const float _BorderTop = 6.0f;
    private const float _BorderDowne = -4.0f;

    private ContactsPoler _contactsPoler;
    private PlayerView _playerView;
    private SpriteAnimator _spriteAnimator;

    public MainHeroPhysicWalker(PlayerView playerView, SpriteAnimator spriteAnimator)
    {
        _playerView = playerView;
        _spriteAnimator = spriteAnimator;

        _contactsPoler = new ContactsPoler(_playerView.Collider);
    }
    public void FixedUpdate()
    {
        var doJump = Input.GetAxis(Vertical) > 0;
        var xAxisInput = Input.GetAxis(Horizontal);

        _contactsPoler.Update();

        var isGoSideWay = Mathf.Abs(xAxisInput) > _playerView.MovingTresh;
        if(isGoSideWay)
            _playerView.SpriteRenderer.flipX = xAxisInput > 0;

        var newVelocity = 0f;

        if(isGoSideWay &&
            (xAxisInput>0 || !_contactsPoler.hasLeftContacts) &&
            (xAxisInput<0 || !_contactsPoler.hasRightContacts)
            )
        {
            newVelocity = Time.fixedDeltaTime * _playerView.PowerOfMovement * (xAxisInput < 0 ? -1 : 1);
        }
        _playerView.Rigidbody.velocity = _playerView.Rigidbody.velocity.Change(x: newVelocity);
        if (_contactsPoler.isGrrounded && doJump && Mathf.Abs(_playerView.Rigidbody.velocity.y) <= _playerView.FlyTresh)
            _playerView.Rigidbody.AddForce(Vector2.up * _playerView.JampStartSpeed);
        _playerView.Rigidbody.position = FrameBorder(_playerView.Rigidbody.position);
        #region animation
        if (_contactsPoler.isGrrounded)
        {
            if(Mathf.Abs(newVelocity) > 0 || Mathf.Abs(newVelocity) < 0) StartAnimation(Track.run, 3);
            else StartAnimation(Track.idle, 1);
        }
        else if(Mathf.Abs(_playerView.Rigidbody.velocity.y)>_playerView.FlyTresh)
        {
            StartAnimation(Track.jump, 1);
        }
        #endregion
    }
    private void StartAnimation(Track track, float cof)
    {
        _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, track, true, _playerView.AnimationsSpeed * cof);
    }
    private Vector3 FrameBorder(Vector3 pos)
    {
        if (pos.x < _BorderLeft)   pos.x = _BorderLeft; 
        if (pos.x > _BorderRight)  pos.x = _BorderRight; 
        if (pos.y > _BorderTop)    pos.y = _BorderTop; 
        if (pos.y < _BorderDowne)  pos.y = _BorderDowne;
        return pos;
    }
}

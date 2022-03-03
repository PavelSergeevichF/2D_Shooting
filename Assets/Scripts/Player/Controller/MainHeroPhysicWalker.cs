using UnityEngine;

public class MainHeroPhysicWalker
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

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
        {
            _playerView.SpriteRenderer.flipX = xAxisInput > 0;
        }

        var newVelocity = 0f;

        if(isGoSideWay &&
            (xAxisInput>0 || !_contactsPoler.hasLeftContacts) &&
            (xAxisInput<0 || !_contactsPoler.hasRightContacts)
            )
        {
            newVelocity = Time.fixedDeltaTime * _playerView.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
            //Vector3 tmp = Vector3.right * (Time.deltaTime * _playerView.WalkSpeed * (xAxisInput < 0 ? -1 : 1));
            //_playerView.transform.position += tmp;
            //tmp = _playerView.transform.position;
            //if (_playerView.transform.position.x < -16.5f) { tmp.x = -16.5f; _playerView.transform.position = tmp; }
            //if (_playerView.transform.position.x > 24.5f) { tmp.x = 24.5f; _playerView.transform.position = tmp; }
            //if (_playerView.transform.position.y < -4.0f) { tmp.y = -4.0f; _playerView.transform.position = tmp; }
            //if (_playerView.transform.position.y > 6f) { tmp.y = 6f; _playerView.transform.position = tmp; }
        }
        _playerView.Rigidbody.velocity = _playerView.Rigidbody.velocity.Change(x: newVelocity);
        if (_contactsPoler.isGrrounded && doJump && Mathf.Abs(_playerView.Rigidbody.velocity.y) <= _playerView.FlyTresh)
        {
            _playerView.Rigidbody.AddForce(Vector2.up * _playerView.JampStartSpeed);
        }
        #region animation
        if (_contactsPoler.isGrrounded)
        {
            if(Mathf.Abs(newVelocity) > 0 || Mathf.Abs(newVelocity) < 0) Animation(Track.run, 3);
            else Animation(Track.idle, 1);
        }
        else if(Mathf.Abs(_playerView.Rigidbody.velocity.y)>_playerView.FlyTresh)
        {
            Animation(Track.jump, 1);
        }
        #endregion
    }
    private void Animation(Track track, float cof)
    {
        _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, track, true, _playerView.AnimationsSpeed * cof);
    }
}

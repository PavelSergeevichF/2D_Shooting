using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private SpriteRenderer _beckground;
    [SerializeField]
    private PlayerView _playerView;
    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    [SerializeField]
    private SpriteAnimationConfig _spriteAnimationConfig;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _beckground.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.idle, true, 10);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
    }
    private void FixedUpdate()
    {
        
    }
    private void OnDestroy()
    {
        
    }
}

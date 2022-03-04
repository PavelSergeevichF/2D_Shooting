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
    private CameraManager _cameraManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroPhysicWalker _mainHeroPhysicWalker;
    [SerializeField]
    private SpriteAnimationConfig _spriteAnimationConfig;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _beckground.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroPhysicWalker = new MainHeroPhysicWalker(_playerView, _spriteAnimator);
        _cameraManager = new CameraManager(_camera, _playerView.transform);
        _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.idle, true, 5);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _cameraManager.Update();
    }
    private void FixedUpdate()
    {
        _mainHeroPhysicWalker.FixedUpdate();
    }
    private void OnDestroy()
    {
        
    }
}

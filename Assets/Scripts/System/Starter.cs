using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private SpriteRenderer _beckground;
    [SerializeField]
    private PlayerView _playerView;
    [SerializeField]
    private EnemyView _enemyView;
    [SerializeField]
    private AiConfig _config;

    private ParalaxManager _paralaxManager;
    private CameraManager _cameraManager;
    private SpriteAnimator _playerSpriteAnimator;
    private SpriteAnimator _enemySpriteAnimator;
    private MainHeroPhysicWalker _mainHeroPhysicWalker;
    [SerializeField]
    private SpriteAnimationConfig _spriteAnimationConfig;
    private SimplePatrolAi _simplePatrolAi;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _beckground.transform);
        _playerSpriteAnimator = new SpriteAnimator(_spriteAnimationConfig, CharacterTipy.Player);
        _enemySpriteAnimator = new SpriteAnimator(_spriteAnimationConfig, CharacterTipy.FlyingBeetle);
        _mainHeroPhysicWalker = new MainHeroPhysicWalker(_playerView, _playerSpriteAnimator);
        _cameraManager = new CameraManager(_camera, _playerView.transform);
        _playerSpriteAnimator.StartAnimation(_playerView.SpriteRenderer, Track.idle, true, 5);
        _enemySpriteAnimator.StartAnimation(_enemyView.SpriteRenderer, Track.idle, true, 25);
        _simplePatrolAi = new SimplePatrolAi(_enemyView, new SimpalPatrolAiModel(_config));
    }

    private void Update()
    {
        _paralaxManager.Update();
        _playerSpriteAnimator.Update();
        _enemySpriteAnimator.Update();
        _cameraManager.Update();
    }
    private void FixedUpdate()
    {
        _mainHeroPhysicWalker.FixedUpdate();
        _simplePatrolAi.FixedUpdate();
    }
    private void OnDestroy()
    {
        
    }
}

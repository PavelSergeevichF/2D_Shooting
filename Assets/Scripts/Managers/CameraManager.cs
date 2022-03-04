using UnityEngine;

public class CameraManager
{
    private Camera _camera;
    private Transform _playerTransform;
    private const float _BorderLeft = -9f;
    private const float _BorderRight = 13f;

    public CameraManager(Camera camera, Transform Player)
    {
        _camera = camera;
        _playerTransform = Player;
    }

    public void Update()
    {
        if (_playerTransform.position.x > _BorderLeft && _playerTransform.position.x < _BorderRight)
        {
            var camTransform = _camera.transform.position;
            camTransform.x = _playerTransform.position.x;
            _camera.transform.position = camTransform;
        }
    }
}

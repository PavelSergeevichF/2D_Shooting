
using System;
using UnityEngine;

public class SimpalPatrolAiModel 
{
    private readonly AiConfig _config;
    private Transform _target;
    private int _currentPointIndex;
    public SimpalPatrolAiModel(AiConfig config)
    {
        _config = config;
        _target = GetNextWayPoint();
    }

    public Vector2 CalculateVelocity(Vector2 fromPosition)
    {
        var distance = Vector2.Distance(_target.position, fromPosition);
        if (distance <= _config.minDistanceToTarget)
            _target = GetNextWayPoint();
        var direction = ((Vector2)_target.position - fromPosition).normalized;
        return _config.speed * direction;
    }
    private Transform GetNextWayPoint()
    {
        _currentPointIndex = (_currentPointIndex + 1) % _config.wayPoints.Length;
        return _config.wayPoints[_currentPointIndex];
    }
}

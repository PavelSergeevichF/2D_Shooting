using System;
using UnityEngine;

[Serializable]
public class AiConfig
{
    public float speed;
    public float minDistanceToTarget;
    public Transform[] wayPoints;
}

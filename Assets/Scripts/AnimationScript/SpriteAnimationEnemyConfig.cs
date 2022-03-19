using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteAnimationEnemyConfig", menuName = "Data/SpriteAnimationEnemyConfig", order = 1)]
public class SpriteAnimationEnemyConfig : ScriptableObject
{
    [SerializeField]
    private List<SpritesSequence> _sequences;

    public List<SpritesSequence> Sequences => _sequences;
}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Data/SpriteAnimationConfig", order = 1)]
public class SpriteAnimationConfig : ScriptableObject
{
    [SerializeField]
    private List<SpritesSequence> _sequences;
    [SerializeField]
    private List<SpritesSequence> _sequencesEnemyFlyingBeetle;
    [SerializeField]
    private List<SpritesSequence> _sequencesEnemyBeatle;
    [SerializeField]
    private List<SpritesSequence> _sequencesEnemyCrab;

    public List<SpritesSequence> Sequences => _sequences;
    public List<SpritesSequence> SequencesEnemyFlyingBeetle => _sequencesEnemyFlyingBeetle;
    public List<SpritesSequence> SequencesEnemyBeatle => _sequencesEnemyBeatle;
    public List<SpritesSequence> SequencesEnemyCrab => _sequencesEnemyCrab;
}

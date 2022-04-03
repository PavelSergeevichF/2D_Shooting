using UnityEngine;

[CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "ConfigQuest/QuestStoryConfig", order = 1)]
public class QuestStoryConfig : ScriptableObject
{
    public QuestConfig[] Quests;
    public QuestStoryType QuestStoryType;
}

public enum QuestStoryType
{
    Comon,
    Resettable 
}

using UnityEngine;

[CreateAssetMenu(fileName = "QuestConfig", menuName = "Config/QuestConfig", order =1)]
public class QuestConfig : ScriptableObject
{
    public int id;
    public QuestType questType;
}

public enum QuestType
{
    Switch
}

using System;
using UnityEngine;

public class QuestObjectView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Color _completedColor;

    [SerializeField]
    private int _id;

    public int id => _id;

    private Color _defaultColor;

    public Action<PlayerView> OnLevelObjectContact;
    private void Awake()
    {
        _defaultColor = _spriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<PlayerView>();
        OnLevelObjectContact?.Invoke(levelObject);
    }
    public void ProcessComplete()
    {
        _spriteRenderer.color = _completedColor;
    }
    public void ProcessActivate()
    {
        _spriteRenderer.color = _defaultColor;
    }
}

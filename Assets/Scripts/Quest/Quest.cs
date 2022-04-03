using System;
using UnityEngine;

public class Quest : IQuest, IDisposable
{
    private readonly QuestObjectView _view;
    private readonly IQuestModel _model;

    private bool _active;

    public bool IsCompleted { get; private set; }

    public event Action<IQuest> Completed;

    public Quest(QuestObjectView view, IQuestModel model)
    {
        _view = view;
        _model = model;
    }

    public void Dispose()
    {
        _view.OnLevelObjectContact -= OnContact;
    }

    public void Reset()
    {
        if (_active)
            return;

        _active = true;
        IsCompleted = false;
        _view.OnLevelObjectContact += OnContact;
        _view.ProcessActivate();
    }

    private void OnContact(PlayerView playerView)
    {
        var completed = _model.TryComplete(playerView.gameObject);

        if (completed)
            Complete();
    }

    private void Complete()
    {
        if (!_active)
            return;

        _active = false;
        IsCompleted = true;
        _view.ProcessComplete();
        Completed?.Invoke(this);
        Dispose();
    }
}

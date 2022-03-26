
using UnityEngine;

public class SimplePatrolAi
{
    private readonly EnemyView _view;
    private readonly SimpalPatrolAiModel _model;
    public SimplePatrolAi(EnemyView view, SimpalPatrolAiModel model)
    {
        _view = view;
        _model = model;
    }
    public void FixedUpdate()
    {
        _view.Rigidbody.velocity = _model.CalculateVelocity(_view.transform.position);
    }
}

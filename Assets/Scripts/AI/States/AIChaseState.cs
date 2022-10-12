using UnityEngine;

public class AIChaseState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        enemy.agent.isStopped = false;
    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.newTarget.position);
    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

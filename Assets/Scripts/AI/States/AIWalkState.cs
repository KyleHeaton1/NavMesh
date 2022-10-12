using UnityEngine;

public class AIWalkState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        enemy.agent.isStopped = false;
        enemy.agent.SetDestination(enemy.pos);
    }
    
    public override void UpdateState(AIStateManager enemy)
    {

    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

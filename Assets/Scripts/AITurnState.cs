using UnityEngine;

public class AITurnState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {

    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        enemy.lookRotation = Quaternion.LookRotation(enemy.pos);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, enemy.lookRotation, Time.deltaTime * 4);
        enemy.agent.isStopped = true;
    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

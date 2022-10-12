using UnityEngine;

public class AITurnState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        enemy.agent.isStopped = true;
    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        /*
        enemy.lookRotation.x = 0;
        enemy.lookRotation.z = 0;
        enemy.lookRotation = Quaternion.LookRotation(enemy.pos);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, enemy.lookRotation, Time.deltaTime * 4);
       */
    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

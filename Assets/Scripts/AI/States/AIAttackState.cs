using UnityEngine;

public class AIAttackState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        enemy.agent.isStopped = false;
    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        enemy.anim.SetFloat("AttackBlend", enemy.agent.velocity.magnitude);
    }   

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

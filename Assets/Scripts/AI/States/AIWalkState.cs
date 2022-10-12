using UnityEngine;

public class AIWalkState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        enemy.nextStateTimer = 5.5f;
        enemy.agent.isStopped = false;
        enemy.index= Random.Range(0, enemy.positions.Length);
        enemy.currentPosition = enemy.positions[enemy.index];
        enemy.agent.SetDestination(enemy.currentPosition.transform.position);
    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        enemy.anim.SetFloat("Run Blend", enemy.agent.velocity.magnitude);

    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

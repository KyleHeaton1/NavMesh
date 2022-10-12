using UnityEngine;

public class AIIdleState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        
        //enemy.rb.velocity = Vector3.zero;
        enemy.x = Random.Range(22,-22);
        enemy.z = Random.Range(22,-22);
        enemy.y = 0;
        enemy.pos = new Vector3(enemy.x, enemy.z, enemy.y);
    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        enemy.agent.isStopped = true;
    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

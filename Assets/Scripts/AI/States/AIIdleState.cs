using UnityEngine;

public class AIIdleState : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        /*
        //enemy.rb.velocity = Vector3.zero;
        enemy.x = Random.Range(22,-22);
        enemy.z = Random.Range(22,-22);
        enemy.y = 0;
        enemy.pos = new Vector3(enemy.x, enemy.z, enemy.y);
        */
        //enemy.anim.Play("Male_Idle", 0, 0);
        enemy.nextStateTimer = .5f;
        //enemy.anim.SetFloat("Run Blend", 0);
    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        enemy.anim.SetFloat("Run Blend", enemy.agent.velocity.magnitude);
        enemy.agent.isStopped = true;
    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}

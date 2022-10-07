using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{

    public Rigidbody rb;
    AIBaseState currentState;
    public AIIdleState IdleState = new AIIdleState();
    public AIChaseState ChaseState = new AIChaseState();

    public float x,y,z;
    public Vector3 pos;

    public NavMeshAgent agent;
    public GameObject player;

    public Quaternion lookRotation;

    public float nextStateTimer, baseSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnCollisionEnter(Collision collsion)
    {
        currentState.OnCollisionEnter(this, collsion);
    }

    public void SwitchState(AIBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    
}


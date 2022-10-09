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
    public AITurnState TurnState = new AITurnState();
    public AIWalkState WalkState = new AIWalkState();

    public float x,y,z;
    public Vector3 pos;

    public NavMeshAgent agent;
    public GameObject player;

    public Quaternion lookRotation;

    public bool agroActive = false;
    bool canSwitch;

    public float nextStateTimer, baseTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextStateTimer = baseTime;
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        if(!agroActive)
        {
            nextStateTimer -= Time.deltaTime;
            if(nextStateTimer < 0)
            {
                canSwitch = true;
                nextStateTimer = baseTime;
                SwitchToNextStateInQueue();
            }
        }
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

    void SwitchToNextStateInQueue()
    {
        if(currentState == IdleState )
        {
            SwitchState(TurnState);
            Debug.Log("Idle");
        }
        if(currentState == TurnState)
        {
            SwitchState(WalkState);
            Debug.Log("Turn");
        }
        if(currentState == WalkState)
        {
            SwitchState(IdleState);
            Debug.Log("Walk");
        }
        if(agroActive)
        {
            SwitchState(ChaseState);
            Debug.Log("Chase");
        }
    }
}


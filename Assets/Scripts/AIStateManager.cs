using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{


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

        nextStateTimer = baseTime;
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);


        nextStateTimer -= Time.deltaTime;
        if(agroActive)
        {
            CheckForAgroState();
        }
        else
        {
            if(nextStateTimer < 0)
            {
                canSwitch = true;
                nextStateTimer = baseTime;
                NextStateInQueue();
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

    void NextStateInQueue()
    {
        if(currentState == IdleState && canSwitch)
        {
            SwitchState(TurnState);
            canSwitch = false;
            Debug.Log("Turn");
        }
        if(currentState == TurnState && canSwitch)
        {
            SwitchState(WalkState);
            canSwitch = false;
            Debug.Log("Walk");
        }
        if(currentState == WalkState && canSwitch)
        {
            SwitchState(IdleState);
            canSwitch = false;
            Debug.Log("Idle");
        }

    }
    void CheckForAgroState()
    {
        SwitchState(ChaseState);
        Debug.Log("Chase");
    }
}


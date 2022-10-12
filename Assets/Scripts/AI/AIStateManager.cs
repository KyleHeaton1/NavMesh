using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{


    AIBaseState currentState;
    public AIIdleState IdleState = new AIIdleState();
    public AIChaseState ChaseState = new AIChaseState();
    public AIWalkState WalkState = new AIWalkState();
    public AIFleeState FleeState = new AIFleeState();
    public AIAttackState AttackState = new AIAttackState();
    public AIFOV fov;

    public Transform newTarget;

    public float x,y,z;
    //public Vector3 pos;

    public NavMeshAgent agent;
    public GameObject player;

    public GameObject[] positions;
    public GameObject currentPosition;
    public int index;

    public Quaternion lookRotation;

    public bool agroActive = false;
    bool canSwitch;


    public float nextStateTimer, baseTime = 2;

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

            foreach (Transform visibleTarget in fov.visibleTargets)
            {
                newTarget = visibleTarget;
                Debug.Log("Target Found: ", visibleTarget.Find(name));
                agroActive = true;
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


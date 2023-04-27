using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : StateMachineBehaviour
{
    public EnemyManager em;
    public Vector3 monsterLocation;
    public Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        em = animator.GetComponent<EnemyManager>();

        player = GameObject.FindGameObjectWithTag("player").transform;
        monsterLocation = animator.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(em.meleeCounter == 3)
        {
            animator.SetBool("IsHeavyAttack", true);
            animator.SetBool("IsMelee", false);
        }

        float remainingDistance = Vector3.Distance(monsterLocation, player.position);
        if (remainingDistance >= 15 && remainingDistance <=50)
        {
            animator.SetBool("IsRangeAttack", true);
            animator.SetBool("IsMelee", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

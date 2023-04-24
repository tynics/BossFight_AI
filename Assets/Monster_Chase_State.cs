using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Chase_State : StateMachineBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public EnemyManager em;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        em = animator.GetComponent<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        /* var isThirthy = em.IsThirthyPercentHealth();
        if (isThirthy)
        {
            animator.SetBool("IsSpecialAttack", true);
            animator.SetBool("IsSpellAttack", false);
            animator.SetBool("IsRangeAttack", false);
            animator.SetBool("IsMelee", false);
            animator.SetBool("IsHeavyAttack", false);
            animator.SetBool("IsChase", false);
        } */
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.destination = player.position;
    
        if(agent.remainingDistance <= 5)
        {
            animator.SetBool("IsMelee", true);
            animator.SetBool("IsChase", false);
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

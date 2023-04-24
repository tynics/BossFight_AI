using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Range_Attack_State : StateMachineBehaviour
{
    public EnemyManager em;
    public Transform player;
    public float speed = 5;
    public Vector3 monsterLocation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        em = animator.GetComponent<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        em.isLookingAtPlayer = false;
        monsterLocation = animator.transform.position;

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
        if (em.rangeCounter == 5)
        {
            animator.SetBool("IsSpellAttack", true);
            animator.SetBool("IsRangeAttack", false);
        }

        float remainingDistance = Vector3.Distance(monsterLocation, player.position);
        Debug.Log(remainingDistance);
        if (remainingDistance >= 51)
        {
            animator.SetBool("IsRangeAttack", false);
            animator.SetBool("IsChase", true);
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

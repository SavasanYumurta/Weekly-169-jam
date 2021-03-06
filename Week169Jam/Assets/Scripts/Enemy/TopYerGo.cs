﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopYerGo : StateMachineBehaviour
{
    [SerializeField] private Transform topluk;
    [SerializeField] private float speed, offsetx, offsety;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        topluk = GameObject.FindWithTag("EnemyTopluk").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector3(topluk.position.x + offsetx, topluk.position.y + offsety), speed * Time.deltaTime);
        if (Vector2.Distance(animator.transform.position, new Vector3(topluk.position.x + offsetx, topluk.position.y + offsety)) <= 0.1)
        {
            animator.SetBool("isGoTopluk", false);
            animator.SetBool("isGoFire", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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

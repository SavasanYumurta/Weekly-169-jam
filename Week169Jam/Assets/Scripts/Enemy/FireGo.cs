using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGo : StateMachineBehaviour
{
    public Transform topos;
    [SerializeField]private float speed,offsetx,offsety;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      topos = GameObject.FindWithTag("EnemyTop").transform;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,new Vector3(topos.position.x + offsetx,topos.position.y + offsety),speed * Time.deltaTime);
        if (Vector2.Distance(animator.transform.position, new Vector3(topos.position.x + offsetx, topos.position.y + offsety)) <= 0.001)
        {
            animator.SetBool("isGoFire", false);
            animator.SetBool("isFire", true);
        }
    }
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

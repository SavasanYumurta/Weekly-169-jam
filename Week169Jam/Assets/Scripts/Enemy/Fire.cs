using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public class Fire : StateMachineBehaviour
{
    [SerializeField] private GameObject mermi;
    [SerializeField] private FireGo fG;
    [SerializeField] private float offsetx,offsety,maxSpeed,minSpeed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fG = animator.GetBehaviour<FireGo>();
        GameObject go = Instantiate(mermi,new Vector2(fG.topos.position.x - 5, fG.topos.position.y), Quaternion.identity);
        float topSpeed = Random.Range(minSpeed, maxSpeed);
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fG.topos.position.x - offsetx, fG.topos.position.y + offsety) * topSpeed);
        animator.SetBool("isFire", false);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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

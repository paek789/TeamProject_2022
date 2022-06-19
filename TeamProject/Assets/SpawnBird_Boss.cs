using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird_Boss : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(Resources.Load("DrillBird_Original") as GameObject, new Vector3(GameObject.Find("boss_head").transform.position.x+25, GameObject.Find("boss_head").transform.position.y - 3, GameObject.Find("boss_head").transform.position.z), Quaternion.identity);
        Instantiate(Resources.Load("DrillBird_Original") as GameObject, new Vector3(GameObject.Find("boss_head").transform.position.x + 25, GameObject.Find("boss_head").transform.position.y - 5, GameObject.Find("boss_head").transform.position.z), Quaternion.identity);
        Instantiate(Resources.Load("DrillBird_Original") as GameObject, new Vector3(GameObject.Find("boss_head").transform.position.x + 25, GameObject.Find("boss_head").transform.position.y - 1, GameObject.Find("boss_head").transform.position.z), Quaternion.identity);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("patternInt", 0);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss1 : StateMachineBehaviour
{
    GameObject bullet;
    float timer;
    int ready;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        bullet = Resources.Load("Enemy_Bullet_1") as GameObject;
        ready = 5;
    }    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 0.3f && ready>0)
        {
            Instantiate(bullet, new Vector3(GameObject.Find("boss_head").transform.position.x, GameObject.Find("boss_head").transform.position.y-3, GameObject.Find("boss_head").transform.position.z), Quaternion.identity);                       
            timer = 0;
            ready--;
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

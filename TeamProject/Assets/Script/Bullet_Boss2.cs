using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss2 : StateMachineBehaviour
{
    GameObject bullet;
    float timer;
    bool ready;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        bullet = Resources.Load("Enemy_Bullet_2") as GameObject;
        ready = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 0.5f && ready)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 ranY = new Vector3(0f, Random.Range(-2f, 5f)-6, 0f);
                Vector3 ranVec = new Vector3(Random.Range(-0.8f, 0.8f), Random.Range(0f, 2f), 0);
                Instantiate(bullet, GameObject.Find("boss_head").transform.position + ranVec + ranY, Quaternion.identity);
            }
            ready = false;
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

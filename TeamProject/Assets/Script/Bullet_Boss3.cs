using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss3 : StateMachineBehaviour
{
    GameObject bullet;
    float timer;
    bool ready;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        bullet = Resources.Load("Enemy_Bullet_3") as GameObject;
        ready = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 0.5f && ready)
        {
            Vector3 ranY = new Vector3(0f, Random.Range(-2f, 4f)-4, 0);
            for (int i = 0; i < 3; i++)
            {
                Vector3 ArcVec = new Vector3(0.5f * i, 3f * i, 0);
                Instantiate(bullet, GameObject.Find("boss_head").transform.position + ArcVec + ranY, Quaternion.identity);

            }
            for (int j = 0; j > -3; j--)
            {
                Vector3 ArcVec = new Vector3(-0.5f * j, 3f * j, 0);
                Instantiate(bullet, GameObject.Find("boss_head").transform.position + ArcVec + ranY, Quaternion.identity);

            }
            ready = false;
        }
    }    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("patternInt", 0);
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

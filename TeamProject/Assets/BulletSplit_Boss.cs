using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplit_Boss : StateMachineBehaviour
{
    GameObject bullet;
    float timer;
    bool ready;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        ready = true;
        bullet = Resources.Load("Split_Bullet") as GameObject;
    }   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 0.9f && ready)
        {
            ready = false;
            Instantiate(bullet, new Vector3(GameObject.Find("boss_head").transform.position.x-3, GameObject.Find("boss_head").transform.position.y - 6, GameObject.Find("boss_head").transform.position.z), Quaternion.identity);
        }
    }   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("patternInt", 0);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_idle : StateMachineBehaviour
{
    float timer = 0;
    float timer2 = 0;
    SpriteRenderer bubble;
    int behavior = 0;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bubble = GameObject.Find("bubbletext").GetComponent<SpriteRenderer>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer > 5f)
        {
            if (behavior == 0)
            {
                animator.SetTrigger("dwarfTrigger");
                behavior = 1;
            }
            else if (behavior == 1)
            {
                animator.SetTrigger("sadTrigger");
                behavior = 0;
            }
            timer = 0;
        }
        if (bubble.color.a>0) timer2 += Time.deltaTime;
        if (bubble.color.a >0 && timer2 > 0.01)
        {
            bubble.color = new Color(bubble.color.r, bubble.color.g, bubble.color.b, bubble.color.a - timer2);
            timer2 = 0;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}

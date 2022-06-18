using UnityEngine;

public class Beam_Boss : StateMachineBehaviour
{
    float timer;
    bool ready;
    bool destroy;
    GameObject beam;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        ready = true;
        destroy = false;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 4f && ready)
        {
            ready = false;
            beam = Instantiate(Resources.Load("beam") as GameObject, new Vector3(GameObject.Find("bone_8").transform.position.x, GameObject.Find("bone_8").transform.position.y, GameObject.Find("bone_8").transform.position.z), Quaternion.identity);
        }
        if(timer < 5.5f && !ready) beam.transform.position = new Vector3 (GameObject.Find("bone_8").transform.position.x - 11, GameObject.Find("bone_8").transform.position.y, GameObject.Find("bone_8").transform.position.z);
        if (timer > 5.5f && !destroy)
        {
            Destroy(beam);
            destroy = true;
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

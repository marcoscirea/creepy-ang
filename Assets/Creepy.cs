using UnityEngine;
using System.Collections;

public class Creepy : MonoBehaviour
{

    public Vector3 target;
    public bool chase = false;
    Animator animator;
    NavMeshAgent agent;
    public bool seen = false;
    GameObject player;

    Vector3 lastFramePosition;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();   
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        lastFramePosition = transform.position;

        animator.applyRootMotion = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 currentFramePosition = transform.position;
        float distance = Vector3.Distance(lastFramePosition, currentFramePosition);
        
        lastFramePosition = currentFramePosition;
        float currentSpeed = Mathf.Abs(distance)/Time.deltaTime;

        if(!seen)
            Chase(player.transform.position);

        if (currentSpeed < 0.5f)
        {
            animator.SetBool("Run", false);
        } else
        {
            animator.SetBool("Run", true);
        }

        /*if (agent.remainingDistance < 2f)
        {
            agent.Stop();
        }*/

        /*if (seen)
        {
            Freeze();
        } else
        {
            Resume();
        }*/
    }

    public void Chase(Vector3 t)
    {
        target = t;
        agent.SetDestination(t);
        chase = true;
        animator.SetBool("Run", true);
    }

    public void Freeze(){
        agent.enabled = false;
        animator.enabled = false;
        seen = true;
    }

    public void Resume(){
        agent.enabled = true;
        agent.SetDestination(target);
        animator.enabled = true;
        seen = false;
    }
}

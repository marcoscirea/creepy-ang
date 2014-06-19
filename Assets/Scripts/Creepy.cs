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
    public bool activated = true;
    Vector3 lastFramePosition;
    //AudioSource audio;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();   
        agent = GetComponent<NavMeshAgent>();
        //audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");

        lastFramePosition = transform.position;

        animator.applyRootMotion = false;

        if (enabled)
            audio.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            Vector3 currentFramePosition = transform.position;
            float distance = Vector3.Distance(lastFramePosition, currentFramePosition);
        
            lastFramePosition = currentFramePosition;
            float currentSpeed = Mathf.Abs(distance) / Time.deltaTime;

            if (!seen)
                Chase(player.transform.position);

            if (currentSpeed < 0.5f)
            {
                animator.SetBool("Run", false);
            } else
            {
                animator.SetBool("Run", true);
            }
        } else
        {
            Freeze();
        }
    }

    public void Chase(Vector3 t)
    {
        target = t;
        agent.SetDestination(t);
        chase = true;
        animator.SetBool("Run", true);
    }

    public void Freeze()
    {
        if (!seen)
        {
            //agent.enabled = false;
            agent.Stop();
            animator.enabled = false;
            audio.Pause();
            seen = true;
        }
    }

    public void Resume()
    {
        if (seen && activated)
        {
            //agent.enabled = true;
            if (activated)
                agent.SetDestination(target);
            animator.enabled = true;
            audio.Play();
            seen = false;
        }
    }

    void OnTriggerEnter(Collider collider){
        if (activated && collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dead");
        }
    }
}

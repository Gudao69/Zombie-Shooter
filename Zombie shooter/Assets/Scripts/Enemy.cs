using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Animator animator;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
            float distance = 0;
            distance = Vector3.Distance(transform.position, player.position);

            if (distance > 3)
            {
                agent.isStopped = false;
                agent.SetDestination(player.position);
                animator.SetInteger("State", 0);
            }
            else
            {
                agent.isStopped = true;
                animator.SetInteger("State", 1);
            }
        }
    }

    public void AttackToPlayer()
    {
        Player player;
        player = FindObjectOfType<Player>();

        player.RedcueHealth();
    }

    public void DoDamage()
    {
        health -= 1;

        if(health <= 0)
        {
            agent.isStopped = true;
            animator.SetInteger("State", 2);
            GameObject.Destroy(gameObject,2f);
        }
    }
}

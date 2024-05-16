using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBossMish : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform playerTarget;
    public Transform playerHead;
    public float stopDistance = 5;
    private Animator animator;
    public SimpleShoot gun;
    public bool isAlive = true;
    public float maxHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetupRagdoll();
    } 

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            agent.SetDestination(playerTarget.position);
            float distance = Vector3.Distance(playerTarget.position, transform.position);
            if (distance < stopDistance) {
                agent.isStopped = true;
                animator.SetBool("Shoot", true);
            } else {
                agent.isStopped = false;
                animator.SetBool("Shoot", false);
                agent.SetDestination(playerTarget.position);
            }

            if (playerHead != null) {
                transform.LookAt(playerHead);
            }
        }
    }
    public void ShootEnemy() {
        gun.Shoot();
    }

    public void SetupRagdoll()
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = true;
        }
    }

    public void TakeDamage(Vector3 pos, float damage = 20) {
        print("Took damage");
        currentHealth -= damage;
        if (currentHealth <= 0) {
            print("Dead");
            Dead(pos);
        }
    }

    public void Dead(Vector3 hitPosition)
    {
        isAlive = false;
        agent.isStopped = true;
        animator.enabled = false;
        GameManagerMish.instance.BossKilled();

        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.transform.position = transform.position;
            item.isKinematic = false;
        }

        foreach (var item in Physics.OverlapSphere(hitPosition, 0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if(rb)
            {
                rb.AddExplosionForce(1000, hitPosition, 0.3f);
            }
        }
    }
}

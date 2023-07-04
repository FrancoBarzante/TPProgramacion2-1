using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour , Interfaz
{
    public int maxHealth = 3;
    public GameObject deathEffect;
    public string playerTag = "Player"; // Etiqueta del objeto que el enemigo seguirá
    public float chaseRange = 10f; // Rango de distancia para comenzar a perseguir al jugador
    public float speed = 3f;


    public int currentHealth;
    public NavMeshAgent navMeshAgent;
    private GameObject player;
     

    
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag(playerTag);
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= chaseRange)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
            else
            {
                navMeshAgent.SetDestination(transform.position);
            }
        }
    }

  

    public virtual void Die()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        Destroy(this.gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Die();
        }

        Debug.Log(damage);
    }
}

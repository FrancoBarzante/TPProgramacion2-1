using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public GameObject deathEffect;
    public string playerTag = "Player"; // Etiqueta del objeto que el enemigo seguirá
    public float chaseRange = 10f; // Rango de distancia para comenzar a perseguir al jugador


    public int currentHealth;
    public NavMeshAgent navMeshAgent;
    private GameObject player;
     

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        player= GameObject.FindGameObjectWithTag(playerTag);
        navMeshAgent = GetComponent<NavMeshAgent>();
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

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
        {
            Die();
        }

        Debug.Log(damage);
    }

    private void Die()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        Destroy(this.gameObject);
    }
}

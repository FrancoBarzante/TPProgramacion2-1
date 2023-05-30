using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public GameObject deathEffect;

    private int currentHealth;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
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

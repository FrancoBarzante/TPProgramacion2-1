using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFly : Enemy
{
    public float speedMultiplier = 1.5f; // Factor de multiplicación de velocidad
    public int extraHealth = 2; // Vida adicional

    protected override void Start()
    {
        base.Start();
        currentHealth = extraHealth;        
        navMeshAgent.speed *= speedMultiplier;// Multiplica la velocidad del NavMeshAgent del hijo de Enemy
    }

    public override void TakeDamage(int damage)
    {
        Debug.Log("Logica Nueva");
        base.TakeDamage(damage);
    }

    


}

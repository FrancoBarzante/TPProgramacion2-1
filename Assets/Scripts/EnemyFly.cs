using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFly : Enemy
{
    public float speedMultiplier = 1.5f; // Factor de multiplicación de velocidad
    public int extraHealth = 2; // Vida adicional

    private void Start()
    {
        currentHealth = maxHealth + extraHealth; // Establece la vida inicial sumando el valor extraHealth
        navMeshAgent.speed *= speedMultiplier; // Aumenta la velocidad multiplicando el valor speedMultiplier
    }
}

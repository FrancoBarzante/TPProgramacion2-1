using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public string nextSceneName = "Level2";
    public Collider nextLevelDoorCollider; // Asigna el collider de la puerta en el inspector

    private void Update()
    {
        // Verifica si no hay enemigos activos en la escena
        if (AreAllEnemiesDefeated())
        {
            TeleportToNextScene();
        }
    }

    private bool AreAllEnemiesDefeated()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.IsAlive)
            {
                return false; // Todavía hay enemigos vivos
            }
        }

        return true; // No quedan enemigos vivos
    }

    private void TeleportToNextScene()
    {
        SceneManager.LoadScene("Level2");
    }
}


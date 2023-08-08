using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagerR : MonoBehaviour
{
    

    private int totalEnemies;
    private int enemiesDefeated;

    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesDefeated = 0;
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;

        if (enemiesDefeated >= totalEnemies)
        {
            SceneManager.LoadScene("winScene");
        }
    }
}

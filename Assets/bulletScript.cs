using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public GameObject impactEffect;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        if(impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}

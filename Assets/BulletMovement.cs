using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    
}

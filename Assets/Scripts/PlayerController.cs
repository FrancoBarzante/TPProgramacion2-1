using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float bulletSpeed = 10f;



    private Rigidbody rb;
    private float nextFireTime;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 direction = mousePosition - transform.position;
        direction.y = 0f;

        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * speed;

        

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

       
        
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Vector3 characterDirection = transform.forward;

        bulletScript bulletMovement = bullet.GetComponent<bulletScript>();
        if(bulletMovement != null)
        {
            bulletMovement.SetDirection(characterDirection);
            
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}

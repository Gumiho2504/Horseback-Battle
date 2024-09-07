using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] GameObject greenParticles;
    //public Camera cam;
    void Start()
    {
        Vector3 taget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity =(taget - transform.position)* speed;
    }

 
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDemage(20);
        }else if (collision.CompareTag("zone"))
        {
            Destroy(gameObject);
        }
        //Instantiate(greenParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

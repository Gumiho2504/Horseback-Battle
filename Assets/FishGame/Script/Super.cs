using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Super : MonoBehaviour
{

    //public float lifeTime;
    //public float distance;
    //public LayerMask whatIsSolid;
    public GameObject destoryEffect;
    public float speed;
    public float demege;
    private Rigidbody2D rb;
    [SerializeField] GameObject greenParticles;
    void Start()
    {

       // Vector3 taget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }


    void Update()
    {


    }

    void DestroyBullet()
    {
        Instantiate(destoryEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDemage(demege);
            }
            

            rb.isKinematic = true;
            rb.simulated = false;

            StartCoroutine(d());
        }
        if (collision.CompareTag("zone"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator d()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}

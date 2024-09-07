using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy: MonoBehaviour
{
    public float health;
    public float speed ;
    public Slider healthSlider;
    //public float demage;
    private Rigidbody2D rb;
    [SerializeField] private GameObject redParticles;

    public void TakeDemage(float demage)
    {
    
        health -= demage;
        healthSlider.value = health;
        if(health <=0)
        {
            Instantiate(redParticles, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<Weapon>().IncreasPower();
            FindObjectOfType<EnemySpawner>().currentEnemyCount -= 1;
            GameManager.instance.IncreasKill();
            GameManager.instance.enemydie.PlayOneShot(GameManager.instance.enemydie.clip);
        }
    }

    private void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        //rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(speed,rb.velocity.y);
    }
}

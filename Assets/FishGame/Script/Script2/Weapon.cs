using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float offset;
    public GameObject bullet,super;
    public Transform shotPos;
    public float timeBtwShots;
    public SpriteRenderer weaponSpriteRenderer;
    public Sprite[] weaponSprite;

    public float jumpHeight = 2f; // Height of the jump
    public float jumpDuration = 0.5f; // Duration of the jump
    public float fallDuration = 0.5f; // Duration of the fall

    
    //public static float demage;

    public Slider heathSlider;
    public Slider powerSlider;
    public float heath = 10000;
    public float power = 0;
    public GameObject place;
    public Button supperButton;

    bool isJumping = false;

    public GameObject gameOverPanel;

    private void Start()
    {
        gameObject.transform.position = place.transform.position;
        supperButton.interactable = false;
        supperButton.onClick.AddListener(OnClickSupper);
        heathSlider.maxValue = heath;
        heathSlider.value = heath;
        powerSlider.maxValue = 100;
        powerSlider.value = power;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0f,0f, rotZ+ offset);
      
        if(timeBtwShots <= 0)
        {
            if(Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<Animator>().Play("shoot");

                StartCoroutine(Shoot(rotZ));
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

       
    }


    
    IEnumerator Shoot(float rotZ)
    {
        GameManager.instance.shoot.PlayOneShot(GameManager.instance.shoot.clip);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bullet, shotPos.position, Quaternion.Euler(0f, 0f, rotZ + offset));
        //GameManager.instance.DecreasCoin(10);
    }

    int weaponIndex = 0;
    public void SwitchWeapon()
    {
         string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch(buttonName){
            case "-":
                weaponIndex--;
                weaponSpriteRenderer.sprite = weaponSprite[weaponIndex];
                break;
            default:
                weaponIndex++;
                weaponSpriteRenderer.sprite = weaponSprite[weaponIndex];
                break;

        }
        print(weaponIndex);
    }

    public void Jump()
    {
        isJumping = true;

        // Jump up to the specified height
        LeanTween.moveY(gameObject, transform.position.y + jumpHeight, jumpDuration).setEaseOutQuad().setOnComplete(() =>
        {
            // Fall back down after the jump
            LeanTween.moveY(gameObject,  -1.47f, fallDuration).setEaseInQuad().setOnComplete(() =>
            {
                isJumping = false;
            });
        });
    }

    public void IncreasPower()
    {
        power += 10f;
        powerSlider.value = power;
        if(power == powerSlider.maxValue)
        {
            supperButton.interactable = true;
        }
        
    }

    public void PlayerOnAttack()
    {
        heath -= Random.Range(100, 150);
        heathSlider.value = heath;
        gameObject.GetComponent<Animator>().Play("onA");
        if (heath <= 0)
        {
            GameManager.instance.playerdie.PlayOneShot(GameManager.instance.playerdie.clip);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnClickSupper()
    {
        power = 0;
        GameManager.instance.supper.PlayOneShot(GameManager.instance.supper.clip);
        powerSlider.value = power;
        Instantiate(super, shotPos.position, Quaternion.identity);
        supperButton.interactable = false;

    }
}

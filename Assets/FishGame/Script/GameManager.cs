using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    public int kill = 0;
    public float time = 0f;
    
    public Text timeText;
    public Text killText;
    public Text killTextOver;
    public AudioSource bg, shoot, supper, click, playerdie, enemydie;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        killText.text = $"kill = {kill}";
        killTextOver.text = $"kill = {kill}";
        //coinText.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("00.00") + "s";
    }

    public void PlayAgain()
    {
        click.PlayOneShot(click.clip);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        click.PlayOneShot(click.clip);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void IncreasKill()
    {
        kill += 1;
        killText.text = $"kill = {kill}";
        killTextOver.text = $"kill = {kill}";
    }


    public void OnClickSound(int i)
    {
        if (i == 0)
        {
            bg.mute = true;
            shoot.mute = true;
            supper.mute = true;
            playerdie.mute = true;
            enemydie.mute = true;
            click.mute = true;
        }
        else
        {
            bg.mute = false;
            shoot.mute = false;
            supper.mute = false;
            playerdie.mute = false;
            enemydie.mute = false;
            click.mute = false;
        }
    }
}

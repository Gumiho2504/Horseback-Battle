using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuControll : MonoBehaviour
{
    public GameObject loadingPanel;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        loadingPanel.SetActive(false);
        
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

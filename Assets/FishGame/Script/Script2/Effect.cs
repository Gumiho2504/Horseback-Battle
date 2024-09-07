using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEfect());
    }

   
    void Update()
    {
        
    }

    IEnumerator DestroyEfect()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
       // print("gggg");
    }
}

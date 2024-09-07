using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1,1)]
    public float speed = 5f;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * speed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}

using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private Renderer backgroundRender; 
    public float scrollSpeed; 
    private void Update()
    {
        backgroundRender.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0); 
    }
}

using UnityEngine;

public class LawnmowerVisuals : MonoBehaviour
{

    public Transform asset; // For visually flipping asset

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        Vector3 scale = asset.localScale;
        asset.localScale = scale;
    }

}

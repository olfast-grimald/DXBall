using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickk : MonoBehaviour
{
    public int hits = 1;
    public int points = 10;
    public Vector3 rotator;
    public Material hitMaterial;

    Material poriginalMat;
    Renderer prenderer;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y) * 0.1f);
        prenderer = GetComponent<Renderer>();
        poriginalMat = prenderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        if(hits <= 0)
        {
            Destroy(gameObject);
        }
        prenderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }

    void RestoreMaterial()
    {
        prenderer.sharedMaterial = poriginalMat;
    }
}

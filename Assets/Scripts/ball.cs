using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    float pspeed = 20f;
    Rigidbody prigidbody;
    Vector3 pvelocity;

    // Start is called before the first frame update
    void Start()
    {
        //to have access to the rigidbody compnent added to ball from inspector:
        prigidbody = GetComponent<Rigidbody>();
        prigidbody.velocity = Vector3.down * pspeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //direction component of velocity is set to reflected angle i think, and speed component of velocity is assigned
        prigidbody.velocity = prigidbody.velocity.normalized * pspeed;
        pvelocity = prigidbody.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        prigidbody.velocity = Vector3.Reflect(pvelocity, collision.contacts[0].normal);
    }
}

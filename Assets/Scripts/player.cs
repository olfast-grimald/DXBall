using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody prigidbody;
    // Start is called before the first frame update
    void Start()
    {
        prigidbody = GetComponent<Rigidbody>();
       // Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move the paddle rigid body along ((x of mouse input, y 0, z 50) as x, y -17, z 0) in the world
        prigidbody.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x, -17, 0));
    }
}

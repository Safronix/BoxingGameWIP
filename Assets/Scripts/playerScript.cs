using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = .1f;

    // Update is called once per frame
    void Update()
    {
        // general movement
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical"); // backwards and forwards

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection * speed;
    }
}

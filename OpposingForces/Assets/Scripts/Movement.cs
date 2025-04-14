using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3;
    Rigidbody rb;
    public AudioClip gemSound;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement using arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.position += Vector3.right * speed * Time.deltaTime;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
        //if player touches gem, increase their speed
    {
        if(collision.gameObject.layer == 3)
        {
            source.PlayOneShot(gemSound);
            Destroy(collision.gameObject);
            speed += 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track1Travel : MonoBehaviour {

    public float speed;
    public Vector3 direction;
    private Vector3 velocity;
    private Vector3 initialposition;

    private void Start()
    {
        initialposition = transform.position;
        velocity = speed * direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("track1"))
        {
            direction = new Vector3(1, 0, 0);
        }
        else if (other.gameObject.CompareTag("track2"))
        {
            direction = new Vector3(0, 1, 0);
        }
        else if (other.gameObject.CompareTag("track3"))
        {
            direction = new Vector3(-1, 0, 0);
        }
        else if (other.gameObject.CompareTag("track4"))
        {
            direction = new Vector3(0, -1, 0);
        }
        velocity = speed * direction;
    }

    private void FixedUpdate()
    {
        transform.position = initialposition + velocity * (Time.deltaTime);
        initialposition = transform.position;
    }
}

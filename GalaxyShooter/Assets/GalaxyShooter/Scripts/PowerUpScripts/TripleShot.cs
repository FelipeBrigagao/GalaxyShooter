using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float tripleShotSpeed = 20f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector3.up * tripleShotSpeed;
    }

    void Update()
    {
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}

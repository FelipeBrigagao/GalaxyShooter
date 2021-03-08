using UnityEngine;

public class Laser : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float laserSpeed = 20f;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector3.up * laserSpeed;
    }


    private void Update()
    {
        if(transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}

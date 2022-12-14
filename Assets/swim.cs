using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swim : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed = 3;
    public bool caught = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(new Vector2(-1,0) * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.Sleep();
        if (rb.gameObject.transform.position.x < -15)
        {
            Destroy(rb.gameObject);
        }
    }
}

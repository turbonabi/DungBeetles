using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornControl : MonoBehaviour
{
    public Rigidbody2D rd;
    public float shootForcel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Vector3 dir = -collision.gameObject.transform.up;
            rd.AddForce(dir * shootForcel);
        }
    }
}

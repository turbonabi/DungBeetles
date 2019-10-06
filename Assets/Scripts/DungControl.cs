using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungControl : MonoBehaviour
{
    Collider2D col;
    Rigidbody2D rd;
    Vector3 targetPos;

    public float scorePoint { set; get; }

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        rd = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!col.enabled)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5);
            if ((transform.position - targetPos).magnitude < 0.2f)
            {
                rd.bodyType = RigidbodyType2D.Static;
                enabled = false;
            }
        }
    }

    public void SetMass(float mass)
    {
        rd.mass = mass;
    }

    public void TurnOff(Vector3 nextPos)
    {
        col.enabled = false;
        rd.bodyType = RigidbodyType2D.Kinematic;
        Vector3 diff = transform.position - nextPos;
        targetPos = nextPos + (diff * Random.Range(-.2f, .7f));
    }
}

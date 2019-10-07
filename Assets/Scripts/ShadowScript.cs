using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    public float castDist;
    Vector3 shadowDist;
    // Start is called before the first frame update
    void Start()
    {
        shadowDist = new Vector3(castDist, -castDist, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position + shadowDist;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleControl : MonoBehaviour
{
    public SpriteRenderer bodySR;
    public SpriteRenderer colorSR;
    bool isMount;
    Rigidbody2D rd;
    Collider2D cd;
    float moveFactor = 1;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
    }

    public void MoveAndTurn(float moveValue, float turnValue)
    {
        Move(moveValue);
        Turn(turnValue);
    }

    public void Move(float moveValue)
    {
        cd.enabled = moveValue < 0;
        moveFactor = cd.enabled ? 0.8f : 1;
        Vector3 moveForce = rd.transform.up * moveValue * Time.deltaTime * 160 * moveFactor;
        Debug.DrawRay(rd.transform.position, moveForce, Color.black, 1);
        rd.AddForce(moveForce);
    }

    public void Turn(float turnValue)
    {
        rd.transform.Rotate(0, 0, turnValue * Time.deltaTime * 160 * moveFactor);
    }

    public void SetupBeetle(int id, Color c)
    {
        int sortOrder = id * 10;
        bodySR.sortingOrder = sortOrder;
        colorSR.sortingOrder = sortOrder + 1;
        colorSR.color = c;
    }
}

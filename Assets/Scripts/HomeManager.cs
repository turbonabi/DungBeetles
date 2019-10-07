using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public SpriteRenderer homeColor;
    public float score;
    public int PlayerId { private set; get; }
    public BeetleControl PlayerBeetle { private set; get; }

    public void SetBeetle(int id, BeetleControl bc)
    {
        PlayerId = id;
        PlayerBeetle = bc;
        PlayerBeetle.SetupBeetle(PlayerId, homeColor.color);
    }


    public void Activate()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DungControl dc = collision.GetComponent<DungControl>();
        if (dc != null)
        {
            score += dc.scorePoint;
            dc.TurnOff(transform.position);

            PlayManager.Instance.ClaimWinner(PlayerId, score);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public SpriteRenderer homeColor;
    public float score;
    private BeetleControl playerBeetle;
    public BeetleControl PlayerBeetle
    {
        set
        {
            playerBeetle = value;
            playerBeetle.SetColor(homeColor.color);
        }
        get
        {
            return playerBeetle;
        }
    }
    public int PlayerId { set; get; }

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
        score += dc.scorePoint;
        dc.TurnOff(transform.position);

        PlayManager.Instance.ClaimWinner(PlayerId, score);
    }
}

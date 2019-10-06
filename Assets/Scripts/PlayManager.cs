using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : Singleton<PlayManager>
{
    public InputManager inputManager;
    public SetupManager setupManager;

    public int playerCount;
    public int winningScore;

    public bool IsPlaying { private set; get; }

    Dictionary<int, HomeManager> homes;
    private void Awake()
    {
        homes = new Dictionary<int, HomeManager>();
    }

    void Start()
    {
        HomeManager[] activeHomes = setupManager.SetupPlayground(playerCount);
        foreach (var home in activeHomes)
        {
            homes[home.PlayerId] = home;
        }

        IsPlaying = true;
    }

    public BeetleControl GetBeetle(int id)
    {
        return homes[id].PlayerBeetle;
    }

    public void ClaimWinner(int id, float score)
    {
        if (score >= winningScore)
        {
            IsPlaying = false;
        }
    }
}

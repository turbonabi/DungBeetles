using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : Singleton<PlayManager>
{
    public InputManager inputManager;
    [HideInInspector]
    public SetupManager setupManager;

    public int playerCount;
    public int winningScore;

    public bool IsPlaying { private set; get; }

    Dictionary<int, HomeManager> homes;
    private void Awake()
    {
        homes = new Dictionary<int, HomeManager>();
        IsPlaying = false;
        StartSetup();
    }

    public void StartSetup()
    {
        setupManager = FindObjectOfType<SetupManager>();
        homes.Clear();
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

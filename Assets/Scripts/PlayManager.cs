using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayManager : Singleton<PlayManager>
{
    public TextMeshProUGUI winnerText;
    public InputManager inputManager;
    [HideInInspector]
    public SetupManager setupManager;

    public bool IsPlaying { private set; get; }
    Dictionary<int, HomeManager> homes;
    private void Awake()
    {
        homes = new Dictionary<int, HomeManager>();
        IsPlaying = false;
    }

    public void StartSetup(int playerCount)
    {
        setupManager = FindObjectOfType<SetupManager>();
        homes.Clear();
        HomeManager[] activeHomes = setupManager.SetupPlayground(playerCount);
        foreach (var home in activeHomes)
        {
            homes[home.PlayerId] = home;
        }
        IsPlaying = true;
        InputManager.Instance.State = InputManager.PlayState.Play;
    }

    public BeetleControl GetBeetle(int id)
    {
        return homes[id].PlayerBeetle;
    }

    public void ClaimWinner(int id, float score)
    {
        if (score >= InputManager.Instance.winningScore)
        {
            IsPlaying = false;
            winnerText.text = "Player " + id + "\r\nWon";
            StartCoroutine(DisplayWinner());
        }
    }

    IEnumerator DisplayWinner()
    {
        winnerText.enabled = true;
        yield return new WaitForSeconds(1);
    }

    public void OnBackHome()
    {
        InputManager.Instance.State = InputManager.PlayState.End;
    }
}

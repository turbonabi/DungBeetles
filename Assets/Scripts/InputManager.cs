using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager>
{
    public enum PlayState { Home, Ready, Play, End };
    public PlayState State { set; get; }

    public int playerCount;
    public int winningScore;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case PlayState.Home:
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene("Main");
                }
                break;
            case PlayState.Ready:
                PlayManager.Instance.StartSetup(playerCount);
                break;
            case PlayState.Play:
                {
                    if (PlayManager.Instance.IsPlaying)
                    {
                        for (int i = 0; i < playerCount; i++)
                        {
                            int beetleNum = i + 1;
                            float forwardValue = Input.GetAxisRaw("Beetle_" + beetleNum + "_Forward");
                            //beetles[i].Move(forwardValue);
                            float turnValue = Input.GetAxisRaw("Beetle_" + beetleNum + "_Turn");
                            //beetles[i].Turn(turnValue);

                            PlayManager.Instance.GetBeetle(beetleNum).MoveAndTurn(forwardValue, turnValue);
                        }
                    }
                    else
                    {
                        if (Input.anyKeyDown)
                        {
                            PlayManager.Instance.OnBackHome();
                        }
                    }
                }
                break;
            case PlayState.End:
                {
                    if (PlayManager.Instance != null)
                    {
                        Destroy(PlayManager.Instance.gameObject);
                    }
                    SceneManager.LoadScene("Home");
                }
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            State = PlayState.Ready;
        }
        else if (scene.name == "Home")
        {
            State = PlayState.Home;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

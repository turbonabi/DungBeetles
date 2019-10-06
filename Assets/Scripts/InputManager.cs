﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    // Update is called once per frame
    void Update()
    {
        if (PlayManager.Instance.IsPlaying)
        {
            for (int i = 0; i < PlayManager.Instance.playerCount; i++)
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

        }
    }
}

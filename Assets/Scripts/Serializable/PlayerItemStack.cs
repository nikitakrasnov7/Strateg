using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerItemStack 
{
    private Player _player;

    public Player Player => _player;
    public PlayerItemStack()
    {
        _player = null;
    }

    public PlayerItemStack(PlayerItemStack stack)
    {
        _player = stack.Player;
    }

    public PlayerItemStack(Player player)
    {
        _player = player;
    }

    

}

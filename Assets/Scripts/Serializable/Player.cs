using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Player
{
    private string _name;
    private Color _color;
    private bool _isMainPlayer = false;

    public string Name => _name;
    public Color Color
    {
        get => _color;
        set => _color = value;
    }

    public bool IsMainPlayer => _isMainPlayer;

    public Player(string name, Color color, bool isMainPlayer = false)
    {
        _name = name;
        Color = color;
        _isMainPlayer = isMainPlayer;
        
    }
}

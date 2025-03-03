using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Game Settings/Resources Count", fileName = "Resources Count")]
public class ResourceCountSO : ScriptableObject
{
    [SerializeField] private int _units;
    [SerializeField] private int _food;
    [SerializeField] private int _tree;
    [SerializeField] private int _iron;
    [SerializeField] private int _rock;

    public int Units { get { return _units; } set { _units = value; } }
    public int Food { get { return _food; } set { _food = value; } }
    public int Tree { get { return _tree; } set { _tree = value; } }
    public int Iron { get { return _iron; } set { _iron = value; } }
    public int Rock { get { return _rock; } set { _rock = value; } }

}

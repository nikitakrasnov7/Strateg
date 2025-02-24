using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "RTS/Game Settings/Settings", fileName = "New Game Settings")]
public class GameSettingsSO : ScriptableObject
{
    [SerializeField] private int _enemiesCount;
    [SerializeField] private List<PlayerItemStack> _playerList;
    [SerializeField] private int _mapSize;
    

    public int EnemiesCount => _enemiesCount;
    public List<PlayerItemStack> Player => _playerList;
    public int MapSize => _mapSize;

    public void SetGameSettings(int enemies, int mapSize)
    {
        _enemiesCount = enemies;
        _mapSize = mapSize;
    }

    public void Clear()
    {
        _enemiesCount = -1;
        _playerList.Clear();
        _mapSize = -1;
    }

    public void Add(Player item, int count =1)
    {
        if(count <=0) return;
        _playerList.Add(new PlayerItemStack(item));
    }


}

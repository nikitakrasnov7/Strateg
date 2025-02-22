using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GameInitializer : MonoBehaviour
{
    public GameSettingsSO GameSettingsSO;
    public Terrain Terrain;
    public NavMeshSurface Surface;

    private void Start()
    {
        SetMapArea();
    }

    private void OnDisable()
    {
        GameSettingsSO.Clear();
    }

    private void SetMapArea()
    {
        Terrain.terrainData.size = new Vector3(GameSettingsSO.MapSize * 2, 10, GameSettingsSO.MapSize * 2);
        Surface.BuildNavMesh();
        
    }
}

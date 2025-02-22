using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationMap : MonoBehaviour
{

    public GameObject Rock;
    public GameObject Tree;
    public GameObject TownPlayer;

    public Transform parent;
    public GameSettingsSO gameSettings;

    private int _terrainSize;

    private Vector3 _center;
    private Vector3[] corners = new Vector3[4];


    private void OnEnable()
    {
        _terrainSize = gameSettings.MapSize * 2;

        _center = new Vector3(_terrainSize / 2,0, _terrainSize / 2);

        corners = new[]
        {
            Vector3.zero,
            new Vector3(0,0,_terrainSize),
            new Vector3(_terrainSize,0,0),
            new Vector3(_terrainSize,0,_terrainSize)
        };

        GenerationResouces();

    }
    void GenerationResouces()
    {
        for (int x = 0; x < _terrainSize; x++)
        {
            for (int y = 0; y < _terrainSize; y++)
            {
                float xCoord = (float)x / _terrainSize * 40;
                float yCoord = (float)y / _terrainSize * 40;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                if (sample > 0.8f)
                {
                    Vector3 position = new Vector3(x, 0, y);
                    GameObject resourcePref = (sample > 0.85f) ? Rock : Tree;
                    Instantiate(resourcePref, position, Quaternion.identity, parent);
                }
            }
        }
    }
}

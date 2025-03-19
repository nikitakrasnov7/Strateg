using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GenerationMap : MonoBehaviour
{

    public GameObject Rock;
    public GameObject Tree;
    public GameObject TownPlayer;

    public Transform parent;
    public GameSettingsSO gameSettings;
    public SaveEnemyDataSO saveEnemyDataSO;

    private int _terrainSize;

    private Vector3 _center;
    private Vector3[] corners = new Vector3[4];

    public Terrain Terrain;


    private List<Vector3> _listVector = new List<Vector3>();

    [Header("Point for Spawn")]
    public List<GameObject> _listPointer = new List<GameObject>();
    public GameObject PointPlayer;
    public GameObject CameraController;

    public GameObject RightDownPoint;
    public GameObject LeftUpPoint;


    [Header("Prefab player and enemy")]
    public GameObject PrefabPlayer;
    public GameObject PrefabEnemy;



    private void OnEnable()
    {
        _terrainSize = gameSettings.MapSize * 2;

        _center = new Vector3(_terrainSize / 2, 0, _terrainSize / 2);

        corners = new[]
        {
            Vector3.zero,
            new Vector3(0,0,_terrainSize),
            new Vector3(_terrainSize,0,0),
            new Vector3(_terrainSize,0,_terrainSize)
        };



        GenerationEnemy();
        GenerationResouces();

    }

    void GenerationEnemy()
    {
        Terrain.terrainData.size = new Vector3(_terrainSize, _terrainSize, _terrainSize);

        PointPlayer.transform.position = new Vector3(_terrainSize / 10, 0, _terrainSize / 10);

        LeftUpPoint.transform.position = new Vector3(_terrainSize - 50, 0, _terrainSize - 50);
        RightDownPoint.transform.position = new Vector3(-50, 0, -50);

        _listVector.Add(new Vector3(_terrainSize / 6, 0, _terrainSize / 2));
        _listVector.Add(new Vector3(_terrainSize / 6, 0, _terrainSize * 5 / 6));

        _listVector.Add(new Vector3(_terrainSize / 2, 0, _terrainSize / 2));
        _listVector.Add(new Vector3(_terrainSize / 2, 0, _terrainSize * 5 / 6));

        _listVector.Add(new Vector3((_terrainSize / 6) * 5, 0, _terrainSize / 2));
        _listVector.Add(new Vector3((_terrainSize / 6) * 5, 0, _terrainSize * 5 / 6));

        if (PrefabPlayer != null || PointPlayer != null)
        {
            GameObject Player = Instantiate(PrefabPlayer, PointPlayer.transform.position, Quaternion.identity);
            UnitActionsControllerSO.Instance.PlayerBase = Player;

            CameraController.transform.position = new Vector3(Player.transform.position.x - 40, 0, Player.transform.position.z);
        }


        CreateEnemy();


    }


    public void CreateEnemy()
    {

        for (int i = 0; i < saveEnemyDataSO._enemyList.Count; i++)
        {
            if (_listPointer[i] != null)
            {
                if (PrefabEnemy != null)
                {
                    _listPointer[i].transform.position = _listVector[i];
                    GameObject enemy = Instantiate(PrefabEnemy, _listPointer[i].transform);
                    enemy.GetComponentInChildren<TextMeshProUGUI>().text = saveEnemyDataSO._enemyList[i];
                    enemy.GetComponentInChildren<Image>().color = saveEnemyDataSO._enemyColorList[i];
                }

            }
        }

    }
    void GenerationResouces()
    {

        for (int x = 0; x < _terrainSize; x++)
        {
            for (int y = 0; y < _terrainSize; y++)
            {
                int constantSize = _terrainSize / 3;

                float xCoord = (float)x / _terrainSize * constantSize;
                float yCoord = (float)y / _terrainSize * constantSize;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);



                if (sample > 0.85f)
                {
                    Vector3 position = new Vector3(x, 0, y);
                    GameObject resourcePref = (sample > 0.9f) ? Rock : Tree;
                    Instantiate(resourcePref, position, Quaternion.identity, parent);
                }
            }
        }
    }
}


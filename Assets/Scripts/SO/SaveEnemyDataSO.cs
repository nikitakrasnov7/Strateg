using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RTS/Game Settings/Enemy Data", fileName = "Enemy Data")]
public class SaveEnemyDataSO : ScriptableObject
{


    public List<string> _enemyList;
    public List<Color> _enemyColorList;


}

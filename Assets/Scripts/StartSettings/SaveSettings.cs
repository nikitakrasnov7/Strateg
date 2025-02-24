using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    public TMP_InputField MapSize;
    public TMP_Dropdown CountEnemy;
    public GameSettingsSO GameSettingsSO;

    public void SaveInformation()
    {
        int size = int.Parse(MapSize.text);
        int count = int.Parse(CountEnemy.value.ToString());
        GameSettingsSO.SetGameSettings(count+1, size);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DownInventoryManager : MonoBehaviour
{
    private static DownInventoryManager _inst;

    public static DownInventoryManager Instance
    {
        get
        {
            if (_inst == null)
            {
                _inst = GameObject.FindAnyObjectByType<DownInventoryManager>();
            }
            return _inst;
        }
    }
    private void Awake()
    {
        if (_inst == null)
        {
            _inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActiveTrue()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);  
    }

    public void ActiveFalse()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}

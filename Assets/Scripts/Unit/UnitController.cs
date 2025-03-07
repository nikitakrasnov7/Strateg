using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Unit unit;

    public string Name;
    public float hp;
    public float speed;
    public List<ResourseCost> resource;
    public float zonaActive;

    bool _isGoing;
    private void Update()
    {
        if (_isGoing)
        {

            GoingToPlayerPosition();
        }
    }

    public void GoingToPlayerPosition()
    {

    }

    public void GoingActiveToggle()
    {
        _isGoing = !_isGoing;
    }





}

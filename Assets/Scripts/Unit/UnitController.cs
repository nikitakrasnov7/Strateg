using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour
{
    public InformationUnitSO InformationUnit;
    public Unit unit;

    public Sprite Icon;
    public string Name;
    public float hp = 100f;
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

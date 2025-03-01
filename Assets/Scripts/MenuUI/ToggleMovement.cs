using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMovement : MonoBehaviour
{
    public Image Stop;

    public void ToggleMove()
    {
        UnitActionsControllerSO.Instance.IsMove = !UnitActionsControllerSO.Instance.IsMove;
        Stop.gameObject.SetActive(!UnitActionsControllerSO.Instance.IsMove);
    }
}

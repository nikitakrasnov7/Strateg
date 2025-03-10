using UnityEngine;

public class FIghters : UnitController
{
    public float MinDistationForAttack;
    public float MaxDistationForAttack;
    public float TimeDelayAttack;
    public float Damage;

    public bool isAttack = false;

    private void Update()
    {
        if(isAttack)
        {
            Debug.Log(UnitActionsControllerSO.Instance.RayHitObject.name);
        }
    }



}

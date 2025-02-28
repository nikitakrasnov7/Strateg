using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArmUnit : MonoBehaviour

{
   public UnitActionsControllerSO UnitActionsControllerSO;
   


    IEnumerator Move(Transform target, Vector3 dir)
    {
        while(Vector3.Distance(target.position, dir) > 0.1f)
        {
            target.position = Vector3.MoveTowards(target.position, dir, 10f * Time.fixedDeltaTime);
            yield return null;
        }
        target.position = dir;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "Terrain")
                    {
                        GameObject vat = UnitActionsControllerSO.Unit;
                        Vector3 ray2 = Camera.main.ScreenToWorldPoint(touch.position);

                        Debug.Log("точки касания " + hit.transform.position);
                        Debug.Log("точки игрока" +vat.transform.position);
                        Debug.Log("точки ray2" +ray2);

                        Vector3 poi = hit.point;
                        StartCoroutine(Move(vat.transform, poi));
                        //vat.transform.position = hit.point * 10f * Time.fixedDeltaTime;
                            
                            

                    }
                }
            }
        }
    }
}

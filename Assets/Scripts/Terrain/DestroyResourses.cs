using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyResourses : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree" || other.tag == "Rock")
        { Destroy(other.gameObject); }


    }
    private void OnTriggerStay(Collider other)
    {

        List<GameObject> gameObjects = new List<GameObject>();
        if (other.tag == "Tree" || other.tag == "Rock")
        { gameObjects.Add(other.gameObject); }
        if (gameObjects.Count == 0)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.transform.tag);
    //}
}

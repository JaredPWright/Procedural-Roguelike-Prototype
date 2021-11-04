using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroyer : MonoBehaviour
{
    private float radius;
    private Collider coll;
    private Collider[] hits;

    private int hitCount = 0;
   

    public void DoorDestruction()
    {
        coll = GetComponent<MeshCollider>();

        if(coll.bounds.extents.x > coll.bounds.extents.z)
        {
            radius = coll.bounds.extents.x / 4f;
        }else
        {
            radius = coll.bounds.extents.z / 4f;
        }

        hits = Physics.OverlapSphere(coll.bounds.center, radius);
        foreach(var intersections in hits)
        {
            if(coll == intersections)
            {
                continue;
            }

            if(intersections.gameObject.tag == "Door")
            {
                hitCount++;
            }
        }
        // float bogus = 0.0f;
        // Vector3 bogusVector = new Vector3();
        //!Physics.ComputePenetration(coll, coll.bounds.center, coll.gameObject.transform.rotation, intersections, intersections.bounds.center, intersections.gameObject.transform.rotation, out bogusVector, out bogus)

        if(hitCount <= 0)
        {
            GameObject rubblePile = new GameObject();
            rubblePile.name = "RubblePile";
            rubblePile.transform.position = this.transform.position;

            Destroy(coll.gameObject);
        }
        //}
    }
}

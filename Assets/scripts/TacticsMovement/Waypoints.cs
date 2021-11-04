using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("Make this the length of the side that the origin is on:")]
    public float xModuleLength = 10f;
    [Header("Make this the other side:")]
    public float zModuleWidth = 10f;
    public float xTileLength = 1f;
    public float zTileWidth = 1f;
    private float waypointIncrementX = 1f;
    private float waypointIncrementZ = 1f;
    private Vector3 startLocation;

    private GameObject waypoint;

    private int waypointNumber = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        waypointIncrementX = (xModuleLength / xTileLength) /xModuleLength;
        waypointIncrementZ = (zModuleWidth / zTileWidth) /zModuleWidth;

        waypoint = new GameObject();
        waypoint.name = "Waypoint Explorer";

        waypoint.transform.position = new Vector3(100000f, 100000f, 100000f);

        IEnumerator wayMaker = WayMaker(xModuleLength, zModuleWidth, waypointIncrementX, waypointIncrementZ);

        StartCoroutine(wayMaker);

        yield return new WaitForSeconds(0.0f);
    }

    

    IEnumerator WayMaker(float x, float z, float scaleX, float scaleZ)
    {
        yield return new WaitForSeconds(3.5f);

        startLocation = transform.localPosition;

        if(this.gameObject.tag == "SpawnRoom")
        {
            startLocation.z = -(zModuleWidth /2f);
        }

        startLocation.x = (-xModuleLength / 2) + (xTileLength / 2);
        startLocation.z -= (zTileWidth / 2);

        Vector3 adjustment = startLocation;
        
        for(int i = 0; i < x; i++)
        {
            GameObject waypointHolders = new GameObject();
            waypointHolders.name = "Column" + i.ToString();
            for (int j = 0; j < z; j++)
            {
                //adjustment = transform.InverseTransformPoint(adjustment);
                GameObject tempPoint = Instantiate(waypoint, adjustment, Quaternion.identity, this.transform);
                tempPoint.name = "Waypoint" + waypointNumber.ToString();
                adjustment.z -= scaleZ;

                tempPoint.transform.parent = waypointHolders.transform;

                waypointHolders.transform.parent = this.transform;

                waypointNumber++;
            }

            adjustment.x += scaleX;
            adjustment.z = startLocation.z;
        }

        Destroy(waypoint.gameObject);
    }
}

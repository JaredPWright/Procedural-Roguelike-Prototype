using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using SpecialMidshipmanDataTypes;

public class PlatformPropogatorScript : MonoBehaviour
{
    public enum PlatformType {Type1, Type2, Type3, Type4};
    public PlatformType platformType;

    public int personalID;
    public int valenceID;

    public float myRotation;

    public DungeonTileStorageCloset storageCloset;
    public Dungeon dungeon;
    public GrandMason beginCon;

    public Transform[] doorPosition;

    void Awake()
    {
        storageCloset = GameObject.Find("Custodes").GetComponent<DungeonTileStorageCloset>();
        beginCon = GameObject.Find("Custodes").GetComponent<GrandMason>();
        dungeon = GameObject.Find("Custodes").GetComponent<Dungeon>();

        personalID = dungeon.numberOfRooms;
        this.name = "Room " + personalID.ToString();
        valenceID = beginCon.valenceLevel;
        dungeon.numberOfRooms++;
    }

    public void BuildGeneration()
    {
        GameObject tempObject;

        switch(platformType)
        {
            case PlatformType.Type1:
            {
                if(this.gameObject.tag == "SpawnRoom")
                {
                    foreach(Transform i in doorPosition)
                    {
                        Quaternion quat = Quaternion.Inverse(i.rotation.normalized);

                        myRotation = quat.y;
                        
                        if(Mathf.Approximately(quat.y, 180.0f) || Mathf.Approximately(quat.y, -180.0f))
                        {
                            Debug.Log("Turning back to default rot");
                            quat = new Quaternion(0f, 0f, 0f, 0f);
                        }
                        
                        if(myRotation == 0.0f)
                        {
                            quat.y = 180.0f;
                        }
                        
                        Vector3 setLoc = i.position;
                        setLoc.y += .25f;

                        tempObject = Instantiate(storageCloset.SortTheBins(1, 2, 3, 4), setLoc, quat, beginCon.shellParent.transform);
                        tempObject.transform.position = Vector3Int.RoundToInt(tempObject.transform.position);
                        
                        Vector3 tempPos = tempObject.transform.position;
                        tempPos.x += Mathf.Epsilon;
                        tempPos.z += Mathf.Epsilon;

                        tempObject.transform.position = tempPos;

                        dungeon.Layout.Add(tempObject);

                        i.gameObject.GetComponent<DoorDestroyer>().DoorDestruction();
                    }
                    break;
                }else{break;}
            }
            case PlatformType.Type2:
            {
                foreach(Transform i in doorPosition)
                {
                    Quaternion quat = Quaternion.Inverse(i.rotation.normalized);

                    myRotation = quat.y;
                    
                    if(Mathf.Approximately(quat.y, 180.0f) || Mathf.Approximately(quat.y, -180.0f))
                    {
                        Debug.Log("Turning back to default rot");
                        quat = new Quaternion(0f, 0f, 0f, 0f);
                    }
                    
                    if(myRotation == 0.0f)
                    {
                        quat.y = 180.0f;
                    }

                    Vector3 setLoc = i.position;
                    setLoc.y += .25f;

                    tempObject = Instantiate(storageCloset.SortTheBins(1, 2, 3, 4), setLoc, quat, beginCon.shellParent.transform);
                    tempObject.transform.position = Vector3Int.RoundToInt(tempObject.transform.position);

                    Vector3 tempPos = tempObject.transform.position;
                    tempPos.x += Mathf.Epsilon;
                    tempPos.z += Mathf.Epsilon;

                    tempObject.transform.position = tempPos;

                    dungeon.Layout.Add(tempObject);

                    i.gameObject.GetComponent<DoorDestroyer>().DoorDestruction();
                }

                break;
            }
            case PlatformType.Type3:
            {
                foreach(Transform i  in doorPosition)
                {
                   Quaternion quat = Quaternion.Inverse(i.rotation.normalized);

                   myRotation = quat.y;
                    
                    if(Mathf.Approximately(quat.y, 180.0f) || Mathf.Approximately(quat.y, -180.0f))
                    {
                        Debug.Log("Turning back to default rot");
                        quat = new Quaternion(0f, 0f, 0f, 0f);
                    }
                    
                    if(myRotation == 0.0f)
                    {
                        quat.y = 180.0f;
                    }
                
                    Vector3 setLoc = i.position;
                    setLoc.y += .25f;

                    tempObject = Instantiate(storageCloset.SortTheBins(1, 2, 3, 4), setLoc, quat, beginCon.shellParent.transform);
                    tempObject.transform.position = Vector3Int.RoundToInt(tempObject.transform.position);

                    Vector3 tempPos = tempObject.transform.position;
                    tempPos.x += Mathf.Epsilon;
                    tempPos.z += Mathf.Epsilon;

                    tempObject.transform.position = tempPos;
                    
                    dungeon.Layout.Add(tempObject);

                    i.gameObject.GetComponent<DoorDestroyer>().DoorDestruction();
                }

                break;
            }
            case PlatformType.Type4:
            {
                foreach(Transform i  in doorPosition)
                {
                    Quaternion quat = Quaternion.Inverse(i.rotation.normalized);

                    myRotation = quat.y;
                        
                        if(Mathf.Approximately(quat.y, 180.0f) || Mathf.Approximately(quat.y, -180.0f))
                        {
                            Debug.Log("Turning back to default rot");
                            quat = new Quaternion(0f, 0f, 0f, 0f);
                        }
                        
                        if(myRotation == 0.0f)
                        {
                            quat.y = 180.0f;
                        }
                        
                    Vector3 setLoc = i.position;
                    setLoc.y -= .25f;

                    tempObject = Instantiate(storageCloset.SortTheBins(1, 2, 3, 4), setLoc, quat, beginCon.shellParent.transform);
                    tempObject.transform.position = Vector3Int.RoundToInt(tempObject.transform.position);

                    Vector3 tempPos = tempObject.transform.position;
                    tempPos.x += Mathf.Epsilon;
                    tempPos.z += Mathf.Epsilon;

                    tempObject.transform.position = tempPos;
                    
                    dungeon.Layout.Add(tempObject);

                    i.gameObject.GetComponent<DoorDestroyer>().DoorDestruction();
                }
                break;
            }
            default:
            {
                break;
            }
        }
    }
}
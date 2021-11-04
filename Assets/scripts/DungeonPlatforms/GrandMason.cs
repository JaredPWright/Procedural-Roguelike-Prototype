using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpecialMidshipmanDataTypes;

public class GrandMason : MonoBehaviour
{
    public bool runningBuildRoutine = false;

    private Dungeon dungeon;
    private DungeonTileStorageCloset tileStorage;
    
    public int valenceLevel = 0;
    public int valenceBuild = -1;
    public GameObject shellParent;

    IEnumerator Start()
    {
        GameObject testCase = new GameObject();
        testCase.name = "Father of the Lost";

        GameObject allFather = new GameObject();
        allFather.name = "Allfather";

        dungeon = GameObject.Find("Custodes").GetComponent<Dungeon>();
        tileStorage = GameObject.Find("Custodes").GetComponent<DungeonTileStorageCloset>();

        GameObject spawnRoom;
        spawnRoom = Instantiate(tileStorage.TileBin5[IntRandomizer.IntRandom(0, 3)]);
        dungeon.Layout.Add(spawnRoom);

        int layoutListLength;

        for(int i = 0; i <= dungeon.dungeonLevel; i++)
        {
            Debug.Log("Entering " + i.ToString() + " iteration of 'i' loop");
            layoutListLength = dungeon.Layout.Count;
            //Debug.Log("Layout list length: " + layoutListLength.ToString());
            PlatformPropogatorScript propogatorScript;

            shellParent = new GameObject();
            shellParent.name = "ShellParent" + valenceLevel.ToString();

            for(int j = 0; j < layoutListLength; j++)
            {
                if(dungeon.Layout[j].name != "One Untimely Born")
                {
                    //Debug.Log("Entering " + j.ToString() + " iteration of 'j' loop, i-loop " + i.ToString());
                    propogatorScript = dungeon.Layout[j].GetComponent<PlatformPropogatorScript>();
                    //Debug.Log("Valence Level: " + valenceLevel.ToString());
                    //Debug.Log("Room: " + dungeon.Layout[j].name);

                    if (propogatorScript.valenceID == valenceBuild)
                    {
                        propogatorScript.BuildGeneration();
                    }

                    for(int k = 0; k < dungeon.Layout.Count; k++)
                    {
                        Collider tempObj1Coll;
                        Renderer tempObj1Rend;
                        //Vector3 vect3_1;
                        int room1ID;

                        if(dungeon.Layout[k].name != "One Untimely Born")
                        {
                            //Debug.Log("Entering " + k.ToString() + " iteration of 'k' loop, j-loop " + j.ToString() + ", i-loop " + i.ToString());
                            tempObj1Coll = dungeon.Layout[k].GetComponent<MeshCollider>();
                            tempObj1Rend = dungeon.Layout[k].GetComponent<Renderer>();
                            room1ID = dungeon.Layout[k].GetComponent<PlatformPropogatorScript>().personalID;
                            // vect3_1 = transform.TransformPoint(tempObj1Coll.bounds.center);
                            // vect3_1.y = 0f;
                        }
                        else{room1ID = 0; tempObj1Coll = null; tempObj1Rend = null;}

                        yield return new WaitForSeconds(3f);

                        for(int l = 0; l < dungeon.Layout.Count; l++)
                        {
                            //Vector3 vect3_2;
                            int room2ID;
                            GameObject temporaryObj;
                            Renderer tempObj2Rend;

                            if(dungeon.Layout[l].name != "One Untimely Born")
                            {
                                //Debug.Log("Entering " + l.ToString() + " iteration of 'l' loop, k-loop " + k.ToString() + ", j-loop " + j.ToString() + ", i-loop " + i.ToString());
                                room2ID = dungeon.Layout[l].GetComponent<PlatformPropogatorScript>().personalID;
                                tempObj2Rend = dungeon.Layout[l].GetComponent<Renderer>();

                                if((dungeon.Layout[k] != dungeon.Layout[l]) && ((dungeon.Layout[k].name != "One Untimely Born") && (dungeon.Layout[l].name != "One Untimely Born")))
                                {
                                    //Debug.Log(dungeon.Layout[l].name + " " + dungeon.Layout[k].name);
                                    
                                    float radius;

                                    if(tempObj1Coll.bounds.extents.x > tempObj1Coll.bounds.extents.z)
                                    {
                                        radius = tempObj1Coll.bounds.extents.x / 1.5f;
                                    }else
                                    {
                                        radius = tempObj1Coll.bounds.extents.z / 1.5f;
                                    }

                                    Collider[] hits = Physics.OverlapSphere(tempObj1Coll.bounds.center, radius);
                                    foreach(var intersections in hits)
                                    {
                                        if(tempObj1Coll == intersections || tempObj1Coll.gameObject.CompareTag("Door"))
                                            continue;

                                        float bogus = 0.0f;
                                        Vector3 bogusVector = new Vector3();
                                        bool check = Physics.ComputePenetration(tempObj1Coll, tempObj1Rend.bounds.center, dungeon.Layout[k].transform.rotation, intersections, tempObj2Rend.bounds.center, dungeon.Layout[l].transform.rotation, out bogusVector, out bogus);

                                        if(check)
                                        {
                                            if(room1ID < room2ID)
                                            {
                                                Debug.Log("Destroying an overlapper");
                                                
                                                yield return new WaitForSeconds(3f);
                                                Destroy(dungeon.Layout[l]);
                                                temporaryObj = new GameObject();
                                                temporaryObj.name = "One Untimely Born";
                                                temporaryObj.transform.parent = testCase.transform;

                                                dungeon.Layout[l] = temporaryObj;
                                            }
                                        }
                                    }
                                }
                            }
                            else{room2ID = 0;}
                        }
                    }
                }
            }
            valenceBuild++;
            valenceLevel++;
        }

        for(int p = 0; p < valenceLevel; p++)
        {
            GameObject.Find("ShellParent" + p.ToString()).transform.parent = allFather.transform;
        }

        Debug.Log("Finished building");
    }
}

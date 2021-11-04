using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using SpecialMidshipmanDataTypes;

public class Dungeon : MonoBehaviour
{
    public int numberOfRooms = 0;
    public int dungeonLevel = 1;

    public List<GameObject> Layout = new List<GameObject>();

    public  List<GameObject> Enemies = new List<GameObject>();

    public  List<GameObject> Treasure = new List<GameObject>();

    public  List<GameObject> Clutter = new List<GameObject>();

    void Update()
    {
        numberOfRooms = Layout.Count;
    }
}
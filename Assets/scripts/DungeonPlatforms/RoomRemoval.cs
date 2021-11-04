using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRemoval : MonoBehaviour
{
    public enum Mark{Marked, Unmarked};
    private PlatformPropogatorScript buddyChecker, selfChecker;
    private Dungeon dungeon;
    
    private BoxCollider myCollider;

    public Mark mark = Mark.Unmarked;
    //public bool markedForDestruction = false;

    int myID, buddyID;

    // void Awake()
    // {
    //     this.enabled = false;
    // }

    void Start()
    {
        selfChecker = GetComponent<PlatformPropogatorScript>();
        dungeon = GameObject.Find("Custodes").GetComponent<Dungeon>();
        myID = selfChecker.personalID;
        myCollider = GetComponent<BoxCollider>();
    }
    

    void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.tag == "Room")
        // {
        //     buddyChecker = other.gameObject.GetComponent<PlatformPropogatorScript>();
        //     buddyID = buddyChecker.personalID;

        //     BoxCollider otherCollider = other.gameObject.GetComponent<BoxCollider>();

        //     if((myID > buddyID) && myCollider.center == otherCollider.center)
        //     {
        //         Debug.Log("About to destroy a room");
        //         Destroy(this.gameObject);
        //         //mark = Mark.Marked;
        //     }
        // }else
        // {
        //     //Debug.Log("About to destroy a room")
        //     //mark = Mark.Unmarked;
        // }
    }

    public void DestroySelf()
    {
        Debug.Log("Destroying myself");
        Destroy(this.gameObject);
    }
}

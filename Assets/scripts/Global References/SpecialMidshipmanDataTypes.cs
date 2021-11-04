using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialMidshipmanDataTypes
{
    [System.Serializable]
    public class RoomType 
    {
        public int shellLoc;
        public Vector3 worldLoc;
        public GameObject roomObject;

        public RoomType()
        {
            shellLoc = 0;
            worldLoc = new Vector3(0f, 0f, 0f);
            roomObject = null;

            return;
        }

        public RoomType(GameObject tempRoom, int shell)
        {   
            roomObject = tempRoom;
            shellLoc = shell;
            worldLoc = tempRoom.transform.position;

            Debug.Log("Returning sRoom");
            return;
        }

        
    }

    // [CreateAssetMenu(fileName = "RoomAddition", menuName = "ScriptableObjects/RoomAddition", order = 1)]
    // public class RoomAddition
    // {
    //     public static void AddRoom(GameObject tempRoom, int shell, RoomType sRoom)
    //     {
    //         //RoomType sRoom;
    //         sRoom.roomObject = tempRoom;
    //         sRoom.shellLoc = shell;
    //         sRoom.worldLoc = tempRoom.transform.position;

    //         Debug.Log("Returning sRoom");
    //     }
    // }   
}
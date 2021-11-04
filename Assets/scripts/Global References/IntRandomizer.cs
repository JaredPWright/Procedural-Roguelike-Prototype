using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntRandomizer : MonoBehaviour
{
   public static int IntRandom(int bottomVal = 0, int upperVal = 100)
    {
        int returnVal = 0;

        float floatReturnVal = Random.Range(bottomVal, upperVal);

        returnVal = (int)floatReturnVal;

        //Debug.Log(returnVal.ToString());

        return returnVal;
    }
}

using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DungeonTileStorageCloset : MonoBehaviour
{
    public GameObject[] TileBin1;
    public GameObject[] TileBin2;
    public GameObject[] TileBin3;
    public GameObject[] TileBin4;
    public GameObject[] TileBin5;

    //public GameObject[][] TileBins = new GameObject[5][];

    // void Start()
    // {
    //     LoadBins();
    // }
    // public void LoadBins()
    // {
    //     for(int i = 0; i < TileBins.Length; i++)
    //     {
    //         switch(i)
    //         {
    //             case 0:
    //             {
    //                 TileBins[i] = TileBin1;
    //                 break;
    //             }
    //             case 1:
    //             {
    //                 TileBins[i] = TileBin2;
    //                 break;
    //             }
    //             case 2:
    //             {
    //                 TileBins[i] = TileBin3;
    //                 break;
    //             }
    //             case 3:
    //             {
    //                 TileBins[i] = TileBin4;
    //                 break;
    //             }
    //             case 4:
    //             {
    //                 TileBins[i] = TileBin5;
    //                 break;
    //             }
    //             default:
    //             {
    //                 break;
    //             }
    //         }
    //     }
    // }

    public GameObject SortTheBins(int binNumber1, int binNumber2, int binNumber3, int binNumber4)
    {
        float chanceDice1 = Random.Range(0f, 25f);
        float chanceDice2 = Random.Range(26f, 50f);
        float chanceDice3 = Random.Range(51f, 75f);
        float chanceDice4 = Random.Range(76f, 100f);
        float chanceDice5 = Random.Range(0f, 99f);

        GameObject tempPlat;

        if(chanceDice5 <= chanceDice1)
        {
            tempPlat = TileBin1[IntRandomizer.IntRandom(0, (TileBin1.Length))];
        }
        else if(chanceDice5 > chanceDice1 && chanceDice5 <= chanceDice2)
        {
            tempPlat = TileBin2[IntRandomizer.IntRandom(0, (TileBin2.Length))];
        }
        else if(chanceDice5 > chanceDice2 && chanceDice5 <= chanceDice3)
        {
            tempPlat = TileBin3[IntRandomizer.IntRandom(0, (TileBin3.Length))];
        }
        else
        {
            tempPlat = TileBin4[IntRandomizer.IntRandom(0, (TileBin4.Length))];
        }

        return tempPlat;
    }
}
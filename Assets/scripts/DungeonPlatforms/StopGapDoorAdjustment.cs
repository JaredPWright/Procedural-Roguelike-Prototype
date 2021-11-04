using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGapDoorAdjustment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
    }
}

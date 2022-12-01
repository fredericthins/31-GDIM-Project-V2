using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Simple Camera Movement
public class CameraMotor : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraOffset;

    // Update is called once per frame
    void Update()
    {
    //Camera will follow the player with a selected offset. No dead zones.
        transform.position = player.position + cameraOffset;
    }
}

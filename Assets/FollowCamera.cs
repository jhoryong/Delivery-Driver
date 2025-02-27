using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // camera position should be same as the car
    [SerializeField] 
    GameObject car;
    void LateUpdate()
    {
        transform.position = car.transform.position + new Vector3(0, 0, -10);
        // transform.rotation = car.transform.rotation;
    }
}

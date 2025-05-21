using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float yOffset = 0f;
    public float zOffset = -10f;

   
    void Update()
    {
       Vector3 newPos = new Vector3(target.position.x,target.position.y +yOffset, zOffset);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}

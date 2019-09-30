using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraFollowMode
{
    None,
    FollowPlayer,
    FollowMiniGame,
    FollowMap
}
public class CameraFollowPlayer : MonoBehaviour
{

    public bool working = false;
    
    public Transform TargetObject;
    public float distanceFromObject = 6f;
   
    void Update()
    {
        if(!working && TargetObject != null)
        {
            working = true;
        }

        if (!working)
            return;

        transform.position = Vector3.Lerp(transform.position, TargetObject.position,Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetObject.rotation, Time.deltaTime);
    }

    Vector3 MovePosition(Transform Target)
    {
        Vector3 lookOnObject = Target.position - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 TargetLastPosition = Target.position - lookOnObject.normalized * distanceFromObject;
        TargetLastPosition.y = Target.position.y + distanceFromObject / 2;
        return TargetLastPosition;
    }

    public void SetTargetCamera(Transform trans)
    {
        TargetObject = trans;
    }
    
    
}

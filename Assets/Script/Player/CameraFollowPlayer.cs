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
public enum StateCamera
{
    GameManager,
    MiniGame,
    Puzzle
}
public class CameraFollowPlayer : MonoBehaviour
{

    public bool working = false;
    public int speed = 1;
    public Transform TargetObject;
    public float distanceFromObject = 6f;
    public StateCamera state;
    Transform temptrans;

    void Update()
    {
        if(!working && TargetObject != null)
        {
            working = true;
        }

        if (!working)
            return;

        transform.position = Vector3.Lerp(transform.position, TargetObject.position,Time.deltaTime* speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetObject.rotation, Time.deltaTime* speed);
        float dis = Vector3.Distance(transform.position, TargetObject.position);
        if (temptrans != TargetObject && dis <= 1.0f)
        {
            temptrans = TargetObject;
            SceneManagement.GetInstance().VisibleBackButton(true);
        }
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
    
    public void SetStateCamera(StateCamera newstate)
    {
        state = newstate;
    }
    
}

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
    
    public CameraFollowMode CameraMode = CameraFollowMode.None ;
    public bool working = false;

    public Transform TargetObject;
    public Transform playerObject;
    public Transform MiniGameObject;
    public GameObject TrackerPlayer;
    public float distanceFromObject = 6f;
   
   
    void Update()
    {

        if (!working && TrackerPlayer != null && CameraMode == CameraFollowMode.None) {
            TrackerPlayer.transform.position = Vector3.Lerp(MovePosition(playerObject), TrackerPlayer.transform.position, Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, TrackerPlayer.transform.position, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, TrackerPlayer.transform.rotation, Time.deltaTime) ;
            if (Vector3.Distance(transform.position,TrackerPlayer.transform.position) < 0.1f)
            {
                CameraMode = CameraFollowMode.FollowPlayer;
                working = true;
            }

            return;
        }

        if (!working)
            return;


        switch (CameraMode)
        {
            case CameraFollowMode.None: working = false; break;
            case CameraFollowMode.FollowPlayer:
                TargetObject = playerObject;
                transform.position = Vector3.Lerp(MovePosition(TargetObject), TrackerPlayer.transform.position, Time.deltaTime);
                break;
            case CameraFollowMode.FollowMiniGame:
                TargetObject = MiniGameObject;
                transform.position = Vector3.Lerp(transform.position, TargetObject.position,Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, TargetObject.rotation, Time.deltaTime);
                break;
            case CameraFollowMode.FollowMap: working = false; break;
            default: break;
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
    public void SetupCamera(Transform tranformplayer, GameObject Track)
    {
        playerObject = tranformplayer;
        TrackerPlayer = Track;
        //TrackerPlayer.transform.position = MovePosition(playerObject);
    }

    public void ChangeCameraMode(CameraFollowMode Mode)
    {
        CameraMode = Mode;
    }
    public void SetTargetMode(CameraFollowMode Mode , Transform Target)
    {
        switch (Mode){
            case CameraFollowMode.FollowPlayer:  playerObject = Target; break;
            case CameraFollowMode.FollowMiniGame:  MiniGameObject = Target; break;
            case CameraFollowMode.FollowMap: ; break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    bool Starting = false;
    public Transform playerObject;
    public GameObject TrackerPlayer;
    public float distanceFromObject = 6f;
    public void SetupCamera(Transform tranformplayer , GameObject Track)
    {
        playerObject = tranformplayer;
        TrackerPlayer = Track;
        Vector3 lookOnObject = playerObject.position - transform.position;
        lookOnObject = playerObject.position - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 playerLastPosition;
        playerLastPosition = playerObject.position - lookOnObject.normalized * distanceFromObject;
        playerLastPosition.y = playerObject.position.y + distanceFromObject / 2;
        TrackerPlayer.transform.position = playerLastPosition;
    }
    void Update()
    {
        if (!Starting && TrackerPlayer != null){
            transform.position = Vector3.Slerp(transform.position, TrackerPlayer.transform.position, Time.deltaTime);
            if (Vector3.Distance(transform.position,TrackerPlayer.transform.position) < 1)
            {
                Starting = true;
            }

            return;
        }

        if (!Starting)
            return;

        Vector3 lookOnObject = playerObject.position - transform.position;
        lookOnObject = playerObject.position - transform.position;
        transform.forward = lookOnObject.normalized;
        Vector3 playerLastPosition;
        playerLastPosition = playerObject.position - lookOnObject.normalized * distanceFromObject;
        playerLastPosition.y = playerObject.position.y + distanceFromObject / 2;
        transform.position = Vector3.Slerp(playerLastPosition, TrackerPlayer.transform.position, Time.deltaTime);
    }
    
}

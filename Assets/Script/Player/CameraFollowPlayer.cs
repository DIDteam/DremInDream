﻿using System.Collections;
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
    public GameObject RootCamera;
    Transform temptrans;
    Quaternion MovetoCamera ;
    Quaternion TempMove;
    void Start()
    {
        RootCamera = GameObject.Find("RootCamera").gameObject;
    }
    void Update()
    {
        if (!working)
            return;

        RootCamera.transform.rotation = Quaternion.Lerp(RootCamera.transform.rotation, MovetoCamera, Time.deltaTime * speed);
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
    
    public void SetStateCamera(Quaternion newRotation)
    {
        working = (MovetoCamera != newRotation);
        Debug.Log(working);
        MovetoCamera = newRotation;
        TempMove = MovetoCamera;
    }
    public void SetCameraPuzzle()
    {
        MovetoCamera = Quaternion.Euler(new Vector3(-35,0,0));
        working = true;
    }
}

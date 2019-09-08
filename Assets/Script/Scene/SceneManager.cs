using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public PlayerStartPoint playerstartpoint;
    public CameraFollowPlayer Camera;
    public GameObject player;
    public bool GameRunning = false;
    public bool GamePause = false;
    void Start()
    {
        playerstartpoint = GameObject.Find("PlayerStartPoint").GetComponent<PlayerStartPoint>();
        Camera = GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>();
        playerstartpoint.SpawnPlayer();
        player = playerstartpoint.player;
        StartCoroutine(SetupGame());
       
    }

    // Update is called once per frame
    void Update()
    {


    }
    
    IEnumerator SetupGame()
    {
     
        yield return new WaitForSeconds(2.0f);
        Camera.SetupCamera(player.transform, player.GetComponent<PlayerController>().Tracker);
        GameRunning = true;
    }
}

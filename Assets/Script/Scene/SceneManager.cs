using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public PlayerStartPoint playerstartpoint;
    public CameraFollowPlayer CameraPlayer;
    public GameObject player;
    public SaveData PlayerData;
    public bool GameRunning = false;
    public bool MiniGameActive = false;
    public bool GamePause = false;
    public bool CanClick =false;
    void Start()
    {
        PlayerData = SaveSystem.LoadSaveGame();
        playerstartpoint = GameObject.Find("PlayerStartPoint").GetComponent<PlayerStartPoint>();
        CameraPlayer = GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>();
        playerstartpoint.SpawnPlayer();
        player = playerstartpoint.player;
        StartCoroutine(SetupGame());
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameRunning)
            return;

        MiniGameEvent();
        
        


    }

    private void MiniGameEvent()
    {
        if (MiniGameActive && Input.GetKeyDown(KeyCode.Escape))
        {
            player.SetActive(true);
            MiniGameActive = false;
            CameraPlayer.ChangeCameraMode(CameraFollowMode.FollowPlayer);
        }

        if (MiniGameActive && CanClick && Input.GetMouseButtonDown(0))
        {
            CanClick = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                ItemInteractiveGame Item = hit.transform.gameObject.GetComponent<ItemInteractiveGame>();
                if (Item){
                    Debug.Log("You selected the " + Item.GameData.Name);
                    PlayerData.Inventory.Add(Item.ID_Item);
                    Destroy(Item.gameObject);
                }
                //hit.transform.position += Vector3.right * speed * Time.deltaTime; // << declare public speed and set it in inspector
            }
        }
        else if (MiniGameActive && !CanClick && Input.GetMouseButtonUp(0))
            CanClick = true;
    }

    static public SceneManager GetInstance()
    {
        return (SceneManager)FindObjectOfType(typeof(SceneManager));
    }
    IEnumerator SetupGame()
    {
     
        yield return new WaitForSeconds(2.0f);
        CameraPlayer.SetupCamera(player.transform, player.GetComponent<PlayerController>().Tracker);
        GameRunning = true;
    }

}

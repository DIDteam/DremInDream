using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    //public PlayerStartPoint playerstartpoint;
    private LayerMask LayerItem;
    public Transform FirstFocus;
    public CameraFollowPlayer CameraPlayer;
    //public GameObject player; 

    public int CurrentMiniGame = 0;
    public GameManagement GameManager;
    
    
    public SaveData PlayerData;

    public bool GameRunning = false;
    //public bool MiniGameActive = false;
    public bool GamePause = false;
    public bool CanClick =false;

    void Start()
    {
        PlayerData = SaveSystem.LoadSaveGame();
        //playerstartpoint = GameObject.Find("PlayerStartPoint").GetComponent<PlayerStartPoint>();
        //FirstFocus = GameObject.Find("FirstFocusCamera").GetComponent<Transform>();
        CameraPlayer = GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>();
        GameManager = GameManagement.GetInstance();
        //playerstartpoint.SpawnPlayer();
        //player = playerstartpoint.player;
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
        if (CanClick && Input.GetMouseButtonDown(0))
        {
            CanClick = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                
                Debug.DrawRay(transform.position, hit.point , Color.green);
                Debug.Log(hit.transform.gameObject);
                ItemInteractiveGame Item = hit.transform.gameObject.GetComponent<ItemInteractiveGame>();
                if (Item){
                    
                    Debug.Log("You selected the " + Item.GameData.Name);
                    PlayerData.Inventory.Add(Item.ID_Item);
                    Destroy(Item.gameObject);
                }
                //hit.transform.position += Vector3.right * speed * Time.deltaTime; // << declare public speed and set it in inspector
            }
        }
        else if (!CanClick && Input.GetMouseButtonUp(0))
            CanClick = true;
    }

    static public SceneManagement GetInstance()
    {
        return (SceneManagement)FindObjectOfType(typeof(SceneManagement));
    }
    IEnumerator SetupGame()
    {
        yield return new WaitForSeconds(2.0f);
        CameraPlayer.SetTargetCamera(GameManager.ListGame[CurrentMiniGame].TrckerCamera.transform);
        GameRunning = true;
    }

    public void LeftButton()
    {
        CameraPlayer.distanceFromObject = 50.0f;
        CurrentMiniGame--;
        CurrentMiniGame = Mathf.Clamp(CurrentMiniGame,0,GameManager.ListGame.Count-1);
        CameraPlayer.SetTargetCamera(GameManager.ListGame[CurrentMiniGame].TrckerCamera.transform);
    }

    public void RightButton()
    {
        CameraPlayer.distanceFromObject = 6.0f;
        CurrentMiniGame++;
        CurrentMiniGame = Mathf.Clamp(CurrentMiniGame,0,GameManager.ListGame.Count-1);
        CameraPlayer.SetTargetCamera(GameManager.ListGame[CurrentMiniGame].TrckerCamera.transform);
    }
}

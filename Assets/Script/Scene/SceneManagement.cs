using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    //public PlayerStartPoint playerstartpoint;
    private LayerMask LayerItem;
    public GameObject BackButton_UI;
    public Transform FirstFocus;
    public CameraFollowPlayer CameraPlayer;
    //public GameObject player; 
    public MiniGameTracker CurrentMiniGame ;
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
                //sDebug.Log(hit.transform.gameObject);
                GameObject obj = hit.transform.gameObject;

                if (obj.GetComponent<ItemInteractiveGame>() && CameraPlayer.state == StateCamera.MiniGame)
                {
                    ItemInteractiveGame item = obj.GetComponent<ItemInteractiveGame>();
                    KeepItemtoInventory(item);
                    FindItemManager.GetInstance().UpdateFindItem(item.ID_Item);
                }
                else if (obj.GetComponent<MiniGameTracker>() )
                {
                    
                    if (CameraPlayer.state == StateCamera.GameManager)
                    {
                        CurrentMiniGame = obj.GetComponent<MiniGameTracker>();
                        GameManagement.GetInstance().MainCollisionActive(false);
                        CameraPlayer.SetStateCamera(StateCamera.MiniGame);
                        CameraPlayer.SetTargetCamera(obj.GetComponent<MiniGameTracker>().TrckerCamera.transform);
                    }
                    else if(CameraPlayer.state == StateCamera.MiniGame)
                    {
                        CurrentMiniGame = obj.GetComponent<MiniGameTracker>();

                        //if (CurrentMiniGame.NextStepCamera.Length > 1)
                        //    GameManagement.GetInstance().SubCollisionActive(true);
                        //else
                        //    GameManagement.GetInstance().SubCollisionActive(false);

                        CameraPlayer.SetStateCamera(StateCamera.MiniGame);
                        CameraPlayer.SetTargetCamera(CurrentMiniGame.TrckerCamera.transform);
                    }
                    FindItemManager.GetInstance().SetListFindItem(CurrentMiniGame.ListFindItems);
                    VisibleBackButton(false);
                }
                //hit.transform.position += Vector3.right * speed * Time.deltaTime; // << declare public speed and set it in inspector
            }
        }
        else if (!CanClick && Input.GetMouseButtonUp(0))
            CanClick = true;
    }

    public void KeepItemtoInventory(ItemInteractiveGame Item)
    {
        Debug.Log("You selected the " + Item.GameData.Name);
        PlayerData.Inventory.Add(Item.ID_Item);
        InventoryManager.GetInstance().AddItem(Item.ID_Item);
        Destroy(Item.gameObject);
    }

    public void DropItemformInventory(string ItemID)
    {
        Debug.Log("You Drop Item : " + ItemID);
        PlayerData.Inventory.Remove(ItemID);
        InventoryManager.GetInstance().RemoveItem(ItemID);
    }

    static public SceneManagement GetInstance()
    {
        return (SceneManagement)FindObjectOfType(typeof(SceneManagement));
    }
    IEnumerator SetupGame()
    {
        yield return new WaitForSeconds(2.0f);
        CameraPlayer.SetTargetCamera(GameManager.transform);
        GameRunning = true;
    }

    public void VisibleBackButton(bool v)
    {
        if (CameraPlayer.state != StateCamera.GameManager)
        {
            BackButton_UI.GetComponent<Button>().interactable = v;
            BackButton_UI.SetActive(v);
        }
    }
    public void BackButton()
    {
        
        VisibleBackButton(false);
        if (CameraPlayer.state == StateCamera.MiniGame)
        {
            if (CurrentMiniGame.BackStepCamera != null)
            {
                Debug.Log("BackButton : BackStepCamera");
                CurrentMiniGame.GetComponent<BoxCollider>().enabled = true;
                CameraPlayer.SetTargetCamera(CurrentMiniGame.BackStepCamera.TrckerCamera.transform);
                CurrentMiniGame = CurrentMiniGame.BackStepCamera;

                //if (CurrentMiniGame.NextStepCamera.Length > 1)
                //    GameManagement.GetInstance().SubCollisionActive(true);
                //else
                //    GameManagement.GetInstance().SubCollisionActive(false);
            }
            else
            {
                Debug.Log("You Drop Item : BackStepCamera null ");
                BackButton_UI.SetActive(false);
                GameManagement.GetInstance().MainCollisionActive(true);
                CameraPlayer.SetStateCamera(StateCamera.GameManager);
                CameraPlayer.SetTargetCamera(GameManager.transform);
                FindItemManager.GetInstance().DestroyListItems();
                CurrentMiniGame = null;
            }
        }
        else if (CameraPlayer.state == StateCamera.GameManager)
        {
            Debug.Log("BackButton : GameManager");
        }
    }

}

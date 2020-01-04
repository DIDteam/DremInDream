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
    public GameObject RootMap;
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
    public GameObject[] Smoke;
    Transform TempRotation;
    void Start()
    {
        PlayerData = SaveSystem.LoadSaveGame();
        //playerstartpoint = GameObject.Find("PlayerStartPoint").GetComponent<PlayerStartPoint>();
        //FirstFocus = GameObject.Find("FirstFocusCamera").GetComponent<Transform>();
        
        CameraPlayer = GameObject.Find("Main Camera").GetComponent<CameraFollowPlayer>();

        RootMap = GameObject.Find("RootMap");
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

                if (obj.GetComponent<ItemInteractiveGame>())
                {
                    ItemInteractiveGame item = obj.GetComponent<ItemInteractiveGame>();
                    KeepItemtoInventory(item);
                    FindItemManager.GetInstance().UpdateFindItem(item.ID_Item);
                    if (FindItemManager.GetInstance().FindItemAllComplete())
                    {
                        CurrentMiniGame.GetRewardItem();
                    }
                }
                else if (obj.GetComponent<MiniGameTracker>() )
                {
                    if (!obj.GetComponent<MiniGameTracker>().IsPuzzleComplete && !obj.GetComponent<MiniGameTracker>().SpawnPuzzle) {

                        Debug.Log("Puzzle Start!");
                        RootMap.SetActive(false);
                        CameraPlayer.SetCameraPuzzle();
                        UIManager.GetInstance().InventoryObject.SetActive(false);
                        SetVisibleSmoke(false);
                        obj.GetComponent<MiniGameTracker>().Puzzle.ParentMiniGame = obj;
                        obj.GetComponent<MiniGameTracker>().SpawnPuzzle = true;
                        obj.GetComponent<MiniGameTracker>().Puzzle.StartPuzzle();
                    }
                    else {
                        PuzzleComplete(obj);
                    }
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
        CurrentMiniGame = GameManager.MainListGame[0];
        GameManager.MainListGame[0].Lighting.SetActive(true);
        CameraPlayer.SetStateCamera(Quaternion.Euler(GameManager.MainListGame[0].CameraPosition));
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
            /*if (CurrentMiniGame.BackStepCamera != null)
            {
                UIManager.GetInstance().SetVisibleFindItemBar(false);
                Debug.Log("BackButton : BackStepCamera");
                CurrentMiniGame.GetComponent<BoxCollider>().enabled = true;
                CameraPlayer.SetTargetCamera(CurrentMiniGame.BackStepCamera.TrckerCamera.transform);
                CurrentMiniGame = CurrentMiniGame.BackStepCamera;
                UIManager.GetInstance().SetVisibleFindItemBar(true);
                //if (CurrentMiniGame.NextStepCamera.Length > 1)
                //    GameManagement.GetInstance().SubCollisionActive(true);
                //else
                //    GameManagement.GetInstance().SubCollisionActive(false);
            }
            else
            {
                UIManager.GetInstance().SetVisibleFindItemBar(false);
                Debug.Log("You Drop Item : BackStepCamera null ");
                BackButton_UI.SetActive(false);
                GameManagement.GetInstance().MainCollisionActive(true);
                CameraPlayer.SetStateCamera(StateCamera.GameManager);
                CameraPlayer.SetTargetCamera(GameManager.transform);
                FindItemManager.GetInstance().DestroyListItems();
                CurrentMiniGame = null;
            }*/
        }
        else if (CameraPlayer.state == StateCamera.GameManager)
        {
            Debug.Log("BackButton : GameManager");
        }
    }
 
    public void PuzzleComplete(GameObject obj)
    {
        CurrentMiniGame = obj.GetComponent<MiniGameTracker>();
        RootMap.SetActive(true);
        UIManager.GetInstance().InventoryObject.SetActive(true);
        obj.GetComponent<MiniGameTracker>().IsPuzzleComplete = true;
        SetVisibleSmoke(true);
        CurrentMiniGame.Lighting.SetActive(false);
        CurrentMiniGame = obj.GetComponent<MiniGameTracker>();
            //GameManagement.GetInstance().MainCollisionActive(false);
            
        CameraPlayer.SetStateCamera(Quaternion.Euler(CurrentMiniGame.CameraPosition));
        CameraPlayer.SetTargetCamera(obj.GetComponent<MiniGameTracker>().TrckerCamera.transform);

        UIManager.GetInstance().SetVisibleFindItemBar(true);
        VisibleBackButton(false);
        CurrentMiniGame.Lighting.SetActive(true);
        if (CurrentMiniGame.IsComplete == false)
            FindItemManager.GetInstance().SetListFindItem(CurrentMiniGame.ListFindItems);

    }

    public void SetVisibleSmoke(bool v)
    {
        foreach(GameObject item in Smoke)
        {
            item.SetActive(v);
        }
    }
}

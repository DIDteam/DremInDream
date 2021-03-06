﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MiniGameTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TrckerCamera;
    public Transform ETrcker;
    public GameObject E_TextPrefabs;
    //GameObject E_ui;
    //Image E_UIimg;
    [Header("--Mini Game Setting--")]
    public bool IsComplete = false;
    public bool IsPuzzleComplete = false;
    public bool SpawnPuzzle = false;
    public string ID_MiniGame;
    public MiniGameTable.Row GameData;
    public List<ItemsTable.Row> ListFindItems;
    public List<string> TempIdFindItem;
    ItemsTable.Row RewardItemData;
    public string puzzlename;
    public ST_PuzzleDisplay Puzzle;
    [Header("--Step Camera Setting--")]
    public Vector3 CameraPosition;
    public GameObject Lighting;
    //public MiniGameTracker BackStepCamera;
    //public MiniGameTracker[] NextStepCamera;
    [Header("--Mouse Setting--")]
    public Texture2D cursurOver;
    public CursorMode Cursormode = CursorMode.Auto;

    MiniGameTable Table = new MiniGameTable();
    TextAsset File;
    ItemsTable TableItem = new ItemsTable();
    TextAsset FileItem;

    private void Awake()
    {
        StreamReader reader = new StreamReader("Assets/CSV/MiniGame.csv");
        File = new TextAsset(reader.ReadToEnd());  
        Table.Load(File);
        Debug.Log(File.text);
        GameData = Table.Find_ID(ID_MiniGame);

        StreamReader readerItem = new StreamReader("Assets/CSV/AllItems.csv");
        FileItem = new TextAsset(readerItem.ReadToEnd());
        TableItem.Load(FileItem);
        foreach (string id in GameData.FindItem)
        {
            ListFindItems.Add(TableItem.Find_ID(id));
        }
        RewardItemData = TableItem.Find_ID(GameData.Reward);

        reader.Close();
        readerItem.Close();

        if(GameData.FindItem.Count > 0)
        {
            if (GameData.FindItem[0] == null || GameData.FindItem[0] == "")
            {
                GameData.FindItem.Clear();
                ListFindItems.Clear();
            }
        }
    }
    void Start()
    {
        if(!SpawnPuzzle && puzzlename != "")
        Puzzle = GameObject.Find(puzzlename).GetComponent<ST_PuzzleDisplay>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetRewardItem()
    {
        IsComplete = true;
        Debug.Log(RewardItemData);
        UIManager.GetInstance().GetRewardUI(RewardItemData.ImagePath);

        foreach (var id in GameData.FindItem)
        {
            SceneManagement.GetInstance().DropItemformInventory(id.ToString());
        }
        InventoryManager.GetInstance().AddItem(GameData.Reward);
        
    }

}

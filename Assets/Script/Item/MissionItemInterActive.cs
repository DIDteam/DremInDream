using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MissionItemInterActive : MonoBehaviour
{
    public string ItemMissionComplete;
    public GameObject ItemActive;
    public string ItemRewardID;
    public ItemsTable.Row DataReward;
    ItemsTable TableItem = new ItemsTable();
    TextAsset FileItem;
    // Start is called before the first frame update
    void Start()
    {
        StreamReader readerItem = new StreamReader("Assets/CSV/AllItems.csv");
        FileItem = new TextAsset(readerItem.ReadToEnd());
        TableItem.Load(FileItem);
        DataReward = TableItem.Find_ID(ItemRewardID);
        readerItem.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnlockMisstion()
    {
        SceneManagement.GetInstance().DropItemformInventory(ItemMissionComplete);
        ActiveEventMission();
    }

    public void ActiveEventMission()
    {
        Debug.Log("ActiveEvent");
        if (ItemActive != null)
        {
            Debug.Log("ActiveEvent2");
            if (ItemActive.GetComponent<AnimateGetItem>())
            {
                Debug.Log("Animation ActiveEvent");
                ItemActive.GetComponent<AnimateGetItem>().ActiveAnimateGetItem(DataReward.ImagePath);
                InventoryManager.GetInstance().AddItem(DataReward.ID);
            }
            else if (ItemActive.activeSelf == false)
            {
                Debug.Log("SetActive ActiveEvent");
                ItemActive.SetActive(true);
            }

            Destroy(this.gameObject);
        }
    }
}


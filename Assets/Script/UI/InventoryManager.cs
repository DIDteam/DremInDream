using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject PrefabsSlotItem;
    public List<GameObject> SlotItemInventory ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    static public InventoryManager GetInstance()
    {
        return (InventoryManager)FindObjectOfType(typeof(InventoryManager));
    }

    public void AddItem(string ItemID)
    {
        if (GetItembyID(ItemID) == null)
        {
            GameObject obj = Instantiate(PrefabsSlotItem,this.transform,false);
            obj.GetComponent<SlotItem>().ID_Item = ItemID;
            //obj.transform.SetParent(this.gameObject.transform);
            SlotItemInventory.Add(obj);
           
        }
        else
        {
            Debug.Log("Have Item : " + ItemID + "in Inventory");
        }
    }
    public void RemoveItem(string ItemID)
    {
        GameObject item = GetItembyID(ItemID);
        if (item != null)
        {
            int index = SlotItemInventory.IndexOf(item);
            SlotItemInventory.RemoveAt(index);
            Destroy(item);
        }
    }

    private GameObject GetItembyID(string id)
    {
        foreach (GameObject item in SlotItemInventory)
        {
            if (item.GetComponent<SlotItem>().ID_Item == id)
                return item;
        }
        Debug.Log("Can't Find Item that match with Item ID : " + id );
        return null;
    }
}

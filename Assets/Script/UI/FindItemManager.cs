using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItemManager : MonoBehaviour
{
    public GameObject PrefabFinditem;
    public List<FindItemControl> FindItems;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    static public FindItemManager GetInstance()
    {
        return (FindItemManager)FindObjectOfType(typeof(FindItemManager));
    }

    public void SetListFindItem(List<ItemsTable.Row> ListFindItem)
    {

        DestroyListItems();
        foreach (ItemsTable.Row item in ListFindItem)
        {
            GameObject obj = Instantiate(PrefabFinditem);
            obj.transform.SetParent(this.transform);
            bool MaskVisible = SceneManagement.GetInstance().PlayerData.Inventory.Contains(item.ID);
            obj.GetComponent<FindItemControl>().SetFindItemControl(item.ID, item.Name, MaskVisible);
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            FindItems.Add(obj.GetComponent<FindItemControl>());
        }
    }
    public void UpdateFindItem(string ID)
    {
        foreach (FindItemControl item in FindItems)
        {
            if(item.FindItemID == ID)
            {
                item.MaskTextVisible(true);
            }
        }
    }
    public void DestroyListItems()
    {
        foreach (FindItemControl item in FindItems)
        {
            Destroy(item.gameObject);
        }
        FindItems.Clear();
    }
}

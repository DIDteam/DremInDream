using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandle : MonoBehaviour , IDragHandler , IEndDragHandler
{
    public SlotItem parentItem;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            Debug.DrawRay(transform.position, hit.point, Color.green);
            //Debug.Log(hit.transform.gameObject);
            MissionItemInterActive Item = hit.transform.gameObject.GetComponent<MissionItemInterActive>();
            Debug.Log(Item.ItemMissionComplete + "==" + parentItem.ID_Item);
            if (Item.ItemMissionComplete == parentItem.ID_Item)
            {
                Item.UnlockMisstion();
                SceneManagement.GetInstance().DropItemformInventory(Item.ItemMissionComplete);
            }
        }
    }
        // Start is called before the first frame update
    void Start()
    {
        parentItem = this.transform.parent.gameObject.GetComponent<SlotItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

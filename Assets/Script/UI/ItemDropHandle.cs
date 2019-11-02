using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandle : MonoBehaviour ,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inPanal = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(inPanal, Input.mousePosition))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.DrawRay(transform.position, hit.point, Color.green);
                Debug.Log(hit.transform.gameObject);
                ItemInteractiveGame Item = hit.transform.gameObject.GetComponent<ItemInteractiveGame>();

                if (Item)
                {

                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

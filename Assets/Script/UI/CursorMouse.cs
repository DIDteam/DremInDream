using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorMouse : MonoBehaviour
{
    private Image render;
    public Texture2D NormalMouse;
    public Texture2D KeepItem;
    public Texture2D ZoomGlass;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 cursurPos = Input.mousePosition;
        // this.transform.position = cursurPos;
        //this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(ray, out hit, 10000.0f))
        {
            GameObject obj = hit.transform.gameObject;
            
            if (obj.GetComponent<ItemInteractiveGame>() && KeepItem != null)
            {
                Cursor.SetCursor(KeepItem, Vector2.zero, CursorMode.Auto);
            }
            else if (obj.GetComponent<MiniGameTracker>() && ZoomGlass != null)
            {
                Cursor.SetCursor(ZoomGlass, Vector2.zero, CursorMode.Auto);
            }
           
        }
        else
        {
            Cursor.SetCursor(NormalMouse, Vector2.zero, CursorMode.Auto);
        }



    }
}

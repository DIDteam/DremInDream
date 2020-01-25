using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindItemControl : MonoBehaviour
{
    public string FindItemID;
    public Text TextFindItem;
    public GameObject MaskText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetFindItemControl(string id, string name,bool MaskVisible)
    {
        FindItemID = id;
        TextFindItem.text = name.ToUpperInvariant();
        MaskTextVisible(MaskVisible);
    }
    public void MaskTextVisible(bool Visible)
    {
        MaskText.SetActive(Visible);
    }
}

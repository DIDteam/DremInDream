using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ItemInteractiveGame : MonoBehaviour
{

    [Header("--Item Data--")]
    public string ID_Item;
    public ItemsTable.Row GameData;

    ItemsTable Table = new ItemsTable();
    TextAsset File;
    private void Awake()
    {
        StreamReader reader = new StreamReader("Assets/CSV/AllItems.csv");
        File = new TextAsset(reader.ReadToEnd());
        Table.Load(File);
        Debug.Log(File.text);
        GameData = Table.Find_ID(ID_Item);
        reader.Close();
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

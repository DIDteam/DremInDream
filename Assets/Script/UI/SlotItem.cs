using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SlotItem : MonoBehaviour
{
    
    [Header("--Item Data--")]
    public string ID_Item;
    public ItemsTable.Row GameData;

    Text TextName;
    Image IMG;
    ItemsTable Table = new ItemsTable();
    TextAsset FileAsset;

    private GameObject myobj;
    // Start is called before the first frame update
    private void Awake()
    {
       
        TextName = GetComponentInChildren<Text>(true);
        IMG = GetComponent<Image>();
    }
    void Start()
    {
        myobj = new GameObject();
        GameData = new ItemsTable.Row();
        StreamReader reader = new StreamReader("Assets/CSV/AllItems.csv");
        FileAsset = new TextAsset(reader.ReadToEnd());
        Table.Load(FileAsset);
        Debug.Log(FileAsset.text);
        GameData = Table.Find_ID(ID_Item);
        reader.Close();

        if (GameData.ImagePath != "")
        {
            Texture2D sprites = Resources.Load<Texture2D>(GameData.ImagePath);
            Rect rec = new Rect(0, 0, sprites.width, sprites.height);
            Sprite.Create(sprites, rec, new Vector2(0, 0), 1);
            IMG.sprite = Sprite.Create(sprites, rec, new Vector2(0, 0), .01f);
        }
        TextName.text = ID_Item;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
}
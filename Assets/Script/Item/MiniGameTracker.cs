using System.Collections;
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
    public string ID_MiniGame;
    public MiniGameTable.Row GameData;

    [Header("--Step Camera Setting--")]
    public MiniGameTracker BackStepCamera;
    public MiniGameTracker[] NextStepCamera;

    MiniGameTable Table = new MiniGameTable();
    TextAsset File;
    private void Awake()
    {
        StreamReader reader = new StreamReader("Assets/CSV/MiniGame.csv");
        File = new TextAsset(reader.ReadToEnd());  
        Table.Load(File);
        Debug.Log(File.text);
        GameData = Table.Find_ID(ID_MiniGame);
        reader.Close();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


}

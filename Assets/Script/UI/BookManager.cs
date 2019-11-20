using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class BookManager : MonoBehaviour
{
    [SerializeField]
    public Text LeftTopicText;
    public Image LeftImage;
    public Text LeftDetailText;
    public Text LeftNumText;

    [Header("-----------")]

    [SerializeField]
    public Text RightTopicText;
    public Image RightImage;
    public Text RightDetailText;
    public Text RightNumText;

    [Header("-----------")]
    public GameObject Panel;
    public GameObject LeftPage;
    public GameObject RightPage;


    public int CurrentPage;
    public List<BookDetailTable.Row> ListBook;
    public List<ItemsTable.Row> ListItem;
    public List<MiniGameTable.Row> Listmini;


    BookDetailTable Table = new BookDetailTable();
    TextAsset File;

    ItemsTable TableItem = new ItemsTable();
    TextAsset FileItem;

    MiniGameTable Tablemini = new MiniGameTable();
    TextAsset Filemini;

    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader("Assets/CSV/BookDetail.csv");
        File = new TextAsset(reader.ReadToEnd());
        Table.Load(File);
        Debug.Log(File.text);
        ListBook = Table.GetRowList();
        reader.Close();

        StreamReader readeritem = new StreamReader("Assets/CSV/AllItems.csv");
        FileItem = new TextAsset(readeritem.ReadToEnd());
        TableItem.Load(FileItem);
        Debug.Log(FileItem.text);
        ListItem = TableItem.GetRowList();
        readeritem.Close();

        StreamReader readermini = new StreamReader("Assets/CSV/MiniGame.csv");
        Filemini = new TextAsset(readermini.ReadToEnd());
        Tablemini.Load(Filemini);
        Debug.Log(Filemini.text);
        Listmini = Tablemini.GetRowList();
        readermini.Close();


    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPage < ListBook.Count && CurrentPage >=0 )
        {
            LeftPage.SetActive(true);
            LeftTopicText.text = ListBook[CurrentPage].Mapname;
            Debug.Log(ListBook[CurrentPage].IDItem);
            //string pathL = TableItem.Find_ID(ListBook[CurrentPage].IDItem).ImagePath;
            //Texture2D spritesL = Resources.Load(pathL) as Texture2D;
            //Rect recL = new Rect(0, 0, spritesL.width, spritesL.height);
            //LeftImage.sprite = Sprite.Create(spritesL, recL, new Vector2(0, 0), .01f);
            LeftDetailText.text = ListBook[CurrentPage].Detail;
            int maxMapL = Table.FindAll_Mapname(ListBook[CurrentPage].Mapname).Count;
            int curiteminMapL = 0; // Table.find(ListBook[CurrentPage].Mapname)
            LeftNumText.text = "( " + curiteminMapL + " / " + maxMapL + " )";
        }
        else
        {
            LeftPage.SetActive(false);
        }

        if (CurrentPage + 1 < ListBook.Count && CurrentPage >= 0)
        {
            RightPage.SetActive(true);
            RightTopicText.text = ListBook[CurrentPage + 1].Mapname;
            Debug.Log(ListBook[CurrentPage + 1].IDItem);
            //string pathR = TableItem.Find_ID(ListBook[CurrentPage + 1].IDItem).ImagePath;
            //Texture2D spritesR = Resources.Load(pathR) as Texture2D;
            //Rect recR = new Rect(0, 0, spritesR.width, spritesR.height);
            //RightImage.sprite = Sprite.Create(spritesR, recR, new Vector2(0, 0), .01f);
            RightDetailText.text = ListBook[CurrentPage + 1].Detail;
            int maxMapR = Table.FindAll_Mapname(ListBook[CurrentPage + 1].Mapname).Count;
            int curiteminMapR = 0; // Table.find(ListBook[CurrentPage].Mapname)
            RightNumText.text = "( " + curiteminMapR + " / " + maxMapR + " )";
        }
        else
        {
            RightPage.SetActive(false);
        }

    }
    public void LeftButton()
    {
        CurrentPage -= 2;
        CurrentPage = Mathf.Clamp(CurrentPage, 0, ListBook.Count);

    }
    public void RightButton()
    {
        CurrentPage += 2;
        CurrentPage = Mathf.Clamp(CurrentPage, 0, ListBook.Count);
    }

    public void CloseButton()
    {
        Panel.SetActive(false);
    }
    public void OpenButton()
    {
        Panel.SetActive(true);
    }
}

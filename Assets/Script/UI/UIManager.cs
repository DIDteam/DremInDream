using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Animator AnimControl;
    public GameObject panalReaward;
    public GameObject RewardObject;
    public GameObject InventoryObject;
    public GameObject FinishPanel;
    public DialogCutScene Dialogs;
    public RoadMapManagement RoadMap;
    public List<GameObject> Star = new List<GameObject>();
    public Text TextScore;
    // Start is called before the first frame update
    void Start()
    {
        AnimControl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    static public UIManager GetInstance()
    {
        return (UIManager)FindObjectOfType(typeof(UIManager));
    }

    public Sprite LoadImageByPath(string path)
    {
        Texture2D sprites = Resources.Load(path) as Texture2D;
        Rect rec = new Rect(0, 0, sprites.width, sprites.height);
        return Sprite.Create(sprites, rec, new Vector2(0, 0), 1);
    }
    IEnumerator GetRewardTime(string pathItem)
    {
        Image img = RewardObject.GetComponentInChildren<Image>();
        img.sprite = LoadImageByPath(pathItem);
        AnimControl.SetBool("GetReward", true);
        yield return new WaitForSeconds(2);
        panalReaward.SetActive(false);
        SetVisibleFindItemBar(false);
        AnimControl.SetBool("GetReward",false);
    }
    public void GetRewardUI(string pathItem)
    {
        StartCoroutine(GetRewardTime(pathItem));
    }

    public void SetVisibleFindItemBar(bool Visible)
    {
        AnimControl.SetBool("FindItem", Visible);
    }

    public void FinishScore(float time)
    {
        int star = 0;
        float min = time / 60.0f ;
        FinishPanel.SetActive(true);
        if (min<= 5.0f)
            star = 3;
        else if (min > 5.0f && min < 6.0f)
            star = 2;
        else if (min > 6.0f && min < 7.0f)
            star = 1;
        else 
            star = 0;

        for (int i = 0; i < star; i++)
        {
            Star[i].SetActive(true);
        }

        int score = min < 5 ? 1000 : 1000 * (5 - ((int)min % 5) / 5);
        TextScore.text = score.ToString();
        AnimControl.SetBool("FinishPanel", true);
    }

   public void StartMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartDiaologs()
    {
        Dialogs.gameObject.SetActive(true);
        FinishPanel.SetActive(false);
    }
}

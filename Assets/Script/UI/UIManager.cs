using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator AnimControl;
    public GameObject panalReaward;
    public GameObject RewardObject;
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
}

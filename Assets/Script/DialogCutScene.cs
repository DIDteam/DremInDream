using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogCutScene : MonoBehaviour
{
    public Text Message;
    public List<string> Dialogs00;
    public List<string> Dialogs01;
    public List<string> Dialogs02;
    public List<string> Dialogs03;
    public List<string> Dialogs;
    public int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManagement.GetInstance().bMap01)
        {
            Dialogs = Dialogs01;
        }
        else if (SceneManagement.GetInstance().bMap02)
        {
            Dialogs = Dialogs02;
        }
        else if (SceneManagement.GetInstance().bMap03)
        {
            Dialogs = Dialogs03;
        }
        else
        {
            Dialogs = Dialogs00;
        }
    }

    public void ClickButton()
    {
        if (Count >= Dialogs.Count)
            CheckContinue();

        Message.text = Dialogs[Count];
        Count++;
    }
    public void CheckContinue()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            UI_MainMenuManager.GetInstance().StartButton();
        }
        else
        {
            if(SceneManagement.GetInstance().bMap01)
            {
                UIManager.GetInstance().RoadMap.Map02Button();
            }
            else if(SceneManagement.GetInstance().bMap02)
            {
                UIManager.GetInstance().RoadMap.Map03Button();
            }
            else if(SceneManagement.GetInstance().bMap03)
            {
                
            }
        }
    }
    public void SetDefluat()
    {
        Message.text = Dialogs[Count];
    }
}

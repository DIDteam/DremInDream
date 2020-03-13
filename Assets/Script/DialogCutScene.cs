using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogCutScene : MonoBehaviour
{
    public Image MePic01;
    public Image MePic02;
    public Text Message;
    public List<string> Dialogs00;
    public List<string> Dialogs01;
    public List<string> Dialogs02;
    public List<string> Dialogs03;
    public List<string> Dialogs;
    public int Count = 0;
    bool setfrist = false;
    public bool HaveMe = false;
    public bool Me02 = false;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setfrist)
            return;

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            HaveMe = true;
            Me02 = false;
            Dialogs = Dialogs00;
            SetDefluat();
        }
        else if(SceneManagement.GetInstance().bMap01)
        {
            HaveMe = false;
            Dialogs = Dialogs01;
            SetDefluat();
        }
        else if (SceneManagement.GetInstance().bMap02)
        {
            HaveMe = false;
            Dialogs = Dialogs02;
            SetDefluat();
        }
        else if (SceneManagement.GetInstance().bMap03)
        {
            HaveMe = true;
            Me02 = true;
            Dialogs = Dialogs03;
            SetDefluat();
        }
       
    }

    public void ClickButton()
    {
        if (Count >= Dialogs.Count)
            CheckContinue();

        Count++;
        Message.text = Dialogs[Count];

    }
    public void CheckContinue()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            UI_MainMenuManager.GetInstance().StartButton();
        }
        else
        {
            if (SceneManagement.GetInstance().bMap01)
            {
                UIManager.GetInstance().RoadMap.Map02Button();
            }
            else if (SceneManagement.GetInstance().bMap02)
            {
                UIManager.GetInstance().RoadMap.Map03Button();
            }
            else if (SceneManagement.GetInstance().bMap03)
            {

            }
        }
    }
    public void SetDefluat()
    {
        Message.text = Dialogs[0];
        setfrist = true;
        if (HaveMe)
        {
            if(Me02)
            {
                MePic02.gameObject.SetActive(HaveMe);
            }
            else
            {
                MePic01.gameObject.SetActive(HaveMe);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionItemInterActive : MonoBehaviour
{
    public string ItemMissionComplete;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnlockMisstion()
    {
        SceneManagement.GetInstance().DropItemformInventory(ItemMissionComplete);
        ActiveEventMission();
    }

    public virtual void ActiveEventMission()
    {

    }
}


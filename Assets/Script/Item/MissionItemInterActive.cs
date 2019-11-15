using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionItemInterActive : MonoBehaviour
{
    public string ItemMissionComplete;
    public GameObject ItemActive;
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

    public void ActiveEventMission()
    {
        Debug.Log("ActiveEvent");
        if (ItemActive != null)
        {
            Debug.Log("ActiveEvent2");
            if (ItemActive.GetComponent<AnimateGetItem>())
            {
                Debug.Log("Animation ActiveEvent");
                ItemActive.GetComponent<AnimateGetItem>().ActiveAnimateGetItem();
            }
            else if (ItemActive.activeSelf == false)
            {
                Debug.Log("SetActive ActiveEvent");
                ItemActive.SetActive(true);
            }

            Destroy(this.gameObject);
        }
    }
}


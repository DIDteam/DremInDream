using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TrckerCamera;
    public Transform ETrcker;
    public GameObject E_TextPrefabs;
    GameObject E_ui;
    Image E_UIimg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (E_ui)
        {
            if (E_ui.activeSelf)
                E_UIimg.transform.position = Camera.main.WorldToScreenPoint(ETrcker.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            PlayerController.GetInstance().InZoneMiniGame = true;
            SceneManager.GetInstance().Camera.SetTargetMode(CameraFollowMode.FollowMiniGame,TrckerCamera.transform);
            if (!E_ui)
            {
                E_ui = Instantiate(E_TextPrefabs, FindObjectOfType<Canvas>().transform);
                E_UIimg = E_ui.GetComponent<Image>();
            }else{
                E_ui.SetActive(true);
            }
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (E_ui)
            E_ui.SetActive(false);
        PlayerController.GetInstance().InZoneMiniGame = true;
    }
}

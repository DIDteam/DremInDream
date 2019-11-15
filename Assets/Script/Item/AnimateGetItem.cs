using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateGetItem : MonoBehaviour
{
    public Animator AnimControl;
    // Start is called before the first frame update
    void Start()
    {
        AnimControl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveAnimateGetItem()
    {
        AnimControl.SetBool("Open",true);
    }
}

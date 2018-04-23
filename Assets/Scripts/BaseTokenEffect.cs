using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTokenEffect : MonoBehaviour
{
   // protected PlayerController m_player;

    protected virtual void Start()
    {
        //m_player = gameObject.GetComponent<PlayerController>();
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(this);
        }
    }

}

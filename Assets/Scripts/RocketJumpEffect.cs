using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketJumpEffect : BaseTokenEffect
{
    protected override void Start ()
    {
        gameObject.GetComponent<PlayerController>().m_RocketJumpTime = 5f;
        gameObject.GetComponent<PlayerController>().m_JetPack.SetActive(true);
        gameObject.GetComponent<PlayerController>().m_RocketJumpIcone.SetActive(true);
        gameObject.GetComponent<PlayerController>().m_RocketJumpTimeText.text = gameObject.GetComponent<PlayerController>().m_RocketJumpTime.ToString();
    }

    protected void OnDestroy()
    {
        gameObject.GetComponent<PlayerController>().m_JetPack.SetActive(false);
        gameObject.GetComponent<PlayerController>().m_RocketJumpIcone.SetActive(false);
    }
}

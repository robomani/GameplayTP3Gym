using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketJumpEffect : BaseTokenEffect
{
    private GameObject m_JetPack = GameObject.Find("JetPack");
    private GameObject m_Icone;

    protected override void Start ()
    {
        m_Icone = gameObject.GetComponent<PlayerController>().m_RocketJumpIcone;
        m_Icone.g = gameObject.GetComponent<PlayerController>().m_RocketJumpTime;
        m_JetPack.SetActive(true);
        m_Icone.SetActive(true);
    }
	

	private void Update ()
    {
		
	}

    protected void OnDestroy()
    {
        m_JetPack.SetActive(false);
    }
}

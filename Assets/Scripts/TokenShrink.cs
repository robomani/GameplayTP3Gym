using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenShrink : BaseToken
{

    private void OnTriggerEnter(Collider a_Other)
    {
        
        if(a_Other.tag == "Player")
        {

            PlayerController player = a_Other.GetComponent<PlayerController>();
            if (player.m_MaxNBRShink > player.m_ShrinkUsed)
            {
                player.m_ShrinkUsed++;
                a_Other.gameObject.AddComponent<ShrinkTokenEffect>();
                gameObject.SetActive(false);
            }
        }

    }

}

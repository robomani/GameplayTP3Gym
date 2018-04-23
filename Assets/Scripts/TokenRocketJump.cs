using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TokenRocketJump : MonoBehaviour {

    private void OnTriggerEnter(Collider a_Other)
    {

        if (a_Other.tag == "Player")
        {
            if(a_Other.GetComponent<RocketJumpEffect>())
            {
                a_Other.GetComponent<PlayerController>().m_RocketJumpTime += 5f;
                a_Other.GetComponent<PlayerController>().m_RocketJumpTimeText.text = a_Other.GetComponent<PlayerController>().m_RocketJumpTime.ToString();
            }
            else
            {
                a_Other.gameObject.AddComponent<RocketJumpEffect>();      
            }
            gameObject.SetActive(false);
        }

    }
}

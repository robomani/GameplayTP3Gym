using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Move
    public float m_Speed = 10f;
    public float m_TurnSpeed = 5f;
    public float m_JumpForce = 10f;
    private bool m_Grounded = true;
    private Rigidbody m_RigidBody;

    //Clone PowerUp
    public bool m_Prime = false;
    public int m_CloneUses = 0;
    public int m_NBRClones = 0;
    public int m_MaxClones = 10;
    public GameObject m_PrefabToClone;
    public GameObject[] m_CloneArray;
    //public GameObject m_CloneIcone;
    private GameObject m_PrimeBody;

    //RocketJump PowerUp
    public float m_RocketJumpTime = 0f;
    public float m_RocketJumpPower = 5f;
    //public float m_RocketJumpChargeTime = 10f;
    public GameObject m_JetPack;
    public GameObject m_RocketJumpIcone;
    public Text m_RocketJumpTimeText;

    //Shrink PowerUp
    //public int m_ShrinkUses = 0;
    //public float m_PercentShrink = 50f;
    public int m_MaxNBRShink = 2;
    //public GameObject m_SrinkIcone;
    public int m_ShrinkUsed = 0;
    //private Vector3 m_OriginalSize;

    //Reset PowerUp
    public bool m_ResetReady = false;
    private float m_ResetTime = 0.5f;
    //public GameObject m_ResetIcone;

    void Start ()
    {
        if(gameObject.GetComponent<Rigidbody>())
        {
            m_RigidBody = gameObject.GetComponent<Rigidbody>();
        }
        else if(m_Prime)
        {
            Debug.LogError("No RigidBody for the player");
        }
        else
        {
            Debug.LogError("No RigidBody for a clone");
        }
    }
	

	void Update ()
    {
		if(Input.GetKey(KeyCode.UpArrow))
        {
            m_RigidBody.AddForce(transform.forward * m_Speed);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            m_RigidBody.AddForce(-transform.forward * (m_Speed/2));
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion originalRotation = transform.rotation;
            transform.rotation = originalRotation * Quaternion.AngleAxis(-m_TurnSpeed, Vector3.up);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion originalRotation = transform.rotation;
            transform.rotation = originalRotation * Quaternion.AngleAxis(m_TurnSpeed, Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.Space) && m_Grounded)
        {  
            m_RigidBody.AddForce(transform.up * m_JumpForce);
            m_Grounded = false;
        }
        else if(Input.GetKey(KeyCode.Space) && !m_Grounded && m_RocketJumpTime > 0)
        {
            m_RigidBody.AddForce(transform.up * m_RocketJumpPower);
            m_RocketJumpTime -= Time.deltaTime;
            m_RocketJumpTimeText.text = m_RocketJumpTime.ToString();
            if (m_RocketJumpTime <= 0)
            {
                Destroy(gameObject.GetComponent<RocketJumpEffect>());
            }
        }

        if(Input.GetKeyDown(KeyCode.C) && m_CloneUses > 0 && m_MaxClones > m_NBRClones && m_Prime)
        {
            Vector3 temp = transform.position;
            Quaternion tempRot = transform.rotation;
            if (m_NBRClones % 2 == 0)
            {
                temp.x += Mathf.Clamp(m_NBRClones +2, 2, 100);
            }
            else
            {
                temp.x -= Mathf.Clamp(m_NBRClones +2, 2, 100);                
            }
            GameObject clone = Instantiate(m_PrefabToClone, temp, tempRot);
            clone.GetComponent<PlayerController>().m_PrimeBody = gameObject;
            m_CloneArray[m_NBRClones] = clone;
            m_NBRClones++;
            m_CloneUses--;
        }/*
        else if(Input.GetKeyDown(KeyCode.S) && m_ShrinkUses > 0 && m_MaxNBRShink > 0 && m_Prime)
        {
            Vector3 temp = transform.localScale;
            transform.localScale -= new Vector3(temp.x * (m_PercentShrink/100), temp.y * (m_PercentShrink / 100), temp.z * (m_PercentShrink / 100));
            if(m_NBRClones > 0)
            {
                for(int i = 0; i < m_NBRClones; i++)
                {
                    m_CloneArray[i].transform.localScale -= new Vector3(temp.x * (m_PercentShrink / 100), temp.y * (m_PercentShrink / 100), temp.z * (m_PercentShrink / 100));
                }

            }
            m_ShrinkUses--;
            m_ShrinkUsed++;
        }*/
        else if(Input.GetKeyDown(KeyCode.R) && m_ResetReady && m_Prime)
        {
            if(m_NBRClones > 0)
            {
                foreach(GameObject clone in m_CloneArray)
                {
                    Destroy(clone);
                }
                m_NBRClones = 0;
            }
            /*if(m_ShrinkUsed > 0)
            {
                for (int i =0; i < m_ShrinkUsed; m_ShrinkUsed--)
                {
                    Vector3 temp = m_OriginalSize;
                    for(int j = 0; j < m_ShrinkUsed; j++)
                    {
                        temp *= ((m_PercentShrink / 100));
                    }
                    transform.localScale += temp;
                }
            }
            */

            //m_CloneUses = 0;
            //m_ResetReady = false;
            //m_RocketJumpUses = 0;
            //m_ShrinkUses = 0;
        }
        if (m_ResetReady)
        {
            if (m_ResetTime <= 0)
            {
                m_ResetTime = 0.5f;
                m_ResetReady = false;
            }
            else
            {
                m_ResetTime -= Time.deltaTime;
            }
            
        }
	}

    private void OnTriggerEnter(Collider a_Other)
    {
        if (a_Other.tag == "Ground")
        {
            m_Grounded = true;
        }
    }

}

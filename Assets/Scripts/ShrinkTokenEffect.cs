using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkTokenEffect : BaseTokenEffect
{

    public float m_PercentShrink = 50f;
    private Vector3 m_OriginalSize;

    protected override void Start()
    {
        base.Start();
        m_OriginalSize = transform.localScale;
        Vector3 temp = transform.localScale;
        transform.localScale -= new Vector3(temp.x * (m_PercentShrink / 100), temp.y * (m_PercentShrink / 100), temp.z * (m_PercentShrink / 100));
        if (m_player.m_NBRClones > 0)
        {
            for (int i = 0; i < m_player.m_NBRClones; i++)
            {
                m_player.m_CloneArray[i].transform.localScale -= new Vector3(temp.x * (m_PercentShrink / 100), temp.y * (m_PercentShrink / 100), temp.z * (m_PercentShrink / 100));
            }

        }
       
    }

    protected void OnDestroy()
    {
        m_OriginalSize *= ((m_PercentShrink / 100));
        transform.localScale += m_OriginalSize;
        m_player.m_ShrinkUsed--;
    }

}

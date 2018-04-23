using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseToken : MonoBehaviour
{

	private void Update ()
    {
		if(Input.GetKeyDown(KeyCode.R))
        {
            gameObject.SetActive(true);
        }
	}
}

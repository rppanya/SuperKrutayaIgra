using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCloud : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

		Invoke("DestroyIt", 0.8f);
	}

	void DestroyIt()
	{
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update()
	{

	}
}

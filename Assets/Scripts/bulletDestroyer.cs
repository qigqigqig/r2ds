using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boundry")
        {
            if (gameObject.tag == "Bullet")
            {
                Debug.Log("hi??");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("hi??");
                Destroy(gameObject);
            }
        }
    }
}

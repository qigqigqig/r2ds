using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroyer : MonoBehaviour {
    public float HP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(gameObject.tag);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (gameObject.tag == "Enemy")
            {
                //      Debug.Log("enemy hit");
                HP = HP - 1;
                if (HP <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
           
        }
    }

}

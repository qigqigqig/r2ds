using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody2D myrigidbody;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
         
		
	}

    // Update is called once per frame
    void Update() {
        playerMoving = false;
       // Debug.Log(Input.GetAxisRaw("HoriR"));
        Debug.Log(Input.GetAxisRaw("VertR"));
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            playerMoving = true;
            myrigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myrigidbody.velocity.y);
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            //   transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") *moveSpeed * Time.deltaTime, 0f, 0f));


        }
        if (Input.GetButtonDown("Fire1"))
            {

            Vector2 dir;
            float deadZone = 0.2f;
            float rightX = Input.GetAxis("HoriR");
            float rightY = Input.GetAxis("VertR");
            dir = new Vector2(rightX, rightY);
          //  Debug.Log(dir);
         //   if (dir.sqrMagnitude > deadZone)
           // {
                dir.Normalize();
                Debug.Log("Right Stick Location: " + dir);

            //}
            //Debug.Log("Hi");
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Bullet");
            if (bullet != null)
            {
                Debug.Log("Mouse Location: " + direction);
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * 20;

            }

        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            playerMoving = true;
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            // transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

        }
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
           
            myrigidbody.velocity = new Vector2(0f, myrigidbody.velocity.y);
            
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
          
            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, 0f);
            
        }
        anim.SetFloat("Movex", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("movey", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("lastmovex", lastMove.x);
        anim.SetFloat("lastmovey", lastMove.y);

    }
}

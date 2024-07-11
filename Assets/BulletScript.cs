using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = 3.0f;

        rb.velocity = new Vector3(0, 0, moveSpeed);

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject GameManager;
            GameManagerScript gameManagerScript;
            GameManager = GameObject.Find("GameManager");
            gameManagerScript = GameManager.GetComponent<GameManagerScript>();

            gameManagerScript.Hit();

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}

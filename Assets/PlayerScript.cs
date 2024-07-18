using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

using Input = UnityEngine.Input;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    public Animator animator;

    public GameObject bullet;

    public GameObject gameManager;

    int bulletTimer = 0;

    private GameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();

        Quaternion.Euler(0, 0, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            gameManagerScript.GameOverStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }

        float moveSpeed = 2.0f;

        float stageMax = 4.0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);

                transform.rotation = Quaternion.Euler(0, 90, 0);

                animator.SetBool("State", true);
            }
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -stageMax)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);

                transform.rotation = Quaternion.Euler(0, -90, 0);

                animator.SetBool("State", true);
            }
        }

        else
        {
            rb.velocity = new Vector3(0, 0, 0);

            Quaternion.Euler(0, 0, 0);

            animator.SetBool("State", false);
        }
    }

    void FixedUpdate()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }

        if (bulletTimer == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z += 1.0f;

                Instantiate(bullet, position, Quaternion.identity);

                bulletTimer = 1;
            }
        }
        else
        {
            bulletTimer++;
            if (bulletTimer > 10)
            {
                bulletTimer = 0;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol t�klama kontrol�
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0; // Z eksenini s�f�rla

            if (touchPos.x < transform.position.x) // Oyuncunun soluna t�kland�ysa sola git
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else // Sa��na t�kland�ysa sa�a git
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }

            Invoke("StopMovement", 0.6f); // 0.5 saniye sonra hareketi durdur
        }
    }

    void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene("Game");
        }
    }





}
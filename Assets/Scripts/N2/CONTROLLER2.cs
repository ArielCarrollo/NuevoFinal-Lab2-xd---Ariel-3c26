using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CONTROLLER2 : CONTROLES
{
    bool Cred2 = false;
    bool Cblue2 = false;
    private void Awake()
    {
        _compRigidBody2D = GetComponent<Rigidbody2D>();
        _Spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Saltar();
        if (this.gameObject.transform.position.y <= -5.42f)
        {
            SceneManager.LoadScene("perdiste2");
        }
    }
    void FixedUpdate()
    {
        Movimiento();
        Chequearpiso();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "red" && Cred2 == false)
        {
            Vidas--;
            if (Vidas <= 0)
            {
                SceneManager.LoadScene("perdiste2");
            }
        }
        if (collision.gameObject.tag == "blue" && Cblue2 == false)
        {
            Vidas--;
            if (Vidas <= 0)
            {
                SceneManager.LoadScene("perdiste2");
            }
        }
        if (collision.gameObject.tag == "ganaste2")
        {
            SceneManager.LoadScene("ganaste2");
        }
    }
    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumP();
        }
    }
    void Movimiento()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), 0);
        _compRigidBody2D.velocity = new Vector2(inputVector.x * velocityModifier, _compRigidBody2D.velocity.y);
        Debug.DrawRay(transform.position, inputVector.normalized * distanceModifier, Color.red);
    }
    void Chequearpiso()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.down, distanceModifier, layermask);
        if (raycast)
        {
            if (raycast.collider.CompareTag("Piso"))
            {
                Jumps = 1;
            }
        }
    }
    void JumP()
    {
        if (Jumps > 0)
        {
            _compRigidBody2D.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
            Jumps--;
        }
    }
    public void ColorChangeR2()
    {
        Color newColor = new Color(255, 0, 0);
        _Spriterenderer.color = newColor;
        Cred2 = true;
        Cblue2 = false;
    }
    public void ColorChangeB2()
    {
        Color newColor = new Color(0, 0, 255);
        _Spriterenderer.color = newColor;
        Cblue2 = true;
        Cred2 = false;
    }
}


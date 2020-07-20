using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_ : MonoBehaviour
{
    private float moveSpeed = 0.25f;
    private float moveX = 0.0f;
    private float moveY = 0.0f;
    private Vector2 destination;
    private Vector2 movement;
    private bool canMoveHorizontal = true;
    private bool canMoveVertical = true;

    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        this.transform.position = new Vector3(14.5f, 14.0f, 0.0f);
        destination = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Podemos movernos en UN EJE, pues al hacerlo el otro quedara bloqueado hasta que levantemos la tecla
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && canMoveVertical)
        {
            canMoveHorizontal = false;
            moveX = 0.0f;
            moveY = Input.GetAxis("Vertical");
            destination = (Vector2)this.transform.position + new Vector2(moveX, moveY);
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && canMoveHorizontal)
        {
            canMoveVertical = false;
            moveX = Input.GetAxis("Horizontal");
            moveY = 0.0f;
            destination = (Vector2)this.transform.position + new Vector2(moveX, moveY);
        }

        //Desbloquear el eje correspondiente
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) { canMoveHorizontal = true; }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) { canMoveVertical = true; }
        movement = Vector2.MoveTowards(this.transform.position, destination, moveSpeed);

        //Actualizar la transicion de animaciones
        anim.SetFloat("DirX", moveX);
        anim.SetFloat("DirY", moveY);
    }
    private void FixedUpdate() => rb.MovePosition(movement);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    private int currentWayPoint = 0;
    private float distanceToWayPoint;
    private Vector2 movement;

    public float speed;
    public Vector2 startPosition; //La posicion la ponemos desde el editor para que cada fantasma empiece un poco separado del otro, en vez de todos solapados

    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        this.transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToWayPoint = Vector2.Distance(this.transform.position, wayPoints[currentWayPoint].transform.position); //Distancia entre el fantasma y el punto de destino al que le toca ir a continuacion
        if (Mathf.Abs(distanceToWayPoint) < 0.1f) //en caso de haber llegado al punto
        {
            currentWayPoint = (currentWayPoint + 1) % wayPoints.Length; //Hacemos la ruta del fantasma ciclica
            Vector2 newDirection = wayPoints[currentWayPoint].transform.position - this.transform.position; //Destino - origen = vector de direccion de un punto a otro (coordenadaX, coordenadaY), cada una con su signo correspondiente
            anim.SetFloat("DirX", newDirection.x);
            anim.SetFloat("DirY", newDirection.y);
        }
        else //Si no hemos llegado al punto de ruta, nos movemos hacia el
        {
            movement = Vector2.MoveTowards(this.transform.position, wayPoints[currentWayPoint].transform.position, speed);
        }
    }

    private void FixedUpdate() => rb.MovePosition(movement);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}

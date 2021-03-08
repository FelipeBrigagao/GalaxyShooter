using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private float speedBoostDuration = 15f;
    private float speedBoost = 400f;
    private float normalSpeed = 200f;
    private float horizontalMove;
    private float verticalMove;
    private Vector3 moveAmount;

    private float boundariePosY = 0f;
    private float boundarieNegY = -4.3f;
    private float boundarieChangeX = 9.3f;
    private float boundarieAppearX = 9f;

    private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    int id;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = normalSpeed;
        id = GetComponent<PlayerStats>().GetId();
    }

    private void Update()
    {
        //recebe as informações de entrada sobre movimentação horizontal e vertical
        if(id == 1)
        {
            horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal"); // Input.GetAxisRaw("HorizontalP1");
            verticalMove = CrossPlatformInputManager.GetAxis("Vertical"); //Input.GetAxisRaw("VerticalP1");
        }
        else if(id == 2)
        {
            horizontalMove = Input.GetAxisRaw("HorizontalP2");
            verticalMove = Input.GetAxisRaw("VerticalP2");
        }

        
        //chama a função que detecta os limites do player na tela
        Boundaries();

        animator.SetFloat("DirectionX", horizontalMove);
    }

    private void FixedUpdate()
    {

        Vector3 direction = new Vector3(horizontalMove, verticalMove, 0f).normalized;
        Vector3 velocity = direction * speed;
        moveAmount = velocity * Time.deltaTime;
        //movimenta o player mudando a posição dele
        rb.velocity = moveAmount;
    }



    private void Boundaries()
    {
        //delimita a movimentação do player, sendo que nas laterais ele é movido ao outro lado da tela

        if (transform.position.y > boundariePosY)
        {
            transform.position = new Vector3(transform.position.x, boundariePosY, 0);

        }
        else if (transform.position.y < boundarieNegY)
        {
            transform.position = new Vector3(transform.position.x, boundarieNegY , 0);

        }
        else if (transform.position.x >= boundarieChangeX)
        {
            transform.position = new Vector3(-boundarieAppearX, transform.position.y, 0);

        }
        else if (transform.position.x <= -boundarieChangeX)
        {
            transform.position = new Vector3(boundarieAppearX, transform.position.y, 0);
        }
    }



    public void ActivateSpeedBoost()
    {
        speed = speedBoost;
        StartCoroutine(TurnOffSpeedBoost());

    }

    IEnumerator TurnOffSpeedBoost()
    {
        
        yield return new WaitForSeconds(speedBoostDuration);

        speed =normalSpeed;

    }

}
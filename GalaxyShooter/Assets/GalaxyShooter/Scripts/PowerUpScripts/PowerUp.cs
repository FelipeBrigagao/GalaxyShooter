using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    [SerializeField] private int powerUpID;

    [SerializeField] private AudioClip powerUpSound;

    private Rigidbody2D _rb;
    private float powerUpSpeed = 1;


    void Start()
    {
        //pega o rigidbody do gameObject atual(PowerUp) e aplica velocidade nele
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector3.down * powerUpSpeed;
        
    }


    private void Update()
    {
        if(transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }



    //Quando o collider do powerUp entrar em contato com outro collider essa função é chamada, pois o collider do powerup está marcado como trigger
    private void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log(other.tag);

        //verifica se colidiu com o player

        if(other.tag == "Player")
        {

            AudioSource.PlayClipAtPoint(powerUpSound, Camera.main.transform.position);

            if(powerUpID == 0)//triple shot
            {
                //salva o componente script ShottingControl do player que colidiu
                ShottingControl sC = other.GetComponent<ShottingControl>();

                if (sC != null)
                {
                    //ativa o tiro triplo do player que colidiu
                    sC.ActivateTripleShot();

                }

            }else if(powerUpID == 1)//speed boost
            {
                Player p = other.GetComponent<Player>();

                if(p != null)
                {
                    p.ActivateSpeedBoost();
                }


            }
            else if(powerUpID == 2) //shields
            {
                PlayerStats player = other.GetComponent<PlayerStats>();

                if(player != null)
                {
                    player.ActivateShields();
                }

            }



            //depois de colidir com o player o objeto na cena some
            Destroy(gameObject);

        }
    }
}

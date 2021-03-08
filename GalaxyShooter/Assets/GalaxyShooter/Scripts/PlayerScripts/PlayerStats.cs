using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int actualHealth;
    private int maxHealth = 3;
    [SerializeField] private int id;

    public GameObject explosion;
    public GameObject shieldsGFX;

    private bool shields = false;
    private int shieldsMaxHealth = 1;
    [SerializeField]private int shieldsHealth = 0;
    private GameObject shieldInstance;

    [SerializeField]private int score = 0;

    private UIManager uiManager;
    private GameControlling gC;


    [SerializeField] private AudioClip explosionPlayerSound;


    private List<Vector3> posicoesDano;
    [SerializeField] private GameObject danoGFX;

    void Start()
    {
        actualHealth = maxHealth;

        gC = GameObject.Find("GameControlling").GetComponent<GameControlling>();
        
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(uiManager != null)
        {
            uiManager.UpdateLives(actualHealth, id);
            uiManager.UpdateScore(score);
            if(GameControlling.playMode == 1)
            {
                uiManager.UpdateMaxScore(PlayerPrefs.GetInt("MaxScore", 0));
            }
        }

        posicoesDano = new List<Vector3>();

        posicoesDano.Add(new Vector3(-0.39f, -1.28f, 0f));
        posicoesDano.Add(new Vector3(0.39f, -1.28f, 0f));
        posicoesDano.Add(new Vector3(0.21f, -0.51f, 0f));
        posicoesDano.Add(new Vector3(-0.21f, -0.51f, 0f));

    }

    void Update()
    {
        if(!gC.gameRunning)
        {
            Destroy(gameObject);
        }

        
    }

    public void TakeDamage()
    {

        if (shields)
        {
            shieldsHealth--;

            if (shieldsHealth <= 0)
            {
                shields = false;

                Destroy(shieldInstance);
                //this.transform.GetComponentInChildren<Shield>().DesactivateShields();
            }

        }
        else
        {
            actualHealth--;

            AddDamageEffects();

            if(uiManager != null)
            {
                uiManager.UpdateLives(actualHealth, id);

            }

            if (actualHealth <= 0)
            {
                actualHealth = 0;
                Die();
            }

        }

    }


    public void ActivateShields()
    {
        if (!shields)
        {
            shieldInstance = Instantiate(shieldsGFX, transform.position, Quaternion.identity);
            shieldInstance.transform.SetParent(transform);


            shieldsHealth = shieldsMaxHealth;
            shields = true;

        }else if (shields)
        {
            shieldsHealth++;
        }
    }




    private void Die()
    {
        AudioSource.PlayClipAtPoint(explosionPlayerSound, Camera.main.transform.position);
        Instantiate(explosion, transform.position, Quaternion.identity);
        gC.GameEnded();
        Destroy(gameObject);
    }


    public void AddScore(int enemyPoints)
    {
        score += enemyPoints;
        uiManager.UpdateScore(score);


        if(GameControlling.playMode == 1 && score > PlayerPrefs.GetInt("MaxScore", 0))
        {
            PlayerPrefs.SetInt("MaxScore", score);
            uiManager.UpdateMaxScore(PlayerPrefs.GetInt("MaxScore", 0));
        }

    }


    private void AddDamageEffects()
    {
        //recebe posição e ativa o efeito de dano na posição referente
        int posicaoDano;

        posicaoDano = Random.Range(0, posicoesDano.Count);

        GameObject damageInstance = Instantiate(danoGFX, transform.position + posicoesDano[posicaoDano], Quaternion.identity);
        damageInstance.transform.SetParent(transform);

        posicoesDano.RemoveAt(posicaoDano);


    }

    public int GetId()
    {
        return id;
    }

}

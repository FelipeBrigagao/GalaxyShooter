using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingControl : MonoBehaviour
{

    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private Transform _firePoint;
    private AudioSource audioSource;

    private float _shootingRate = 0.15f;
    private float _nextShoot = 0f;

    private float tripleShotDuration = 15f;
    [SerializeField] private bool tripleShoot = false;

    int id;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        id = GetComponent<PlayerStats>().GetId();
    }

    void Update()
    {
        //verifica se o botão de tiro foi apertado
        if ((Input.GetButton("Fire1") && id == 1)||(Input.GetButton("Fire2") && id == 2))
        {
            _Shoot();

        }

    }

    private void _Shoot()
    {

        //verifica se já pode dar o tiro baseado no tempo do ultimo tiro, para não spamar tiro
        if (Time.time >= _nextShoot)
        {
            audioSource.Play();
            //se a variavel de tiro triplo está ligada, o tiro chamado é o do prefab tripleShot
            if (tripleShoot)
            {
                Instantiate(_tripleShotPrefab , _firePoint.position, Quaternion.identity);
                
                //estabelece quando poderá ser dado o próximo tiro, com base no tempo atual e a taxa de tiro
                _nextShoot = Time.time + _shootingRate;

            }
            else              //Senão é chamado o tiro normal
            {
                Instantiate(_laserPrefab, _firePoint.position, Quaternion.identity);

                 _nextShoot = Time.time + _shootingRate;
            
            }
        }
    }



    //ativa o tiro triplo
    public void ActivateTripleShot()
    {
        tripleShoot = true;

        //começa o processo de coroutine para desativar o tiro triplo com base no tempo de duração do mesmo
        StartCoroutine(DesactivateTripleShot());
        
    }

    //coroutine para desativar o tiro triplo
    IEnumerator DesactivateTripleShot()
    {
        yield return new WaitForSeconds(tripleShotDuration);
        tripleShoot = false;
    }


}

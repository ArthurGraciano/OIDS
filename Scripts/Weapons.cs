using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public static int weaponNumber;
    private float duracaoTotalArma;
    protected float speed = 100.0f;
    private float ForçaDaBala;
    public GameObject Bala;
    private float shootTimer = 0f;
    private bool shoot = false;
    private float TempoDoTiro = 0f;
    private float tempoDeDestruicao;
    private bool countdown;
    public GameObject LaserGun;
    private Vector3 LaserGunPos;
    private LineRenderer Laser;


    // Use this for initialization
    void Start() {
        countdown = false;
        weaponNumber = 1;
        Laser = GetComponent<LineRenderer>();
        Laser.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        LaserGunPos = LaserGun.transform.position;
        if (weaponNumber == 2 && countdown == false)
        {
            countdown = true;
            duracaoTotalArma = 5.0f;
            tempoDeDestruicao = Time.time + duracaoTotalArma;
        }
        else if (weaponNumber == 3 && countdown == false)
        {
            countdown = true;
            duracaoTotalArma = 8.0f;
            tempoDeDestruicao = Time.time + duracaoTotalArma;
        }

        if (Input.GetKey("mouse 0") && shoot == false && shootTimer < Time.time)
        {
            ShootBehaviour(weaponNumber);
            shoot = false;
            
        }


    }

    void ShootBehaviour(int weaponNumberIn)
    {
        shootTimer = Time.time + TempoDoTiro;
        if (weaponNumberIn == 1)
        {
            ForçaDaBala = 100;
            TempoDoTiro = 0.1f;
            countdown = false;
            SoundManager.instance.PlayTiro("Tiro");
            Shoot();

        }
        else if (weaponNumberIn == 2)
        {
            if (tempoDeDestruicao < Time.time)
            {
                weaponNumber = 1;
                countdown = false;

            }
            else
            {
                ForçaDaBala = 200;
                TempoDoTiro = 0.05f;
                Shoot();
                SoundManager.instance.PlayTiro("Tiro");
            }
        }
        else if (weaponNumberIn == 3)
        {
            if (tempoDeDestruicao < Time.time)
            {
                TempoDoTiro = 0f;
                weaponNumber = 1;
                countdown = false;
            }
            else
            {
                Shoot();
                SoundManager.instance.PlayTiro("Laser");
            }
        }
    }

    void Shoot()
    {

        if (weaponNumber == 1 || weaponNumber ==2)
        { 
        shoot = true;
            
        GameObject newBullet = Instantiate(Bala, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * ForçaDaBala);
        Destroy(newBullet, 2.0f);
        }
        else if(weaponNumber == 3)
        {
            StartCoroutine(LaserShoot());
            Debug.DrawRay(LaserGunPos, transform.up * 100, Color.red, 1);
            RaycastHit2D hit = Physics2D.Raycast(LaserGunPos, transform.up * 100, Mathf.Infinity);
             if (hit == true)
            {
                if(hit.rigidbody.gameObject.name == "WeakEnemy")
                {
                    JogoManager.GameManager.addPoints(10);
                }
                else if (hit.rigidbody.gameObject.name == "MediumEnemy")
                {
                    JogoManager.GameManager.addPoints(20);
                }
                else if (hit.rigidbody.gameObject.name == "HardEnemy")
                {
                    JogoManager.GameManager.addPoints(30);
                }
                else if (hit.rigidbody.gameObject.name == "DualEnemy")
                {
                    JogoManager.GameManager.addPoints(40);
                }
                else if (hit.rigidbody.gameObject.name == "CloneDualEnemy")
                {
                    JogoManager.GameManager.addPoints(40);
                }
                else if (hit.rigidbody.gameObject.name == "InvisibleEnemy")
                {
                    JogoManager.GameManager.addPoints(40);
                }
                Debug.Log(hit.rigidbody.tag + " was hit");
                Destroy(hit.rigidbody.gameObject);

            }
         }
       
    }

    IEnumerator LaserShoot()
    {
        Laser.enabled = true;
        yield return new WaitForSeconds(0.01f);
        Laser.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public static player Jogador;
    protected float speed = 100.0f;
    static Rigidbody2D Player;
    public int Vida;
    public bool Imunidade;
	
	// Update is called once per frame
    void Start ()
    {
        Jogador = this;
        Imunidade = false;
        
    }

	void Update () {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);

      //if (Input.GetKey("mouse 0") && shoot == false && shootTimer < Time.time)
       // {
       //     ShootBehaviour();
       //     shoot = false;
       // }
    }

   // void ShootBehaviour()
   // {
   //     shoot = true;
   //     GameObject newBullet = Instantiate(Bala, transform.position, transform.rotation);
   //     newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * ForçaDaBala);
   //     Destroy(newBullet, 2.0f);


   //     shootTimer = Time.time + TempoDoTiro;
   // }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && Imunidade == false)
        {
            SoundManager.instance.PlayTiro("Morte");
            JogoManager.GameManager.Vida -= 1;
            Destroy(other.gameObject);
            
        }
        else if (other.gameObject.tag == "Enemy" && Imunidade == true)
        {
            Destroy(other.gameObject);
        }
    }

}

using UnityEngine;

public class Enemy<T> where T : Enemy
{
    public GameObject GameObject;
    public T ScriptComponent;

    public Enemy(string name)
    {
        GameObject = new GameObject(name);
        ScriptComponent = GameObject.AddComponent<T>();
    }
}

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody2D Rigidbody2D;
    protected SpriteRenderer Sprite;
    protected CircleCollider2D Collider;
    protected int points;
    protected int LifePoints;

    protected int getWeapon;
    protected float Speed;
    protected Vector2 Direction;

    protected Transform playerTransform;

    protected bool haveWeapon;

    public virtual void MovementPattern()
    {
        Direction = ((playerTransform.position - transform.position).normalized);
        Rigidbody2D.MovePosition(Rigidbody2D.position + Direction * Speed * Time.fixedDeltaTime);
    }

    private void Awake()
    {
        haveWeapon = false;
        playerTransform = GameObject.FindWithTag("Player").transform;
        Rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        Sprite = gameObject.AddComponent<SpriteRenderer>();
        Collider = gameObject.AddComponent<CircleCollider2D>();
        transform.position = RespawnPointsList.respawnMethod();
        EnemyFactory.NumberOfEnemies += 1;
        Collider.radius = 0.205f;

        //Sprites

        Sprite.sprite = Resources.Load<Sprite>("enemy");
        Rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Rigidbody2D.gravityScale = 0;

        gameObject.tag = "Enemy";
    }

    void Update()
    {   
       MovementPattern();
    }
     

    //Valores unicos a serem determinados na instanciação

    public void Initialize(float speed, Vector3 position)
    {
        Speed = speed;
        transform.position = position;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {   
            LifePoints -= 1;
            Destroy(collision.gameObject);
            if (LifePoints == 0)
            {
                GameObject.Destroy(gameObject);
                JogoManager.GameManager.addPoints(points);
                EnemyFactory.NumberOfEnemies -= 1;
                if (haveWeapon == true)
                {
                    Weapons.weaponNumber = getWeapon;
                }
            }
        }
    }

   protected void weaponRandomizer(int weaponNumber)
    {
       int randomNumber = Random.Range(0, 20);
       if (randomNumber == 10)
       {
            haveWeapon = true;
            getWeapon = weaponNumber;
       }
    }

}

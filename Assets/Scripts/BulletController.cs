using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;

public class BulletController : MonoBehaviour
{
    [SerializeField] protected Bullet bullet;
    [SerializeField] IntReference playerHp;

    public string perspective;
    Vector3 direction;
    Vector2 screenBounds;
    float angle, velocity;
    public float Substract = 0; //ESTE VALOR LO ESTOY UTILIZANDO LUEGO DE INSTANCIARLO. Ejemplo, JEFES para los patrones    
    public float Multiplier = 1;
    public float AngleMultiplier = 0;
    public float changeThisName = 0;


    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = bullet.Sprite;
        angle = transform.localRotation.eulerAngles.z;
        direction = calculateDirection(angle);
        velocity = bullet.Velocity * Multiplier - Substract;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //Destroy(gameObject, 10f);
    }

    void Update()
    {
        Move();
        ModifyVelocity();

        if (transform.position.x > screenBounds.x * 1.2 || transform.position.x < screenBounds.x * -1.2) Destroy(gameObject);
        if (transform.position.y > screenBounds.y * 1.2 || transform.position.y < screenBounds.y * -1.2) Destroy(gameObject);
    }

    void OnBecameInvisible()
    {

    }


    void Move()
    {
        //Tengo que modificar como se mueven las balas, y que dependan de la direcicon a donde miran
        //A si puedo modificar un poco la rotacion y que esta afecte a su movimiento.
        //float _multiplier = AngleMultiplier != 0 ? AngleMultiplier : 1;
        transform.position += direction * Time.deltaTime * velocity;
    }

    void ModifyVelocity()
    {
        velocity -= changeThisName*Time.deltaTime;
    }

    Vector3 calculateDirection(float _angle)
    {
        const float grad_to_rad = (2 * Mathf.PI) / 360;
        float radians = grad_to_rad * _angle;
        float x = Mathf.Sin(radians);
        float y = Mathf.Cos(radians);
        return new Vector3(x, y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (perspective == "Player" && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BasicEnemyController>().TakeDamage(bullet.Damage);
            Destroy(gameObject);
        }

        if (perspective == "Player" && collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossController>().TakeDamage(bullet.Damage);
            Destroy(gameObject);
        }

        if ((perspective == "Enemy" || perspective == "Boss") && collision.gameObject.CompareTag("Player"))
        {
            playerHp.Value -= bullet.Damage;
            Destroy(gameObject);
        }
    }


}

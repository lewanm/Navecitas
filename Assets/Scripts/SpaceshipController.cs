using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] Spaceship spaceship;
    [SerializeField] IntReference hp;
    [SerializeField] FloatReference playerPositionX;
    [SerializeField] FloatReference playerPositionY;
    [SerializeField] float invincibleTime = 2f;
    [SerializeField] bool invincible = false;

    float shootTimer,velocity;
    int currentHealth;
    Vector3 movement;

    AudioSource source;
    public AudioClip clip;
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spaceship.Sprite;
        hp.Value  = spaceship.Hp;
        currentHealth = spaceship.Hp;

        source = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        
        shootTimer -= Time.deltaTime;
        Move();
        Shoot();
        CheckHp();
        CheckInvencibility();
        velocity = CheckSpeed() ? spaceship.SlowedVelocity : spaceship.Velocity;

        if (currentHealth > hp.Value)
        {
            StartCoroutine(getInvincible(invincibleTime));
            currentHealth = hp.Value;
        }
  
    }

    void LateUpdate()
    {
        CheckBorders();
    }

    private IEnumerator getInvincible(float time)
    {
        invincible = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(93, 93, 93,0.8f);
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        invincible = false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp.Value -= 1;
        }
    }
    void CheckBorders()
    {
        if (transform.position.x < -2.5f)
        {
            transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 2.5f)
        {
            transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -4.4f)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
        }
        if (transform.position.y > 4.7f)
        {
            transform.position = new Vector3(transform.position.x, 4.7f, transform.position.z);
        }
    }
    bool ShootIsOnCooldown()
    {
        return shootTimer <= 0;
    }
    void Move()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        movement = movement.normalized;
        transform.Translate(movement * velocity * Time.deltaTime);
        playerPositionX.Value = transform.position.x;
        playerPositionY.Value = transform.position.y;
    }
    void Shoot()
    {
        if (Input.GetKey("space") && ShootIsOnCooldown())
        {
            GameObject instance = Instantiate(spaceship.Bullet, transform.position,Quaternion.Euler(0, 0, 0));
            BulletController bc = instance.GetComponent<BulletController>();
            bc.perspective = gameObject.tag;
            source.PlayOneShot(clip);
            shootTimer = spaceship.ShootCooldown;
        }
    }

    void CheckInvencibility()
    {
        gameObject.layer = invincible ? 9 : 6;
    }


    void CheckHp()
    {
        if (hp.Value <= 0) Destroy(gameObject);
    }

    bool CheckSpeed()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

}

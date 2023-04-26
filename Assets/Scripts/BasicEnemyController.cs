using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;
using System.Threading.Tasks;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] BasicEnemy enemy;    
    [SerializeField] FloatReference playerPositionX;
    [SerializeField] FloatReference playerPositionY;
    int hp;
    float shootTimer = 0;
    float PlayerAngleDirection;
    float x, y;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = enemy.Sprite;
        hp = enemy.InitialHp;

        Destroy(gameObject, 10f);
    }

    
    void Update()
    {
        Move();
        Shoot();
        CheckHp();
        Rotate();

        shootTimer -= Time.deltaTime;
    }
    
    void Move()
    {
        transform.position += new Vector3(enemy.VelocityX * Time.deltaTime, -enemy.VelocityY * Time.deltaTime, 0);
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * enemy.rotationSpeed));
    }

    void Shoot()
    {
        if (ShootIsOnCooldown())
        {
            switch (enemy.Pattern)
            {
                case 0:
                    NoShoot();
                    break;
                case 1:
                    DirectPattern();
                    break;
                case 2:
                    ThreeBullets();
                    break;
            }
        }
    }

    float calculatePlayerAngle()
    {
        x = playerPositionX.Value - transform.position.x;
        y = playerPositionY.Value - transform.position.y;
        PlayerAngleDirection = Mathf.Atan(x / y) * 180 / Mathf.PI;
        PlayerAngleDirection = playerPositionY.Value < transform.position.y ? PlayerAngleDirection + 180 : PlayerAngleDirection;

        return PlayerAngleDirection;
    }

    void CheckHp()
    {
        if (hp <= 0) Destroy(gameObject);
    }

    bool ShootIsOnCooldown()
    {
        return shootTimer <= 0;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    //PATRONES DE DISPARO

    //0
    void NoShoot()
    {
        return;
    }
    //1
    void DirectPattern()
    {
        GameObject instance = Instantiate(enemy.Bullet, transform.position, Quaternion.Euler(0, 0, calculatePlayerAngle()));
        BulletController bc = instance.GetComponent<BulletController>();
        bc.perspective = gameObject.tag;
        shootTimer = enemy.ShootCooldown;
    }

    void ThreeBullets()
    {
        for (int i = 1; i<42; i+=20)
        {
            GameObject instance = Instantiate(enemy.Bullet, transform.position, Quaternion.Euler(0, 0, 200-i));
            BulletController bc = instance.GetComponent<BulletController>();
            bc.perspective = gameObject.tag;
            shootTimer = enemy.ShootCooldown;
        }
    }

}

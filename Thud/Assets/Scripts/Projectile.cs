using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public GameObject ParticleFXExplosion;
    // Start is called before the first frame update
    void Awake() //Awake : 오브젝트 생성시, Start : 다음 프레임
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force) //불꽃 발사(방향*힘)
    {
        rigidbody2d.AddForce(direction * force);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 10.0f) //불꽃이 화면 밖으로 나가면 제거
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) //불꽃과 다른 물체 충돌 검사
    {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Destroy(gameObject);
        }
        GroundController ground = other.collider.GetComponent<GroundController>();
        StoneController stone = other.collider.GetComponent<StoneController>();
        if(stone != null)
        {
            Destroy(this.gameObject);
        }
        else if(ground != null)
        {
            Destroy(this.gameObject);
            Instantiate(ParticleFXExplosion, ground.transform.position, Quaternion.identity); //폭발 이펙트 생성
            Destroy(ground.gameObject);
        }
    }
}

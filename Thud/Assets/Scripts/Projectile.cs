using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public GameObject ParticleFXExplosion;
    // Start is called before the first frame update
    void Awake() //Awake : ������Ʈ ������, Start : ���� ������
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force) //�Ҳ� �߻�(����*��)
    {
        rigidbody2d.AddForce(direction * force);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 10.0f) //�Ҳ��� ȭ�� ������ ������ ����
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) //�Ҳɰ� �ٸ� ��ü �浹 �˻�
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
            Instantiate(ParticleFXExplosion, ground.transform.position, Quaternion.identity); //���� ����Ʈ ����
            Destroy(ground.gameObject);
        }
    }
}

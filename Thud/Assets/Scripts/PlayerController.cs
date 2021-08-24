using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 6;
    public int maxBomb = 1;
    public float timeInvincible = 2.0f; //2�� ���� ����
    public int health { get { return currentHealth; } } //Define a Property -> �ٸ� ��ũ��Ʈ���� currentHealth �б⸸ ���� (��� x)
    int currentHealth;
    bool isInvincible; //true=����
    float invincibleTimer; //���� ���� �ð�
    public int bomb { get { return currentBomb; } }
    int currentBomb;

    public GameObject firePrefab; //�Ҳ� ������ ���
    public GameObject bombPrefab; //��ź ������ ���

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentBomb = 0;
    }

    // Update is called once per frame
    void Update() //�� �����Ӹ��� �ѹ��� ȣ�� -> �ð����� �������� x (����� �ð� ����)
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer<0) //���� ���� �ð��� ������
            {
                isInvincible = false; //���� ����
            }
        }
        Vector2 move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if(Input.GetKeyDown(KeyCode.V)) //�Ҳ� �߻�(Space key)
        {
            Launch();
        }

        if(Input.GetKeyDown(KeyCode.B)) //��ź �߻�(B key)
        {
            if(currentBomb == maxBomb)
            {
                Bomb();
                currentBomb--;
            }
            else
            {
                Debug.Log("YOU DON'T HAVE BOMB");
            }
        }
    }

    private void FixedUpdate() //������ �ð� ����(�Ϲ������� rigidbody ���� ��ũ��Ʈ)
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            animator.SetTrigger("Hit");
            if (isInvincible) return; //�����̸� ����
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        if(currentHealth == 0)
        {
            GameControl.instance.PlayerDied();
            Destroy(this);
        }
    }

    public void GetBomb(int amount)
    {
        currentBomb = Mathf.Clamp(currentBomb + amount, 0, maxBomb);
        Debug.Log(currentBomb + "/" + maxBomb);
    }

    void Launch()
    {   //Instantiate : ������ ������Ʈ, ���� ��ġ, ���� ����
        GameObject projectileObject = Instantiate(firePrefab, rigidbody2d.position + Vector2.up * 0.1f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300); //Projectile.cs�� Launch(����, ��) �Լ� ȣ��
        animator.SetTrigger("Launch");
    }

    void Bomb()
    {
        GameObject bombObject = Instantiate(bombPrefab, rigidbody2d.position + Vector2.up * 0.1f, Quaternion.identity);
        BombProjectile bomb = bombObject.GetComponent<BombProjectile>();
        bomb.Bomb(lookDirection, 300);
        animator.SetTrigger("Launch");
    }
}

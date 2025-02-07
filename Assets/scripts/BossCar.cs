using System.Collections;
using UnityEngine;

public class BossCar : MonoBehaviour
{
    private Transform player; // Reference to the player
    public float trackingSpeed = 3f; // Speed at which the car turns toward the player

    [Header("Rush Attack")]
    public GameObject warningArea;
    public float rushSpeed = 10f;
    public float rushDelay = 1f;
    private bool isInvincible = false;
    public Transform rushWarningPoint;
    private Collider2D bossCollider;

    [Header("Missile Attack")]
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;

    [Header("Bullet Attack")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletFireRate = 0.5f;
     [Header("Phase 2 Attacks")]
    public GameObject zombiePrefab; // Assign in Inspector
    public Transform[] zombieSpawnPoints; // Assign in Inspector
    public healthcontroller health;
    
    private void Start()
    {   
        bossCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        StartCoroutine(BossAttackPattern());
    }

    void Update()
    {
        // Rotate towards the player
        if (player)
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, trackingSpeed * Time.deltaTime);
        }
        KeepBossInBounds();
    }
 

void KeepBossInBounds()
{
    Vector3 pos = transform.position;
    float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
    float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

    // Clamp position within screen bounds
    pos.x = Mathf.Clamp(pos.x, screenLeft + 2f, screenRight - 2f);
    pos.y = Mathf.Clamp(pos.y, screenBottom + 2f, screenTop - 2f);

    transform.position = pos;
}

    IEnumerator BossAttackPattern()
    {
        while (true)
        {
            int randomAttack = Random.Range(0, 4); // 0 = Rush, 1 = Missile, 2 = Bullet

            if (randomAttack == 0)
            {
                yield return StartCoroutine(RushAttack());
            }
            else if (randomAttack == 1)
            {
                yield return StartCoroutine(MissileAttack());
            }
            else if(randomAttack==2)
            {
                yield return StartCoroutine(BulletAttack());
            }
            else{
                
                yield return StartCoroutine(ZombieAttack());
            }

            yield return new WaitForSeconds(2f); // Delay before choosing the next attack
        }
    }

    IEnumerator RushAttack()
    {
        isInvincible = true;
        bossCollider.enabled = false;

        for (int i = 0; i < 3; i++)
        {
            ShowWarning(rushWarningPoint.position);
            yield return new WaitForSeconds(rushDelay);

            Vector2 direction = (player.position - transform.position).normalized;
            float rushTime = 1f;
            float elapsedTime = 0f;

            while (elapsedTime < rushTime)
            {
                Vector3 newPosition = transform.position + (Vector3)direction * rushSpeed * Time.deltaTime;
                transform.position = ClampToBounds(newPosition);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        bossCollider.enabled = true;
        while (bossCollider.IsTouchingLayers(LayerMask.GetMask("Boundary")))
{
    transform.position += Vector3.back * 0.1f;  // Move slightly backward
}
        isInvincible = false;
    }
IEnumerator ZombieAttack()
{
     foreach (Transform spawnPoint in zombieSpawnPoints)
        {
            Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(3.5f);
}

    IEnumerator MissileAttack()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject missileObj = Instantiate(missilePrefab, missileSpawnPoint.position, Quaternion.identity);
            missile missileScript = missileObj.GetComponent<missile>();

            if (missileScript != null)
            {
                missileScript.target = player;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator BulletAttack()
    {
        for (int i = 0; i < 10; i++) // Fire 5 bullets per attack
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bossbullet bulletScript = bullet.GetComponent<bossbullet>();

            if (bulletScript != null)
            {
                bulletScript.SetDirection(player.position);
            }

            yield return new WaitForSeconds(bulletFireRate);
        }
    }

    void ShowWarning(Vector2 position)
    {
        GameObject warning = Instantiate(warningArea, position, Quaternion.identity);
        Destroy(warning, rushDelay);
    }
     Vector3 ClampToBounds(Vector3 newPosition)
    {
        float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        newPosition.x = Mathf.Clamp(newPosition.x, screenLeft + 2f, screenRight - 2f);
        newPosition.y = Mathf.Clamp(newPosition.y, screenBottom + 2f, screenTop - 2f);

        return newPosition;
    }
}


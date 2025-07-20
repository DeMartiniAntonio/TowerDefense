using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject player;


    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    private float nextFireTime = 0f;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int towerHp= 100;
    [SerializeField] private int towerDamage = 1;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -120 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 120 * Time.deltaTime);
        }
        
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(2f);
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-100f, 100f), 2, UnityEngine.Random.Range(-100f, 100f));
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        yield return SpawnEnemies();
    }
    private void Shoot()
    {
        GameObject createBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = createBullet.GetComponent<Rigidbody>();
        bulletRb.linearVelocity = firePoint.forward * 100f;
        nextFireTime = Time.time + fireRate;
    }


    public void TakeDamage()
    {
        towerHp -= towerDamage;
        if (towerHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Score()
    {
        score += 1;
        scoreText.text = $"Score: {score}";
    }
}

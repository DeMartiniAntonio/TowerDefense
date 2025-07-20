using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    // Enemy imaju hp i iznad njih se vidi health bar, ako ga pogodi metak,
    // neka mu se smanji hp i neka se vidi na health baru. Ako neprijatelj dodje do player-a neka se playeru smanjih hp i neka se neprijatelj unisti.
    // Neka se neprijatelji spawnaju dok god je player ziv,   highscore se spremi i neka je vidljiv u main menu. Ako netko predje taj highscore, highscore se treba update-at 

    [SerializeField] private float health = 100f;
    private Vector3 focus = new Vector3(0f, 2f, 0f);
   
    
    
    // [SerializeField] private GameObject healthBarPrefab; // Prefab for the health bar

    private void Update()
    {
        Vector3 direction = (focus - transform.position).normalized;
        transform.position += direction * Time.deltaTime * 2f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BoxCollider boxCollider) && !other.gameObject.TryGetComponent(out Turret notTurret))
        {
            health -= 20f;
            if (health < 0f)
            {
                Turret turret = FindObjectOfType<Turret>();
                turret.Score();

                Destroy(gameObject);
            }
            Destroy(other.gameObject);

        }
        if (other.gameObject.TryGetComponent(out BoxCollider collider) && other.gameObject.TryGetComponent(out Turret foundTurret))
        {
            foundTurret.TakeDamage(); 
            Destroy(gameObject);
        }
    }
}

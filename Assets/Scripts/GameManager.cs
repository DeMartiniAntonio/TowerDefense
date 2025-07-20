using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // // Enemy imaju hp i iznad njih se vidi health bar, ako ga pogodi metak,
    // neka mu se smanji hp i neka se vidi na health baru. Ako neprijatelj dodje do player-a neka se playeru smanjih hp i neka se neprijatelj unisti.
    // Neka se neprijatelji spawnaju dok god je player ziv,   highscore se spremi i neka je vidljiv u main menu. Ako netko predje taj highscore, highscore se treba update-at 
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject turret;
    private void Update()
    {

        StartCoroutine(SpawnEnemies());

    }

    private IEnumerator SpawnEnemies()
    {
            yield return new WaitForSeconds(2f); 
            Vector3 spawnPosition = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);     
    }
}

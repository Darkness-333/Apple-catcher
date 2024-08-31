using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenAppleRain : MonoBehaviour {
    [SerializeField] private GameObject goldenApplePrefab;
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private float checkInterval=1;
    void Start() {

        StartCoroutine(SpawnApplesOverTime(spawnRate));
    }

    public void SpawnApple() {
        Vector3 spawnPosition = new Vector3(Random.Range(-20f, 20f), 20, 0);
        GameObject apple = Instantiate(goldenApplePrefab, spawnPosition, Quaternion.identity);
        Destroy(apple.GetComponent<Apple>());

        StartCoroutine(CheckHeightAndDestroy(apple));
    }

    private IEnumerator CheckHeightAndDestroy(GameObject apple) {
        while (true) {
            if (apple.transform.position.y < -20f) {
                Destroy(apple); 
                yield break; 
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }

    private IEnumerator SpawnApplesOverTime(float spawnRate) {
        while (true) {
            SpawnApple();
            yield return new WaitForSeconds(spawnRate); 
        }
    }

}

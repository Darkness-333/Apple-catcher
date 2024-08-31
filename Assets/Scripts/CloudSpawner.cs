using UnityEngine;

public class CloudSpawner : MonoBehaviour {
    [Header("Prefabs")]
    [SerializeField] private GameObject smallCloudPrefab;
    [SerializeField] private GameObject bigCloudPrefab;

    [Header("Small cloud borders")]
    [SerializeField] private float smallCloudBottomPosY;
    [SerializeField] private float smallCloudTopPosY;

    [Header("Big cloud borders")]
    [SerializeField] private float bigCloudBottomPosY;
    [SerializeField] private float bigCloudTopPosY;

    [Header("Clouds z position")]
    [SerializeField] private float smallCloudPosZ;
    [SerializeField] private float bigCloudPosZ;

    [Header("Clouds speed")]
    [SerializeField] private float smallCloudSpeed;
    [SerializeField] private float bigCloudSpeed;

    [Header("Spawn settings")]
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private float spawnPositionX;

    private void Start() {
        InvokeRepeating(nameof(SpawnCloud), spawnRate, spawnRate);
        
    }

    private void SpawnCloud() {
        if (Random.value < .5) {
            GameObject cloud= Instantiate(smallCloudPrefab);
            cloud.transform.position = new Vector3(spawnPositionX, Random.Range(smallCloudBottomPosY,smallCloudTopPosY),smallCloudPosZ);
            cloud.GetComponent<CloudMovement>().speed = smallCloudSpeed;
        }
        else {
            GameObject cloud = Instantiate(bigCloudPrefab);
            cloud.transform.position = new Vector3(spawnPositionX, Random.Range(bigCloudBottomPosY, bigCloudTopPosY), bigCloudPosZ);
            cloud.GetComponent<CloudMovement>().speed = bigCloudSpeed;

        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesSpawner : MonoBehaviour
{
    [SerializeField] private List<FollowTargetAIInput> zombiePrefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private Transform player;
    [SerializeField] private float cooldown;
    private float cooldownTimer;

    private void SpawnZombie()
    {
        var spawnedZombie = Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Count)]);
        spawnedZombie.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        spawnedZombie.SetTarget(player);
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer > cooldown)
        {
            SpawnZombie();
            cooldownTimer = 0;
        }
    }
}

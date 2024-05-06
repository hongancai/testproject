using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormSpawner : MonoBehaviour
{
    public GameObject stormPrefab; // 需要在Unity編輯器中設定的Storm預置物
    public float spawnIntervalMin = 3f; // 最小生成間隔時間
    public float spawnIntervalMax = 10f; // 最大生成間隔時間

    private float timer; // 計時器，用於計算生成新Storm的時間

    void Start()
    {
        timer = Random.Range(spawnIntervalMin, spawnIntervalMax); // 隨機設置初始生成時間
    }

    void Update()
    {
        // 更新計時器
        timer -= Time.deltaTime;

        // 如果計時器小於等於0，生成新Storm並重置計時器
        if (timer <= 0f)
        {
            SpawnStorm();
            timer = Random.Range(spawnIntervalMin, spawnIntervalMax); // 隨機生成新Storm的間隔時間
        }
    }

    void SpawnStorm()
    {
        // 生成新Storm的位置為StormSpawner的位置
        Vector3 spawnPosition = transform.position;

        // 生成新Storm
        GameObject newStorm = Instantiate(stormPrefab, spawnPosition, Quaternion.identity);

        // 將生成的新Storm設置為可移動的
        newStorm.AddComponent<StormMovement>();
    }
}
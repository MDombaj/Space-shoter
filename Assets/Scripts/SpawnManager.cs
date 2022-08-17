using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Spawner{
    public GameObject spawnPrefab;
    [Range(0f,100f)]
    public float chance = 100f;
    [HideInInspector]
    public double weigt;

}

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Spawner[] enemyPrefab;
    private double acumulatedWeight;
    private System.Random rand = new System.Random();

    [SerializeField]
    private GameObject enemyContainer;
    private bool spawnEnemies = true;
    // Start is called before the first frame update
    public void OnHit(){
        StartCoroutine(SpawnRoutine());
    }
    void Start()
    {
        CalculateWeights(enemyPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CalculateWeights(Spawner[] prefab){
        acumulatedWeight = 0f;
        foreach (Spawner item in prefab)
        {
            acumulatedWeight+= item.chance;
            item.weigt=acumulatedWeight;
        }

    }
    private int GetRandomIndex (Spawner[] prefab){
        double r = rand.NextDouble() * acumulatedWeight;
        for (int i = 0; i<prefab.Length;i++)
        
        {
            if (prefab[i].weigt >= r){
                return i ;
                
            }
        }
        return 0 ;

    }
    IEnumerator SpawnRoutine(){
        while (spawnEnemies)
        {
            Spawner rEnemy = enemyPrefab[GetRandomIndex(enemyPrefab)];
            Vector3 spawnPos = new Vector3(Random.Range(-10,10),7,0);
            GameObject enemy = Instantiate(rEnemy.spawnPrefab,spawnPos,Quaternion.identity);
            enemy.transform.SetParent(enemyContainer.transform);
            yield return new WaitForSeconds(5.0f);
        }

    }
    public void OnPlayerDeath(){

        spawnEnemies = false;
    }
}

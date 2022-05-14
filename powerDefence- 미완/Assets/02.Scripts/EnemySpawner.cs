using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float startDelay = 1f;
    [HideInInspector] public int currentStage;
    [System.Serializable]
   public class  SpawnEIement
    {
        public GameObject prefab;
        public int num;
        public float delay;
    }
    [SerializeField] private SpawnEIement[][] spawnEIementsList;

    private float[][] timers;
    private int[][] counts;
    public void Spawn()
    {
        if(currentStage < spawnEIementsList.Length -1)
        StartCoroutine(E_Spawn());
        currentStage++;
    }
    private void Awake()
    {
        timers =new float[spawnEIementsList.Length][];
        counts = new int[spawnEIementsList.Length][];
        for (int i = 0; i < spawnEIementsList.Length; i++)
        {
            timers[i] =new float[spawnEIementsList[i].Length];
            counts[i] = new int[spawnEIementsList[i].Length];

            for (int j= 0; j < spawnEIementsList[i].Length; j++)
            {
                timers[i][j] = spawnEIementsList[i][j].delay;
                counts[i][j] = spawnEIementsList[i][j].num;
            }
        }
    }
    private IEnumerator E_Spawn()
    {
        yield return new WaitForSeconds(startDelay);
        for (int i = 0; i < spawnEIementsList[currentStage].Length; i++)
        {
            //소환할것이 남아있는지?
            if (counts[currentStage][i] >0)
            {
                //소환 딜레이 체크 
                if (timers[currentStage][i] <0)
                {
                    Instantiate(spawnEIementsList[currentStage][i].prefab, WayPoints.instance.GetFirstWayPoint().position, Quaternion.identity);
        counts[currentStage][i]--;
                    timers[currentStage][i]= spawnEIementsList[currentStage][i].delay;
    }
                else
                    timers[currentStage][i] -= Time.deltaTime;
            }
        }
    }

    
       
    
}

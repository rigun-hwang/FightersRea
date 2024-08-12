using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Monsters;
    float Timer;
    public float SpawnTime;
    public GameObject[] spawnPoints;
    public int wave;
    public int monstCount = 0;
    public TextMeshProUGUI WaveText;
    public float Timer2 = 0;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (flag == true)
        {
            Timer2 += Time.deltaTime;
        }
        if (Timer > SpawnTime && monstCount == 0)
        {
            if (flag == false)
            {
                StartCoroutine(SpawnMonster());
            }
           if (Timer2 > 5)
            {
                Timer2 = 0;
                flag = false;
                wave += 1;
                Timer = 0;
            }
        }
    }
    IEnumerator SpawnMonster()
    {
        WaveText.text = "WAVE : " + wave;

        for (int i = 0; i < wave + wave / 2; i++)
        {
            Debug.Log(wave / 2);
            int random1 = Random.Range(0, Monsters.Length);
            if (wave < 3)
            {
                random1 = 0;
            }
            int random = Random.Range(0, spawnPoints.Length);
            Instantiate(Monsters[random1], spawnPoints[random].transform.position, Quaternion.identity);
            monstCount += 1;
            yield return new WaitForSeconds(1f);

        }
        flag = true;



    }


}

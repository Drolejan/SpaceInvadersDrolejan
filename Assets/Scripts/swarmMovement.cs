using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarmMovement : MonoBehaviour
{
    [SerializeField] int swarmSpeed;
    int dir;
    Transform initialPos;
    Transform[] shootPos;
    public GameObject laser;
    public int rate;
    int maxRate;
    public int bonus;
    public GameObject[] enemies;
    [SerializeField] float xoffset, yoffset,colummns,waitTime,shootRate;

    void OnEnable()
    {
        dir = 1;
        bonus = 3;
        initialPos = GameObject.Find("spawnSwarmPoint").GetComponent<Transform>();
        transform.position = initialPos.position;
        StartCoroutine(changeDir());
        StartCoroutine(enemyShoot());
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void Start()
    {
        maxRate = rate;
        for (int i = 0; i < enemies.Length; i++)
        {
            for (int j = 0; j < colummns; j++)
            {
                Vector3 posE = new Vector3(transform.position.x + j * xoffset, transform.position.y + i * yoffset, 0);
                GameObject obj = (GameObject)Instantiate(enemies[i], posE, transform.rotation,transform);
            }
        }
    }

    void Update()
    {
        transform.Translate(new Vector3(swarmSpeed * dir * Time.deltaTime, 0));
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator enemyShoot()
    {
        do
        {
            yield return new WaitForSeconds(shootRate);
            shootPos = GetComponentsInChildren<Transform>();
            Transform randomPos = shootPos[Random.Range(1, shootPos.Length)];
            //Instantiate(laser, randomPos.position, randomPos.rotation);
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Enemy Laser");
            if (bullet != null)
            {
                bullet.transform.position = randomPos.position;
                bullet.transform.rotation = randomPos.rotation;
                bullet.SetActive(true);
            }
        } while (true);
    }

    IEnumerator changeDir()
    {
        do
        {
            yield return new WaitForSeconds(waitTime);
            dir *= -1;
            rate--;
            if (rate<1)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                rate = maxRate;
                if (bonus > 1) bonus--;
            }
        } while (true);
    }
}

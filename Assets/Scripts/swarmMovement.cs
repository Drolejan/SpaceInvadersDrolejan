using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarmMovement : MonoBehaviour
{
    [SerializeField] int swarmSpeed;
    int dir;
    public bool goDown;
    Transform initialPos;

    void OnEnable()
    {
        dir = 1;
        initialPos = GameObject.Find("spawnSwarmPoint").GetComponent<Transform>();
        transform.position = initialPos.position;
        StartCoroutine(changeDir());
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
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

    IEnumerator changeDir()
    {
        do
        {
            yield return new WaitForSeconds(3f);
            dir *= -1;
            if (goDown) transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            goDown = !goDown;
        } while (true);
    }
}

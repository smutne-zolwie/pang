using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningWeapons : MonoBehaviour
{
    public GameObject shotgun, singleGun, doubleGun;
    public int posx, posy;
    Vector2 position;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        posx = Random.Range(-10, 10);
        posy = Random.Range(-2, 6);
        position = new Vector2(posx, posy);
    }

    void Update()
    {
        StartCoroutine(Wait());
        Spawner();
    }

    public void Spawner()
    {
        int i = Random.Range(0, 4);
        if (i == 0)
            Instantiate(shotgun, position, shotgun.transform.rotation);
        else if (i == 1)
            Instantiate(singleGun, position, singleGun.transform.rotation);
        else if (i == 2)
            Instantiate(doubleGun, position, doubleGun.transform.rotation);
    }
}

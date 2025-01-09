using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectDestroyer : MonoBehaviour
{
    public Text dogsLeft;
    public GameObject obj;
    public dogSpawner dogSpawnerClass;
    bool hit = true;

    void Start()
    {
        dogSpawnerClass = obj.GetComponent<dogSpawner>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dog"))
        {
            Destroy(gameObject);
            dogMinusText();
            StartCoroutine(dogMinus());
        }
    }

    void Update()
    {
    }

    void dogMinusText()
    {
        if (hit)
        {
            dogSpawnerClass.dogsAmount--;
            Debug.Log(dogSpawnerClass.dogsAmount);
            dogsLeft.text = dogSpawnerClass.dogsAmount.ToString();
            hit = false;
        }
    }

    public IEnumerator dogMinus()
    {
        yield return new WaitForSeconds(2f);
        hit = true;
    }
}

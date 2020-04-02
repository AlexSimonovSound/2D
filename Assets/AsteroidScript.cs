using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

        

    }

    // Срабатывает при "вхождении"
    // Т.е при столкновении текущго коллайдера с каким-то другим (other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid")

        {

         return;

        }

        if (other.tag == "Player")
        {

            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
        else
        {

            GameControllerScript.instance.incrementScore(10);
        }


        Destroy(gameObject); // Уничтожаем текущий обьект (Астеройд)
        Destroy(other.gameObject); // Уничтожаем второй обьект
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
    }
}

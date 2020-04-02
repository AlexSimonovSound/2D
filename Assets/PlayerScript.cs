using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

      public GameObject laserShot; //чем стрелять

      public Transform laserGunn; //Откуда стрелять
    
      public float shortDelay; //Задержка между выстрелами

      public float xMin, xMax, zMin, zMax;

      public float speed;
      public float tilt;
      Rigidbody playerShip;

    float nextShot; //время следующего выстрела

    //Вызываеться при попадание обьекта на сцену
    //Для обектов, которые уже на сцене по сути при старте игры
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
    }

    // Вызывается каждый новый кадр // Понять что хочет игрок, куда лететь?
    void Update()
    {


        // Понять что хочет игрок, куда лететь?
        float moveHorizontal = Input.GetAxis("Horizontal");   //Куда лететь по горизонтальной оси, влево или вправо
        float moveVertical = Input.GetAxis("Vertical");



        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) *speed;

        playerShip.rotation =  Quaternion.Euler(tilt * playerShip.velocity.z, 0, - tilt * playerShip.velocity.x);

        float newXposition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float newZposition = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        playerShip.position = new Vector3(newXposition, 0, newZposition);

        if (Time.time > nextShot && Input.GetButton("Fire1"))
		{
            Instantiate(laserShot, laserGunn.position, Quaternion.identity);
            nextShot = Time.time + shortDelay;
        }
        

    }
}

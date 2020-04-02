using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    //срабатывает при "Выходе" , обьект который "Вызодит" будет в other
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); // Каждый обект, который покинул границы будет уничтожен
    }

}

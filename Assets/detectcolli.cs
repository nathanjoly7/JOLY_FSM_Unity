using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectcolli : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // V�rifier si l'objet en collision a le tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // D�marrer la destruction apr�s 2 secondes
            StartCoroutine(SelfDestruct());
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f); // Attendre 2 secondes
        Destroy(gameObject); // D�truire cet objet
        Debug.Log("L'ennemi s'est autod�truit !");
    }
}

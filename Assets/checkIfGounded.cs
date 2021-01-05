using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfGounded : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (!Physics.Raycast(ray))
        {
            GameObject.FindObjectOfType<ChefDeProjet>().loose();
            Destroy(this.gameObject);
        }

    }
}

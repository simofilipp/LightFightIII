using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoScript : Item
{
    private void OnCollisionEnter(Collision collision)
    {
        //derivo la classe da item in modo da settare il damage, il player andrà a leggere questo valore per subire danni
        Debug.Log(collision.gameObject.name);

        //distruggo il disco nel caso vada contro un muro invisibile
        if(collision.gameObject.tag== "RestartFuocoNemico")
        {
            Destroy(this.gameObject);
        }
    }
}

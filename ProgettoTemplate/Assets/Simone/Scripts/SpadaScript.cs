using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadaScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DiscoNemico")
        {
            var discoColpito = collision.gameObject;
            discoColpito.GetComponent<CapsuleCollider>().enabled = true;
            GameManager.Instance.dischiDistrutti += 1;
            Destroy(discoColpito);
            //fare in modo che il disco si disfi prima di distruggerlo
        }
    }
}

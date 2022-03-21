using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadaScript : MonoBehaviour
{
    [SerializeField] Transform slotSpada;
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

        if (collision.gameObject.tag == "Floor")
        {
            //respawnare la spada nel porta spade e spegnere lo use gravity e comunicare che siamo senza spada se non ci troviamo già in fase di attacco
            RiposizionaSpada();
        }
    }

    private void RiposizionaSpada()
    {
        var rbSpada = GetComponent<Rigidbody>();
        rbSpada.useGravity = false;
        rbSpada.velocity = Vector3.zero;
        rbSpada.angularVelocity = Vector3.zero;
        gameObject.transform.position = slotSpada.position;
        gameObject.transform.rotation = slotSpada.rotation;
        GameManager.Instance.disarmato = true;
    }

    public void AttivaGravità()
    {
        //viene chiamato quando prendo in mano la spada e sono pronto a difendermi
        GetComponent<Rigidbody>().useGravity = true;
        GameManager.Instance.disarmato = false;
        GameManager.Instance.RiprendiFuocoNemico();
    }
}

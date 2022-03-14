using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpostaDischiScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float potenzaSpostamento;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DiscoNemico")
        {
            var disco = other.gameObject;
            disco.transform.LookAt(player.transform);
            disco.GetComponent<Rigidbody>().AddForce(disco.transform.forward * potenzaSpostamento, ForceMode.Impulse);
        }
    }
}

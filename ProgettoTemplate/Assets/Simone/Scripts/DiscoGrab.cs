using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiscoGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<XRGrabInteractable>().
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RestartFuocoNemico")
        {
            //se non afferro o manco il nemico il disco si distrugge e il nemico torna a spararmi
            GameManager.Instance.CambiaFaseGioco();
            GameManager.Instance.RiprendiFuocoNemico();
            Destroy(this.gameObject);
        }
    }
}

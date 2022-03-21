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
            //deve riprendere il fuoco nel caso io distrugga questo disco
        if (collision.gameObject.tag == "RestartFuocoNemico" || collision.gameObject.tag == "Sword")
        {
            //fare scomparire temporaneamente la spada mentro lo ho in mano

            //effetto quando il disco si scontra

            //se non afferro o manco il nemico il disco si distrugge e il nemico torna a spararmi
            //GameManager.Instance.CambiaFaseGioco(FaseDiGioco.FaseDiDifesa);
            GameManager.Instance.RiprendiFuocoNemico();
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> cannoni;
    [SerializeField] GameObject discoLaser;
    [SerializeField] GameObject discoGrab;
    [SerializeField] GameObject player;
    [SerializeField] float forzaEsplosione;
    [SerializeField] float rateoDiFuoco;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FuocoNemico());
    }

    // Update is called once per frame
    void Update()
    {
        //nemico rivolto verso il player
        transform.LookAt(player.transform.position);

    }

    IEnumerator FuocoNemico()
    {
        while (GameManager.Instance.faseCorrente==FaseDiGioco.FaseDiDifesa)
        {
            //prendo un puntatore a caso tra i cannoni
            var puntatoreCasuale = cannoni[Random.Range(0, cannoni.Count)].transform.GetChild(0);
            //istanzio un disco laser e lo sparo
            GameObject colpo;
            if (GameManager.Instance.lanciaDiscoGrab)
            {
                //spara il disco grabbabile e si cambia fase di gioco
                colpo = Instantiate(discoGrab, puntatoreCasuale.position, puntatoreCasuale.rotation);
                GameManager.Instance.lanciaDiscoGrab = false;
                GameManager.Instance.CambiaFaseGioco();
                
            }
            else
            {
                colpo = Instantiate(discoLaser, puntatoreCasuale.position, puntatoreCasuale.rotation);
                Destroy(colpo, 4f);
            }
            colpo.GetComponent<Rigidbody>().AddForce(puntatoreCasuale.forward*forzaEsplosione, ForceMode.VelocityChange);
            yield return new WaitForSeconds(rateoDiFuoco);
        }
    }

    public void RiprendiFuoco()
    {
        StartCoroutine(FuocoNemico());
    }
}

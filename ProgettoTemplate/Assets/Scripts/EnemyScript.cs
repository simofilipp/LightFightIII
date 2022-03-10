using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> cannoni;
    [SerializeField] GameObject discoLaser;
    [SerializeField] GameObject player;
    [SerializeField] float forzaEsplosione;

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
        while (1 > 0)
        {
            //prendo un puntatore a caso tra i cannoni
            var puntatoreCasuale = cannoni[Random.Range(0, cannoni.Count)].transform.GetChild(0);
            //istanzio un disco laser e lo sparo
            var colpo = Instantiate(discoLaser, puntatoreCasuale.position, puntatoreCasuale.rotation);
            colpo.GetComponent<Rigidbody>().AddForce(puntatoreCasuale.forward*forzaEsplosione, ForceMode.Impulse);
            Destroy(colpo, 3f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}

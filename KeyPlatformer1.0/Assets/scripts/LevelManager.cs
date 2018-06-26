using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private PlayerController player;

    public GameObject checkPoint;
    public GameObject dethPartical;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void respawn() {
        StartCoroutine("StartRespawn");
    }

    public IEnumerator StartRespawn() {
        Instantiate(dethPartical, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.transform.position = checkPoint.transform.position;
    }
}

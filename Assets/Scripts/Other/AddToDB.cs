using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToDB : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DoQuery());
	}
	
	IEnumerator DoQuery()
    {
        WWW request = new WWW("http://22271.hosts.ma-cloud.nl/bewijzenmap/p2.1/gpr/opdracht_3/index.php?t_x=1&t_y=2&t_z=400&p_id=20");
        yield return request;
    }
}

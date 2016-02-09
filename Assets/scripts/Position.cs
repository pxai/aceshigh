using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	// It will mark all the useful thing for developers
	void onDrawGizmosSelected() {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (this.transform.position,5f);
	}
}

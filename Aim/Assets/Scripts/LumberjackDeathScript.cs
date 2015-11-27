using UnityEngine;
using System.Collections;

public class LumberjackDeathScript : MonoBehaviour {
    
    //Made by Danny Kruiswijk

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bomb : NetworkBehaviour
{
    public float explosionRadius = 5f;
    public float explodeDelay = 1.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void Start()
    {
        StartCoroutine(Explode());
    }

    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(explodeDelay);
        CmdExplode(transform.position, explosionRadius);
    }

    [Command]
    void CmdExplode(Vector3 pos, float rad)
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            NetworkServer.Destroy(hit.gameObject);
        }
    }
}

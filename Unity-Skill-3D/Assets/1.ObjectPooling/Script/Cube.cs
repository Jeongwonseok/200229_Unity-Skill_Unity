using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody m_myrigid = null;

    private void OnEnable()
    {
        if(m_myrigid == null)
        {
            m_myrigid = GetComponent<Rigidbody>();
        }

        m_myrigid.velocity = Vector3.zero;
        // 활성화 될때마다 폭발하듯 날아가도록 하는 함수 호출 - AddExplosionForce()
        m_myrigid.AddExplosionForce(1000, transform.position, 1f);

        StartCoroutine(DestroyCube());
    }

    IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(1f);
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }
}

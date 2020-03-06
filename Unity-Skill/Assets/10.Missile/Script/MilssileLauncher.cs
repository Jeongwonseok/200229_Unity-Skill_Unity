using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilssileLauncher : MonoBehaviour
{
    // 미사일 프리펩
    [SerializeField] GameObject m_goMissile = null;
    // 발사될 위치 변수 선언
    [SerializeField] Transform m_tfMissileSpawn = null;

    // Update is called once per frame
    void Update()
    {
        // 스페이스바 >> 미사일 생성 >> 위로 날림
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject t_missile = Instantiate(m_goMissile, m_tfMissileSpawn.position, Quaternion.identity);
            t_missile.GetComponent<Rigidbody>().velocity = Vector3.up * 10f;
        }
    }
}

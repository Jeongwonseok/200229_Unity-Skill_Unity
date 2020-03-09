using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // 카메라의 흔들림 세기를 결정지을 변수
    [SerializeField] float m_force = 0f;
    // 카메라의 방향을 결정할 변수
    [SerializeField] Vector3 m_offset = Vector3.zero;

    // 카메라의 초기값을 저장할 변수
    Quaternion m_originRot;

    // Start is called before the first frame update
    void Start()
    {
        m_originRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(ShakeCoroutine());
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            StopAllCoroutines();
            StartCoroutine(Reset());
        }
    }

    // 흔들림 구현 코루틴
    IEnumerator ShakeCoroutine()
    {
        // 카메라의 오일러 초기값 지정
        Vector3 t_originEuler = transform.eulerAngles;

        // 벡터 축 마다 랜덤값 부여
        while(true)
        {
            float t_rotX = Random.Range(-m_offset.x, m_offset.x);
            float t_rotY = Random.Range(-m_offset.y, m_offset.y);
            float t_rotZ = Random.Range(-m_offset.z, m_offset.z);

            // 흔들림 값 = 초기값 + 랜덤값
            Vector3 t_randomRot = t_originEuler + new Vector3(t_rotX, t_rotY, t_rotZ);

            // !! 흔들림 값을 쿼터니온으로 변환 !! >> 실질적으로 쓰이는 값
            Quaternion t_rot = Quaternion.Euler(t_randomRot);

            // 목적값까지 움직일때까지 반복 >> 이 과정이 반복되며 랜덤하게 흔들리게 된다!
            while(Quaternion.Angle(transform.rotation, t_rot) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, m_force * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }

    // 초기값으로 자연스럽게 되돌리는 코루틴
    IEnumerator Reset()
    {
        while (Quaternion.Angle(transform.rotation, m_originRot) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_originRot, m_force * Time.deltaTime);
            yield return null;
        }
    }
}

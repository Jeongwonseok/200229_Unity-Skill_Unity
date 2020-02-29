using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarScript : MonoBehaviour
{
    [SerializeField] GameObject m_goPrefab = null;

    // 몬스터 위치를 담을 리스트 선언
    List<Transform> m_objectList = new List<Transform>();

    // Hp바를 담을 리스트 선언
    List<GameObject> m_hpBarList = new List<GameObject>();

    // 메인 카메라 변수 선언
    Camera m_cam = null;

    // Start is called before the first frame update
    void Start()
    {
        // Camera.main = 메인카메라로 태그 지정된 카메라를 뜻함
        m_cam = Camera.main;

        // Player 태그의 객체들을 배열에 저장
        GameObject[] t_object = GameObject.FindGameObjectsWithTag("Player");

        // 배열의 개수만큼 몬스터 위치 리스트에 저장
        for (int i=0; i<t_object.Length; i++)
        {
            m_objectList.Add(t_object[i].transform);

            // 몬스터 위치에 HP바 프리펩 생성
            GameObject t_hpbar = Instantiate(m_goPrefab, t_object[i].transform.position, Quaternion.identity, transform);
            // 생성된 객체는 HP바 리스트에 추가 
            m_hpBarList.Add(t_hpbar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<m_objectList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1.25f, 0));
        }
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    // 이동시킬 방향과 스피드를 결정할 벡터 선언
    [SerializeField] Vector2 m_offset = Vector2.zero;

    // 메테리얼 정보가 담긴 변수 선언
    MeshRenderer m_mesh = null;

    // Start is called before the first frame update
    void Start()
    {
        m_mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_mesh.material.mainTextureOffset += m_offset * Time.deltaTime;
    }
}

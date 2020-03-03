using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 좌클릭 입력을 감지
        if(Input.GetMouseButtonDown(0))
        {
            // 클릭한 카메라 마우스 좌표에서 Ray를 발사
            Ray t_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit t_hit;

            // Ray에 닿은 객체의 Explosion 함수 호출
            if(Physics.Raycast(t_ray, out t_hit, 100f))
            {
                t_hit.transform.GetComponent<Cube2>().Explosion();
            }
        }
    }
}

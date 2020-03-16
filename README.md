Unity-Skill (Unity2D, Unity3D)
======================

# 1. 목적
Unity 엔진과, 유튜브 강좌를 이용해서 게임에 활용할 12가지의 Unity 스킬을 학습한다.

****
# 2. 개발 범위
* Object Pooling (오브젝트 풀링)

* HP Bar (HP 막대)

* Explosion Debris (폭발 파편)

* Infinite Background (무한 배경)

* Texture Scrolling (텍스쳐 스크롤링)

* Camera Shaking (카메라 흔들림)

* Parabola Shoot (포물선 발사)

* Camera Zoom & Move (카메라 줌 & 이동)

* Auto Turret (오토 터렛)

* Missile (미사일 발사)

* N * Jump (N단 점프)

* AI Patrol (AI 순찰)

****
# 3. 개발 환경
* Unity 2019.2.9f1 Personal
* Visual Studio 2019

****
# 4. 주요 구현부
## 4.1. 오브젝트 풀링
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object1.png" width="678" height="336"><br>
</p>

```
* 설명
- 오브젝트 풀링으로 쓸 객체 변수를 선언한다.
- 객체를 저장시킬 풀(큐)를 생성한다.
- 객체를 생성한 뒤, 시작과 동시에 풀(큐)에 저장한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object2.png" width="330" height="220"><br>
</p>

```
* 설명
- 사용한 객체를 풀(큐)에 반납시키는 함수를 생성한다.
- 풀(큐)에서 객체를 빌려오는 함수를 생성한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object3.png" width="547" height="290"><br>
</p>

```
* 설명
- 미리 풀(큐)에 저장된 객체를 꺼낸다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object4.png" width="516" height="366"><br>
</p>

```
* 설명
- 활성화 될때마다 폭발하듯 날아가도록 하는 함수 (AddExplosionForce()) 이용해서 폭발 구현
- 1초마다 생성된 큐브를 풀(큐)에 반납시켜 효율성을 높인다.
```

## 4.2. HP 막대
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/hp1.png" width="427" height="185"><br>
</p>

```
* 설명
- 생성되는 몬스터 위치와 HP Bar를 담을 리스트를 각각 선언한다.
- 메인 카메라 변수를 선언한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/hp2.png" width="851" height="306"><br>
</p>

```
* 설명
- 게임 오브젝트 배열을 선언하고, "Player" 태그를 찾아 저장한다.
- 게임 오브젝트 배열의 개수만큼 몬스터 위치 리스트에 오브젝트 위치를 저장한다.
- 몬스터 위치에 HP Bar 프리펩을 생성하고, 생성된 객체는 HP Bar 리스트에 추가한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/hp3.png" width="893" height="139"><br>
</p>

```
* 설명
- HP Bar가 몬스터 머리 위를 계속 따라다니도록 WorldToScreenPoint() 함수를 이용해, 매 프레임마다 업데이트 해준다.
```

## 4.3. 폭발 파편
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/Deb1.png" width="362" height="134"><br>
</p>

```
* 설명
- 파편 프리펩을 담을 변수를 선언한다.
- 파편이 날아갈 세기를 결정해주는 변수를 선언한다.
- 파편이 날아갈 위치에 영향을 주는 변수를 선언한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/Deb2.png" width="659" height="231"><br>
</p>

```
* 설명
- 파편 프리펩을 자기 자신의 위치로 생성한다.
- 자식 객체 큐브들의 RigidBody를 배열에 넣는다.
- 모든 큐브들을 AddExplosionForce() 함수를 이용해 폭발시킨다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/Deb3.png" width="514" height="259"><br>
</p>

```
* 설명
- 좌클릭 입력 시, 클릭한 카메라 마우스 좌표에서 Ray를 발사한다.
- Ray에 닿은 객체의 Explosion() 함수를 호출한다.
```

## 4.4. 무한 배경
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/Background1.png" width="410" height="199"><br>
</p>

```
* 설명
- 배경을 담을 변수를 선언한다.
- 스크롤 속도 변수를 선언한다.
- 카메라 왼쪽 너머의 X 좌표를 선언하고, 다시 등장시킬 X 좌표를 선언한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/Background2.png" width="671" height="154"><br>
</p>

```
* 설명
- 배경의 이미지 가로 사이즈를 저장하고, 이미지 길이만큼 벗어나면 사라지도록 한다.
- 총 배경의 길이 = 이미지 길이 * 갯수
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/Background3.png" width="607" height="243"><br>
</p>

```
* 설명
- 배경이 1초에 m_speed 속도만큼 왼쪽으로 이동한다.
- 배경이 왼쪽 너머로 사라지면 오른쪽 너머로 다시 등장시킨다.
```

## 4.5. 텍스쳐 스크롤링
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/tex1.png" width="527" height="312"><br>
</p>

```
* 설명
- 이동시킬 방향과 스피드를 경정할 벡터 변수를 선언한다.
- Matetial 정보가 담긴 변수를 선언하고, 시작과 동시에 생성한다.
- 매 프레임마다 Material Offset을 m_offset 변수의 값만큼 이동시킨다.
```

## 4.6. 카메라 흔들림
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/camera1.png" width="392" height="145"><br>
</p>

```
* 설명
- 카메라의 흔들림 세기를 결정짓는 변수를 선언한다.
- 카메라의 방향을 결정하는 변수를 선언한다.
- 카메라의 초기값을 저장할 Quaternion 변수를 선언한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/camera2.png" width="810" height="427"><br>
</p>

```
* 설명
- 카메라의 오일러 초기값을 지정한다.
- 벡터의 축 마다 랜덤값을 부여한다.
- 흔들림 값 = 초기값 + 랜덤값
- 흔들림 값을 Quaternion으로 변환한다.
- 목적값까지 움직일때까지 while()문을 통해 반복한다. (이 과정이 반복되며 랜덤하게 흔들림) (RotateTowards() 함수 이용)
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/camera3.png" width="828" height="144"><br>
</p>

```
* 설명
- 초기값으로 자연스럽게 되돌리는 함수를 구현한다. (RotateTowards() 함수 이용)
```

## 4.7. 포물선 발사
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/arrow1.png" width="387" height="202"><br>
</p>

```
* 설명
- 화살 프리펩, 화살 Transform 변수를 선언한다.
- Main 카메라를 생성 및 정의한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/arrow2.png" width="818" height="461"><br>
</p>

```
* 설명
- 스크린상의 마우스 좌표를 게임상의 2D좌표로 치환한다. (ScreenToWorldPoint() 함수 이용)
- 활이 마우스를 바라보는 방향 = 활 좌표 - 월드 상의 마우스 좌표
- 활의 x축(오른쪽)을 바라볼 방향으로 설정한다. 즉, 월드 공간에서 Transform의 빨간색 축을 바뀐 방향으로 설정한다.
- 좌클릭 입력 시, 발사하는 함수를 구현한다.
- 활 위치에 화살 프리펩 생성하고, 날아가는 속력을 x축 * 10으로 지정한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/arrow3.png" width="815" height="158"><br>
</p>

```
* 설명
- 화살이 날아가면서 계속 그 정보를 업데이트하고, 영향을 받도록 한다.
- velocity 벡터에는 속도와 방향 정보가 담겨져있다.
```

## 4.8. 카메라 줌 & 이동
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/zoom1.png" width="336" height="130"><br>
</p>

```
* 설명
- 카메라 줌의 속도, 줌의 한계 위치값 변수를 선언한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/zoom2.png" width="557" height="461"><br>
</p>

```
* 설명
- 마우스 휠을 앞으로 굴리면 -1, 뒤로 굴리면 1을 반환한다. (GetAxis("Mouse ScrollWheel"))
- Zoom In & Out 시, 카메라 y값이 한계값보다 작아지거나, 커지면 함수를 종료한다.
- 카메라 위치 = 카메라 위치 + (정면벡터 * 방향 * 스피드)
- 마우스 휠 클릭 시, 상하좌우로 마우스를 움직이면 카메라의 위치도 따라 움직인다.
```

## 4.9. 오토 터렛
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/auto1.png" width="767" height="411"><br>
</p>

```
* 설명
- 객체 주변의 Collider를 검출한다. (OverlapSphere() 함수 이용)
- 가장 긴 길이를 기준으로 가장 짧은 거리를 검출한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/auto2.png" width="956" height="488"><br>
</p>

```
* 설명
- 가장 짧은 거리의 좌표를 바라보는 회전값을 저장한다. (LookRotation() 함수 이용)
- 터렛을 계속 회전시킨다. (RotateTowards() 함수 이용)
- 오일러값에서 y축만 반영되게 수정한뒤 Quaternion으로 변환한다.
- 터렛이 조준해야하는 최종 방향을 저장하고, 총알을 발사한다.
```

## 4.10. 미사일 발사
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/mis1.png" width="766" height="238"><br>
</p>

```
* 설명
- 미사일 프리펩, 발사될 위치 변수를 선언한다.
- 스페이스바를 누르면 미사일이 생성되고, 위로 퉁 날아간다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/mis2.png" width="624" height="173"><br>
</p>

```
* 설명
- 주변 반경 100m 내의 특정 콜라이더를 검출한다. (OverlapSphere() 함수 이용)
- 검출된 것들 중 하나를 랜덤으로 표적 설정한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/mis3.png" width="459" height="201"><br>
</p>

```
* 설명
- 미사일 velocity의 y값이 0 이하가 될 때까지 대기하도록한다.
- 만약 검출하지 못하는 경우, 미사일을 파괴한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/mis4.png" width="575" height="386"><br>
</p>

```
* 설명
- 표적이 있으면 미사일을 위로 가속한다.
- 미사일의 방향과 거리를 산출한다. (표적 위치 - 미사일 위치) -> 거리는 필요없으므로, 방향만 사용한다. (normalized)
- y축을 Lerp() 함수를 이용해 부드럽게 꺾는다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/mis5.png" width="501" height="150"><br>
</p>

```
* 설명
- 미사일이 태그가 "Enemy"인 콜라이더와 충돌하면 해당 미사일과 Enemy를 파괴한다.
```

## 4.11. N단 점프
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/jump1.png" width="560" height="313"><br>
</p>

```
* 설명
- 점프 세기, 점프 가능 횟수, 현재 점프 시도 횟수 변수를 선언한다.
- Ray의 거리를 저장해주는 변수를 선언하고, 플레이어의 발밑 거리를 저장한다. (플레이어의 발밑 = Collider y축 절반 크기)
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/jump2.png" width="776" height="458"><br>
</p>

```
* 설명
- 스페이스 바 입력 시, 위로 점프를 하고, 점프 시도 횟수를 증가한다.
- 발 밑에 땅이 있는지 체크한다.
- y축 속도가 0 미만이면 -> 아래로 Ray를 쏜다. -> 닿은 오브젝트의 태그가 "Ground"이면 현재 점프 시도 횟수를 초기화한다.
```

## 4.12. AI 순찰
<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/ai1.png" width="518" height="235"><br>
</p>

```
* 설명
- AI의 속도가 0이 되면, 다음 지역을 정찰한다.
- 마지막 인덱스에서 처음 인덱스로 다시 리셋한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/ai2.png" width="372" height="206"><br>
</p>

```
* 설명
- SetTarget() -> 위험을 감지하면, 기존의 순찰을 취소하고, 타겟을 지정한다.
- RemoveTarget() -> 위험을 감지가 해제되면, 지정한 타겟을 취소하고, 순찰을 실행한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/ai3.png" width="322" height="275"><br>
</p>

```
* 설명
- 위험지역으로 달려갈 Enemy를 태그를 이용해 검출한다. (OnTriggerEnter() & OnTriggerExit() 오버라이딩)
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/ai4.png" width="382" height="235"><br>
</p>

```
* 설명
- 적이 등장했다면, 적의 위치로 AI를 이동시킨다.
```
 
****
# 5. 참고
* 게임 플레이 영상 : https://www.youtube.com/watch?v=eBJxQg2OESA
* 참고 URL : https://www.youtube.com/watch?v=Qc-JfTpZ5qg&list=PLUZ5gNInsv_PZPDqJSs6IQVRFPQTbf9t6&index=1

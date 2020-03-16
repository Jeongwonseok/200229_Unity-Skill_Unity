Unity-Skill (Unity2D, Unity3D)
======================

# 1. 목적
Unity 엔진과, 유튜브 강좌를 이용해서 게임에 활용할 12가지의 Unity 스킬을 학습한다.

****
# 2. 개발 범위
* Object Pooling (오브젝트 풀링)

* HP 막대

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
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object1.png" width="500" height="500"><br>
</p>

```
* 설명
- 오브젝트 풀링으로 쓸 객체 변수를 선언한다.
- 객체를 저장시킬 풀(큐)를 생성한다.
- 객체를 생성한 뒤, 시작과 동시에 풀(큐)에 저장한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object2.png" width="500" height="500"><br>
</p>

```
* 설명
- 사용한 객체를 풀(큐)에 반납시키는 함수를 생성한다.
- 풀(큐)에서 객체를 빌려오는 함수를 생성한다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object3.png" width="500" height="500"><br>
</p>

```
* 설명
- 미리 풀(큐)에 저장된 객체를 꺼낸다.
```

<p align="center">
<img src="https://github.com/Jeongwonseok/Portfolio_JWS/blob/master/image/Skill/object4.png" width="500" height="500"><br>
</p>

```
* 설명
- 활성화 될때마다 폭발하듯 날아가도록 하는 함수 (AddExplosionForce()) 이용해서 폭발 구현
- 1초마다 생성된 큐브를 풀(큐)에 반납시켜 효율성을 높인다.
```
 
****
# 5. 참고
* 게임 플레이 영상 : https://www.youtube.com/watch?v=eBJxQg2OESA
* 참고 URL : https://www.youtube.com/watch?v=Qc-JfTpZ5qg&list=PLUZ5gNInsv_PZPDqJSs6IQVRFPQTbf9t6&index=1

# Thud
### 게임 설명
- 제목 : Thud (쿵)
- 장르 : 어드벤처 게임
- 시나리오 : 주인공은 마을의 보물들을 훔쳐 달아난 몬스터 집단을 소탕하고 그들에게서 보물을 되찾는다.
- 플레이 방법

- 움직임 : 방향키를 이용하여 캐릭터의 방향을 조절한다. 

- 공격
   > v키 : 불꽃 공격 (몬스터 공격, 땅 부수기)

   > b키 : 폭탄 공격 (돌 부수기) 
   >> 폭탄 아이템이 있으면 공격 가능  
   >> 최대 1개의 폭탄만 가지고 있을 수 있다.

   > 공격 방향 : 캐릭터의 움직임과 같은 방향으로 공격한다.

<br>

### 게임월드 구성 및 주요 기능
- player 🦊
  1. 기본 공격으로 불꽃 공격이 가능하며 무제한 사용 가능
  2. 기본 체력은 6이며 적과 부딫히면 -1 (단, 한번 부딫히면 2초동안 무적상태가 됨)
  3. 최대 체력이 아닌 경우 체력 아이템을 먹을 수 있고, 체력이 +1 됨
  4. 폭탄 아이템을 얻어 폭탄 공격이 가능하며 최대 1개까지 가지고 있을 수 있음
  5. 상하좌우 움직임이ㅣ 가능 (왼쪽 이동시 왼쪽 모습, 오른쪽 이동시 오른쪽 모습이 보임)
  6. 불꽃 / 폭탄 공격을 하면 공격을 하는 모션을 취함
  7. 적 (monster / ghost) 과 부딫히면 공격을 당한 모션을 취함
   
<br>

- monster 💀
  1. 좌, 우로 이동하며 player와 충돌하면 player의 체력이 -1 됨
  2. player의 기본 공격인 불꽃 공격을 받으면 죽으며 사라짐
  3. 왼쪽으로 이동시 왼쪽 모습을 보이고 오른쪽 이동시 오른쪽 모습이 보임

<br>

- ghost 👻
  1. 상, 하로 움직이며 player와 부딪히면 player의 체력이 -1 됨
  2. monster와 다르게 어떠한 공격도 받지 않음

<br>

- ground 🟫
  1. ghost를 가두어 두는 역할을 함
  2. player의 기본 공격인 불꽃 공격을 받으면 폭발하며 파괴됨

<br>

- bomb item 💣
  1. player가 최대 1개까지 먹을 수 있는 아이템

<br>

- fire projectile 🔥
  1. player 기본 공격 시 나가는 불꽃 공격
  2. monster와 부딪히면 폭발을 하며 사라짐
  3. ground와 부딪히면 폭발을 하며 사라짐
  4. stone과 부딪히면 아무런 효과 없이 불꽃이 사라짐
  5. 불꽃이 화면을 벗어나면 해당 오브젝트가 사라짐

<br>

- bomb projectile 💣
  1. player 폭탄 공격 시 나가는 projectile
  2. stone과 부딪히면 폭발을 하며 사라짐

<br>

- gem 💎
  1. player와 접촉하면 player가 먹을 수 있음
  2. '빨, 주, 노, 초, 파, 남, 보' 순서를 반복하며 반짝거림

<br>

- UI health bar 💚
  1. player의 체력을 사용자에게 보여줌

<br>

- UI gem bar 💎
  1. player가 지금까지 모음 gem의 수를 사용자에게 보여줌

<br>

- explosion 💥
  1. 사용자의 불꽃 / 폭탄 공격으로 일어난 폭발을 보여줌

<br>

- game control 🎮
  1. player의 체력이 0이 되면 game over 화면을 띄워줌
  2. 사용자가 game over 화면을 클릭하면 다시 게임을 시작
  3. player가 모은 gem의 개수가 최대(5개)가 되면 you win 화면을 띄워줌
  4. 사용자가 you win 화면을 클릭하면 다시 게임을 시작

<br>

### 게임 실행 화면 캡처
- 게임 시작 화면
![그림1](https://user-images.githubusercontent.com/69156709/130645044-62108858-9725-49c6-bda2-8acd69d492e8.png)
- 적군과 충돌한 화면
![그림1](https://user-images.githubusercontent.com/69156709/130650982-2e65f15b-7ca9-44a4-b735-a66f44d280b2.png)
- ground와 불꽃 공격 충돌, 폭발 화면
![그림1](https://user-images.githubusercontent.com/69156709/130651183-02f0f146-d9df-43cd-b238-ede35ee9730c.png)
- game over 화면 (체력바의 체력 0인 상태)
![그림1](https://user-images.githubusercontent.com/69156709/130651300-485bc1ab-75b2-41a2-a477-54d0fbfef523.png)
- 폭탄 공격과 stone 충돌, 폭발 화면
![그림1](https://user-images.githubusercontent.com/69156709/130651814-c2f6eb47-10bf-4ecb-a2ce-ae0fa63d5c8e.png)
- you win 화면 (gem bar의 gem이 모두 모인 상태)
![그림1](https://user-images.githubusercontent.com/69156709/130651900-da608f15-6a72-4638-b2ee-f7c9b5cd44c1.png)

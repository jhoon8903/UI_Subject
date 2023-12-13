4주차 개인과제
--

- Console Game을 Unity로 구현
- 상태창, 인벤토리창, 상점창 구현이 목적

개발환경
--

|분류|설명|
|:--:|:--:|
|OS|Mac|
|IDE|Rider|
|Unity Ver.|2022.3.2f1|
|Assets| - Addressables<br>  - Newtonsoft Json|


구현기술
--

### Addressables 이용한 리소스 관리

- 게임상의 거의 모든 오브젝트를 프리팹화
- 게임 시작시 로드하는 방식을 사용
- 추후 협업에서 충돌 최소화
- 게임 시작시  `PreLoad` 라벨로 데이터 로드


### UI Binding

- UI는 프리팹을 단독적인 Canvas를 사용하여 각 인스턴스마다 하나의 Canvas를 가지고 있음
- 각각의 객체를 인스턴스화 하는 방식을 사용하여 UI 구현
- UI는 내부에서 enum으로 정의 된 Key, Type을 가지고 바인딩 하여 사용
- 모든 UI는 UI Base를 상속받습니다.


확인된 버그
--

#### Sprite Mode

- Sprite 의 경우 SigleMode의 Sprite는 문제 없지만, 
- Multiple Mode의 Sprite의 경우 로드 되지 않는 문제


구현중 사항 및 예정사항
--

- 아이템 선택 시 장착 해제 팝업 작업 중
- 상점 객체 인스턴스화 작업 예정
- 케릭터 드래스업 예정

![](https://i.imgur.com/iIFbkiZ.jpg)

![](https://i.imgur.com/3nmo6Hi.jpg)

![](https://i.imgur.com/XYUrLe4.jpg)

![](https://i.imgur.com/f1B0cAa.jpg)

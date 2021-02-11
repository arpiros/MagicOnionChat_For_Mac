# MagicOnion_For_mac

## 주의사항
- 맥 환경에서 slnMerge를 이용해서 프로젝트를 합칠 경우, MagicOnionMac.Server프로젝트의 의존성이 깨지는 문제가 발생함.   
    - 해당 문제는 `Use MSbuild Version`을 15에서 16으로 수정하면 해결됨
# MagicOnion_For_mac

## Required
- .Net 5.0
- .Net Core 3.1

## 작업환경
- Mac Big Sur (M1 Macbook Air)
- Rider 2020.3
- Unity 2020.2.3f1

## 주의사항
1. 맥 환경에서 slnMerge를 이용해서 프로젝트를 합칠 경우, MagicOnionMac.Server프로젝트의 의존성이 깨지는 문제가 발생함.   
    - 해당 문제는 `Use MSbuild Version`을 15에서 16으로 수정하면 해결됨
  
2. 맥 환경에서 `grpc_csharp_ext` 관련에러가 발생할 경우
   - `시스템 환경설정 -> 보안 및 개인 정보 보호`에서 사용할함 수 있도록 설정해주어야 
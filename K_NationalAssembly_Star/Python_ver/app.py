import App

def menu():
    # 기능별 작동
    while True:
        print("무엇을 하시겠습니까? \n")
        seq1 = input("1.조회하기 2.투표 3.즐겨찾기 4.순위보기 5.종료 \n")
        if seq1 == "1":
            while True:
                print("무엇을 조회하시겠습니까? \n")
                seq1_1 = input("1.전체 정치인 2.정치인 간편검색 3.지역별 정치인 4.정당별 정치인 5.정치인 상세검색 6.정치인 공약조회 7.뒤로가기 \n")
                if (seq1_1 == "1"):
                    App.electedList()  # 전체 출력
                elif (seq1_1 == "2"):
                    App.electedName()  # 간편 출력
                elif (seq1_1 == "3"):
                    App.electedRegion()  # 지역별 출력
                elif (seq1_1 == "4"):
                    App.electedParty()  # 정당별 출력
                elif (seq1_1 == "5"):
                    App.electedDetail()  # 상세정보 출력
                elif (seq1_1 == "6"):
                    App.electedPledge()  # 공약 출력
                elif (seq1_1 == "7"):
                    break

        elif (seq1 == "2"):
            while True:
                seq2 = input("1.투표 하기 2.나의투표 3.나의투표 삭제 4.뒤로가기 \n")
                if (seq2 == "1"):
                    if (userID == "없음"):
                        print("현재 접속되지 않아 투표를 할 수 없습니다.")
                        break
                    else:
                        App.voteToElected(userID)  # 투표하기
                elif (seq2 == "2"):
                    if (userID == "없음"):
                        print("현재 접속되지 않아 나의투표를 조회 할 수 없습니다.")
                        break
                    else:
                        App.refVote(userID)  # 나의 투표 출력
                elif (seq2 == "3"):
                    if (userID == "없음"):
                        print("현재 접속되지 않아 나의투표 삭제를 할 수 없습니다.")
                        break
                    else:
                        App.delVote(userID)  # 나의 투표 삭제
                elif (seq2 == "4"):
                    break

        elif (seq1 == "3"):
            while True:
                seq3 = input("1.즐겨찾기 하기 2.나의 즐겨찾기 3.나의 즐겨찾기 삭제 4.뒤로가기 \n")
                if (seq3 == "1"):
                    if(userID == "없음"):
                        print("현재 접속되지 않아 즐겨찾기를 할 수 없습니다.")
                        break
                    else:
                        App.markToElected(userID)  # 즐겨찾기 추가
                elif (seq3 == "2"):
                    if (userID == "없음"):
                        print("현재 접속되지 않아 즐겨찾기 조회를 할 수 없습니다.")
                        break
                    else:
                        App.refMark(userID)  # 나의 즐겨찾기 조회
                elif (seq3 == "3"):
                    if (userID == "없음"):
                        print("현재 접속되지 않아 즐겨찾기 삭제를 할 수 없습니다.")
                        break
                    else:
                        App.delMark(userID)  # 나의 즐겨찾기 삭제
                elif (seq3 == "4"):
                    break

        elif (seq1 == "4"):
            while True:
                print("어떤 통계를 보고 싶으십니까? \n")
                seq4 = input("1.정당 순위 2.지역별 순위 3.연령대별 순위 4.뒤로가기 \n")
                if (seq4 == "1"):
                    App.RankParty()  # 정당 순위
                elif (seq4 == "2"):
                    App.RankRegion()  # 지열별 순위
                elif (seq4 == "3"):
                    App.RankAge()  # 연령대별 순위
                elif (seq4 == "4"):
                    break
        elif (seq1 == "5"):
            break

#어플리케이션 시작
seq0 = input("1.사용자 생성 2.사용자 생성 건너뛰기 \n")
if seq0 == "1":
    # 사용자 생성
    userID = input("생성할 사용자 ID를 입력해주세요 (숫자만 허용) : ")
    userName = input("사용자 이름을 입력해주세요 : ")
    userAge = input("사용자 나이대를 입력해주세요 (10대, 20대, 30대, 40대, 50대, 60대, 70대이상) : ")
    userGender = input("사용자 성별을 입력해주세요 (남, 여): ")
    userRegion = input("사용자 지역을 입력해주세요 (서울특별시, OO광역시, OO도, OO남도, OO북도): ")
    MyAccount = App.InitUser(userID, userName, userAge, userGender, userRegion)
    MyAccount.insertUser()
    menu()

elif seq0 == "2":
    userID = "없음"
    menu()
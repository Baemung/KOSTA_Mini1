import psycopg2

### CONNECT DB
conn = psycopg2.connect(host='localhost',
                        dbname='groupproject',
                        user='postgres',
                        password='******',
                        port='5432')
conn.autocommit = True
cur = conn.cursor()

### DEFINE FUNCTION
class InitUser :
    def __init__(self, Id, Name, Age, Gender, Region):
        self.Id = Id
        self.Name = Name
        self.Age = Age
        self.Gender = Gender
        self.Region = Region
    def insertUser(self):
        cur.execute("insert into appUser (userId, name, age, gender, region) values (%s, %s, %s, %s, %s)", (self.Id, self.Name, self.Age, self.Gender, self.Region,))
        print("유저 생성이 완료되었습니다.")
         
def searchResult(): # 정치인 세부사항 출력
    result = cur.fetchall()
    for i in result:
        list(i)
        print("이름 : "+i[0]+'\n')
        if(i[1] != i[2]):
            print("현직 : "+i[1]+" "+i[2]+'\n')
        else:
            print("현직 : "+i[1]+'\n')
        print("정당 : "+i[3]+'\n')
        print("나이 : "+str(i[4]+2)+'\n')
        print("경력1 : "+i[5]+'\n')
        print("경력2 : "+i[6]+'\n')
        print("학력 : "+i[7])

def printResult():
    result = cur.fetchall()
    for i in result:
        list(i)
        if(i[1] != i[2]):
            print("이름 : "+i[0]+" | 지역 : "+i[1]+" "+i[2]+" | 정당 : "+i[3])
        else:
            print("이름 : "+i[0]+" | 지역 : "+i[1]+" | 정당 : "+i[3])

def electedList(): # 전체 정치인 출력
    cur.execute("select name, sdName, sggName, jdName from elected")
    printResult()

def electedName(): # 검색한 이름 정치인 출력
    ElectedName = input("이름을 입력해주세요 : ")
    cur.execute("select name, sdName, sggName, jdName from elected where name = '%s'" %ElectedName)
    printResult()

def electedRegion(): # 검색한 지역 정치인 출력
    ElectedRegion = input("지역을 입력해주세요 : ")
    cur.execute("select name, sdName, sggName, jdName from elected where sdName = '%s'" %ElectedRegion)
    printResult()

def electedParty(): # 검색한 정당 정치인 출력
    ElectedParty = input("정당을 입력해주세요 : ")
    cur.execute("select name, sdName, sggName, jdName from elected where jdName = '%s'" %ElectedParty)
    printResult()

def electedDetail(): # 정치인 세부사항 검색
    ElectedName = input("이름을 입력해주세요 : ")
    cur.execute("select name, Elected.sdName, Elected.sggName, jdName, age, career1, career2, edu from Elected where name = '%s'" %ElectedName)
    searchResult()

def electedPledge(): # 정치인 공약 출력
    ElectedName = input("공약을 검색한 정치인 이름을 입력해주세요 : ")
    cur.execute("select krName, sidoName, sggName, partyName, prmsTitle, prmmCont from Pledge where krName = '%s'" %ElectedName)
    result = cur.fetchall()
    for i in result:
        list(i)
        print("이름 : "+i[0]+'\n')
        if(i[1] != i[2]):
            print("현직 : "+i[1]+" "+i[2]+'\n')
        else:
            print("현직 : "+i[1]+'\n')
        print("정당 : "+i[3]+'\n')
        print("공약 제목 : "+i[4]+'\n')
        print("공약 내용 : "+i[5])

def RankResult(): # 정치인 순위결과 출력
    result = cur.fetchall()
    rank = 1
    for i in result:
        list(i)
        if(i[2] != i[3]):
            print("등수 : "+str(rank)+" | 이름 : "+i[0]+" | 정당 : "+i[1]+" | 지역 : "+i[2]+" "+i[3]+" | 득표수 : "+str(i[4]))
        else:
            print("등수 : "+str(rank)+" | 이름 : "+i[0]+" | 정당 : "+i[1]+" | 지역 : "+i[2]+" | 득표수 : "+str(i[4]))
        rank+=1

def RankAge(): # 사용자 나이대별 정치인 순위
    userAge = input("순위를 보고싶은 사용자 나이대를 입력해주세요 : ")
    cur.execute("select Elected.name, Elected.jdName, Elected.sdName, Elected.sggName, count(*) "
                "from Vote, appUser, Elected "
                "where Elected.huboId = Vote.huboId and appUser.userId = Vote.userId and appUser.age  = '%s' "
                "group by Elected.huboId, Elected.name, Elected.jdName, Elected.sdName, Elected.sggName "
                "order by count desc "
                "limit 5" %userAge)
    RankResult()

def RankRegion(): # 지역별 정치인 순위
    userRegion = input("순위를 보고싶은 지역을 입력해주세요 : ")
    cur.execute("select Elected.name, Elected.jdName, Elected.sdName, Elected.sggName, count(*) "
                "from Vote, Elected "
                "where Elected.huboId = Vote.huboId and sdName  = '%s' "
                "group by Vote.huboId, Elected.name, Elected.jdName, Elected.sdName, Elected.sggName "
                "order by count desc "
                "limit 5" %userRegion)
    RankResult()

def RankParty(): # 정당 순위결과 출력
    cur.execute("select Elected.jdName, count(*) "
                "from Vote, Elected "
                "where Elected.huboId = Vote.huboId "
                "group by Elected.jdName "
                "order by count desc "
                "limit 5;")
    rank = 1
    result = cur.fetchall()
    for i in result:
        list(i)
        print("등수 : "+str(rank)+" | 정당 : "+i[0]+" | 득표수 : "+str(i[1]))
        rank+=1
            
def voteToElected(userIdToVote):
    electedNameToVote = input("정치인 이름을 입력해 주세요\n")
    cur.execute("select huboid from elected where name = '%s'"%electedNameToVote)
    result = cur.fetchall()
    cur.execute("insert into Vote (userId, huboId) values (%s, %s)", (userIdToVote, result[0][0],))
    print("'%s' 에게 투표 하였습니다. \n"%electedNameToVote)

def markToElected(userIdToMark):
    electedNameToMark = input("정치인 이름을 입력해 주세요\n")
    cur.execute("select huboid from elected where name = '%s'"%electedNameToMark)
    result = cur.fetchall()
    cur.execute("insert into Mark (userId, huboId) values (%s, %s)", (userIdToMark, result[0][0],))
    print("'%s' 을(를) 즐겨찾기 하였습니다. \n"%electedNameToMark)

def refVote(userIdToVote):
    cur.execute("select name, sdName, sggName, jdName from Vote, Elected where Elected.huboId = Vote.huboId and userId = '%s'" % userIdToVote)
    printResult()

def refMark(userIdToMark):
    cur.execute("select name, sdName, sggName, jdName from Mark, Elected where Elected.huboId = Mark.huboId and userId = '%s'" % userIdToMark)
    printResult()

def delVote(userIdToVote):
    electedNameToVote = input("투표 삭제할 정치인 이름을 입력해 주세요\n")
    cur.execute("select huboid from elected where name = '%s'" % electedNameToVote)
    result = cur.fetchall()
    cur.execute("delete from Vote where userId = %s and huboId = %s", (userIdToVote,result[0][0],))
    print("'%s' 을(를) 투표 삭제 하였습니다. \n" % electedNameToVote)

def delMark(userIdToMark):
    electedNameToMark = input("즐겨찾기 삭제할 정치인 이름을 입력해 주세요\n")
    cur.execute("select huboid from elected where name = '%s'" % electedNameToMark)
    result = cur.fetchall()
    cur.execute("delete from Mark where userId = %s and huboId = %s", (userIdToMark,result[0][0],))
    print("'%s' 을(를) 즐겨찾기 삭제 하였습니다. \n" % electedNameToMark)
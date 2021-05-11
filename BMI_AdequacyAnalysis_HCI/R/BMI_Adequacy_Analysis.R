## ----------------------------------------------
#
# HWFinal. 국민체력실태조사 - BMI지수와 체력과의 상관관계분석 - 체지방량, 허리둘레와 비교분석
#
# COPYRIGHT (c) 2019 AJOU University
# Author	: Bae, Mungyu
# History : 2019/11/26
#
## ----------------------------------------------

#맥에서 R 한글깨짐 문제 - Locale 설정
#Sys.setlocale("LC_ALL","ko_KR.UTF-8")
#install.packages(c("dplyr","ggplot2","arules","gmodels","corrplot","wordcloud2","KoNLP","stringr","tm","qgraph"))
library(dplyr)
library(ggplot2)
library(tm)
library(arules)
library(gmodels)
library(corrplot)
library(wordcloud2)
library(rJava)
library(KoNLP)
library(stringr)
library(qgraph)

### 텍스트분석 ###
#형태소 분석 함수
ko.words <- function(doc) {
  d <- as.character(doc)
  ## 한글 형태소 식별하기    
  pos <- paste(SimplePos09(d))
  ## 형태소 중 명사(N), 용언(형용사, 동사: NP)만 추출하기    
  ex <- str_match(pos, '([가-힣]+)/[NP]')
  ## 동의어, 의미없는단어 처리
  keywords <- ex[,2]
  keywords <- gsub("아ㆍ태", "국내", keywords)
  keywords <- gsub("BMI", "체질량지수", keywords)
  keywords <- gsub("소녀", NA, keywords)
  keywords <- gsub("아니", NA, keywords)
  keywords <- gsub("교수", NA, keywords)
  keywords <- gsub("가지", NA, keywords)  
  keywords <- gsub("속하", NA, keywords)
  keywords <- gsub("따르", NA, keywords)
  keywords <- gsub("여부", NA, keywords)
  keywords <- gsub("때문", NA, keywords)
  keywords <- gsub("경우", NA, keywords)
  ## 결측값(NA) 정제하기    
  keywords<- keywords[!is.na(keywords)]
  paste(keywords, collapse = ' ')
}

#BMI와 관련된 기사불러오기
txt <- readLines("bmi.txt")
dics <- c('sejong','woorimalsam')
name <- c("체질량지수", "BMI", "체지방량", "허리둘레")
name.df <- data.frame(name, 'ncn') 
#buildDictionary(ext_dic = dics, user_dic=name.df, replace_usr_dic=T)
words <- lapply(txt, ko.words)
cps <- Corpus(VectorSource(words))
tdm <- TermDocumentMatrix(cps, control = list(removePunctuation=T, removeNumbers=T))
tdm.matrix <- as.matrix(tdm)

#단어의 빈도수 분석을 통해 키워드 찾기
words.count <- rowSums(tdm.matrix)
words.order <- order(words.count, decreasing = T)
freq.words <- tdm.matrix[words.order,] 
freq.words <- subset(freq.words, str_length(row.names(freq.words))>=2)
freq.words <- freq.words[1:30,]
keywords.df <- data.frame(rownames(freq.words), rowSums(freq.words))

#키워드를 워드클라우드로 시각화
wordcloud2(keywords.df)

#csv파일불러와서 데이터생성
mdis <- read.table("국민체력실태조사_성인(제공)_2017_20191112_39075.csv",
                   header=FALSE, sep=",", colClasses = c("character", "numeric", "character", "numeric", 
                                                         "numeric", "numeric", "numeric", "numeric", "numeric", 
                                                         "numeric", "numeric", "numeric", "numeric", "numeric", 
                                                         "numeric", "character"))
### 데이터 전처리 ###
mdis$V3<- recode_factor(mdis$V3, '1'="남자")
mdis$V3<- recode_factor(mdis$V3, '2'="여자")
colnames(mdis) = c("지역", "연령", "성별", "신장", "체중", "BMI", "체지방률", "허리둘레", "윗몸일으키기", 
                   "상대악력", "악력", "제자리멀리뛰기", "왕복오래달리기_20m", "좌전굴", "왕복빨리달리기_10m", "연령집단")

##필요한데이터만 추출(지역데이터 제외)
health <- subset(mdis, select=c(BMI, 체지방률, 성별, 연령, 체중, 신장, 허리둘레, 윗몸일으키기, 상대악력, 악력, 좌전굴, 제자리멀리뛰기, 왕복오래달리기_20m, 왕복빨리달리기_10m, 연령집단))
  
##성별별로 데이터분리
#남성데이터 추출
health_male <- health %>%
  filter(성별 == "남자")
#남성만 추출한 데이터에서 성별항목제거 - 모든 데이터를 numeric타입으로 만들기 위해
health_male <- subset(health_male, select = -성별)
#남성데이터에서 BMI, 체지방률, 허리둘레를 대한비만학회의 기준에따라 등급분류
male_eval <- health_male %>%
  mutate(분류_BMI = ifelse(BMI <18.5, 1,
                           ifelse(BMI < 23, 2,
                                  ifelse(BMI < 25, 3,
                                         ifelse(BMI < 30, 4,5)))),#대한비만학회 기준
              분류_체지방률 = ifelse(체지방률 <15, 1,
                                     ifelse(체지방률 < 20, 2,
                                                ifelse(체지방률 < 25, 3,4))),#대한비만학회 기준
              분류_허리둘레 = ifelse(허리둘레 >= 95,3,
                                   ifelse(허리둘레 >= 90,2,1)))#WHO 아시아태평양 지역기준 - 디테일한 등급위해 95이상(고도복부비만) 추가
#연령집단 19-24살,25-29살...60-64살까지 각 연령별로 적용되는 기준이 다른 연령집단을 9집단으로 나눈뒤 각 기준 적용
#1=상(상위 33%),2=중(상위 33%-66%), 3=하(하위 33%)
male_1 <- male_eval %>%
  filter(연령집단 == 1) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<43,3,
                            ifelse(윗몸일으키기<55,2,1)),
         등급_상대악력 = ifelse(상대악력<57.4,3,
                            ifelse(상대악력<65.8,2,1)),
         등급_악력 = ifelse(악력<40.6,3,
                            ifelse(악력<46.2,2,1)),
         등급_좌전굴 = ifelse(좌전굴<7.1,3,
                            ifelse(좌전굴<14.9,2,1)),
         등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<209.1,3,
                            ifelse(제자리멀리뛰기<234.1,2,1)),
         등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<43,3,
                            ifelse(왕복오래달리기_20m<61,2,1)),
         등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<10,1,
                            ifelse(왕복빨리달리기_10m<11,2,3)))
male_2 <- male_eval %>%
  filter(연령집단 == 2) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<41,3,
                                  ifelse(윗몸일으키기<52,2,1)),
                  등급_상대악력 = ifelse(상대악력<55.4,3,
                                       ifelse(상대악력<65.8,2,1)),
                  등급_악력 = ifelse(악력<41.2,3,
                                   ifelse(악력<47.7,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<6.0,3,
                                     ifelse(좌전굴<15.0,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<201.1,3,
                                             ifelse(제자리멀리뛰기<226.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<35,3,
                                                 ifelse(왕복오래달리기_20m<54,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<10.3,1,
                                                 ifelse(왕복빨리달리기_10m<11.3,2,3)))
male_3 <- male_eval %>%
  filter(연령집단 == 3) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<39,3,
                                  ifelse(윗몸일으키기<50,2,1)),
                  등급_상대악력 = ifelse(상대악력<56.0,3,
                                       ifelse(상대악력<65.2,2,1)),
                  등급_악력 = ifelse(악력<42.9,3,
                                   ifelse(악력<49.9,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<7.3,3,
                                     ifelse(좌전굴<14.9,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<199.1,3,
                                             ifelse(제자리멀리뛰기<225.5,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<34,3,
                                                 ifelse(왕복오래달리기_20m<51,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<10.4,1,
                                                 ifelse(왕복빨리달리기_10m<11.5,2,3)))

male_4 <- male_eval %>%
  filter(연령집단 == 4) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<35,3,
                                  ifelse(윗몸일으키기<47,2,1)),
                  등급_상대악력 = ifelse(상대악력<56.7,3,
                                       ifelse(상대악력<64.7,2,1)),
                  등급_악력 = ifelse(악력<42.0,3,
                                   ifelse(악력<47.8,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<4.6,3,
                                     ifelse(좌전굴<14.7,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<196.5,3,
                                             ifelse(제자리멀리뛰기<215.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<32,3,
                                                 ifelse(왕복오래달리기_20m<45,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<10.7,1,
                                                 ifelse(왕복빨리달리기_10m<11.8,2,3)))
male_5 <- male_eval %>%
  filter(연령집단 == 5) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<33,3,
                                  ifelse(윗몸일으키기<44,2,1)),
                  등급_상대악력 = ifelse(상대악력<54.4,3,
                                       ifelse(상대악력<63.6,2,1)),
                  등급_악력 = ifelse(악력<41.6,3,
                                   ifelse(악력<48.4,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<3.8,3,
                                     ifelse(좌전굴<14.0,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<191.1,3,
                                             ifelse(제자리멀리뛰기<212.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<30,3,
                                                 ifelse(왕복오래달리기_20m<42,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<11,1,
                                                 ifelse(왕복빨리달리기_10m<12,2,3)))
male_6 <- male_eval %>%
  filter(연령집단 == 6) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<32,3,
                                  ifelse(윗몸일으키기<42,2,1)),
                  등급_상대악력 = ifelse(상대악력<55.8,3,
                                       ifelse(상대악력<63.9,2,1)),
                  등급_악력 = ifelse(악력<41.5,3,
                                   ifelse(악력<46.9,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<5.1,3,
                                     ifelse(좌전굴<13.1,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<185.1,3,
                                             ifelse(제자리멀리뛰기<203.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<26,3,
                                                 ifelse(왕복오래달리기_20m<39,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<11.4,1,
                                                 ifelse(왕복빨리달리기_10m<12.4,2,3)))
male_7 <- male_eval %>%
  filter(연령집단 == 7) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<30,3,
                                  ifelse(윗몸일으키기<39,2,1)),
                  등급_상대악력 = ifelse(상대악력<55.2,3,
                                       ifelse(상대악력<64.1,2,1)),
                  등급_악력 = ifelse(악력<39.4,3,
                                   ifelse(악력<44.8,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<5.9,3,
                                     ifelse(좌전굴<13.4,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<177.1,3,
                                             ifelse(제자리멀리뛰기<195.5,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<26,3,
                                                 ifelse(왕복오래달리기_20m<36,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<11.6,1,
                                                 ifelse(왕복빨리달리기_10m<12.7,2,3)))
male_8 <- male_eval %>%
  filter(연령집단 == 8) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<28,3,
                                  ifelse(윗몸일으키기<37,2,1)),
                  등급_상대악력 = ifelse(상대악력<53.5,3,
                                       ifelse(상대악력<62.0,2,1)),
                  등급_악력 = ifelse(악력<38.0,3,
                                   ifelse(악력<43.0,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<7.1,3,
                                     ifelse(좌전굴<14.7,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<168.1,3,
                                             ifelse(제자리멀리뛰기<186.5,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<21,3,
                                                 ifelse(왕복오래달리기_20m<33,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<12.0,1,
                                                 ifelse(왕복빨리달리기_10m<13.2,2,3)))
male_9 <- male_eval %>%
  filter(연령집단 == 9) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<23,3,
                                  ifelse(윗몸일으키기<35,2,1)),
                  등급_상대악력 = ifelse(상대악력<53.1,3,
                                       ifelse(상대악력<60.3,2,1)),
                  등급_악력 = ifelse(악력<36.2,3,
                                   ifelse(악력<41.3,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<7.1,3,
                                     ifelse(좌전굴<13.1,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<161.1,3,
                                             ifelse(제자리멀리뛰기<182.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<17,3,
                                                 ifelse(왕복오래달리기_20m<28,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<12.6,1,
                                                 ifelse(왕복빨리달리기_10m<13.8,2,3)))
#각집단으로 나눠진 데이터를 하나의 데이터로 통합
male_eval <- rbind(male_1, male_2)
male_eval <- rbind(male_eval, male_3)
male_eval <- rbind(male_eval, male_4)
male_eval <- rbind(male_eval, male_5)
male_eval <- rbind(male_eval, male_6)
male_eval <- rbind(male_eval, male_7)
male_eval <- rbind(male_eval, male_8)
male_eval <- rbind(male_eval, male_9)
#등급과 평가만 남겨두고 나머지 numeric 기록데이터들은 제거
male_eval <- subset(male_eval,select = c(분류_BMI,분류_체지방률,분류_허리둘레,등급_윗몸일으키기,등급_좌전굴,등급_제자리멀리뛰기,등급_10m왕복빨리달리기,등급_20m왕복오래달리기))


##여성도 남성과 똑같이 데이터 처리
health_female <- health %>%
  filter(성별 == "여자")
health_female <- subset(health_female, select = -성별)
female_eval <- health_female %>%
  mutate(분류_BMI = ifelse(BMI <18.5, 1,
                           ifelse(BMI < 23, 2,
                                  ifelse(BMI < 25, 3,
                                         ifelse(BMI < 30, 4,5)))),#대한비만학회 기준
              분류_체지방률 = ifelse(체지방률 <18, 1,
                                     ifelse(체지방률 < 27, 2,
                                                ifelse(체지방률 < 33, 3,4))),#대한비만학회 기준
              분류_허리둘레 = ifelse(허리둘레 >= 90,3,
                                   ifelse(허리둘레 >= 85,2,1)))#대한비만학회 기준
female_1 <- female_eval %>%
  filter(연령집단 == 1) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<26,3,
                                  ifelse(윗몸일으키기<37,2,1)),
                  등급_상대악력 = ifelse(상대악력<42.2,3,
                                       ifelse(상대악력<50.8,2,1)),
                  등급_악력 = ifelse(악력<23.4,3,
                                   ifelse(악력<28.5,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<12.6,3,
                                     ifelse(좌전굴<20.6,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<139.7,3,
                                             ifelse(제자리멀리뛰기<165.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<19,3,
                                                 ifelse(왕복오래달리기_20m<30,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<12.2,1,
                                                 ifelse(왕복빨리달리기_10m<13.7,2,3)))
female_2 <- female_eval %>%
  filter(연령집단 == 2) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<24,3,
                                  ifelse(윗몸일으키기<36,2,1)),
                  등급_상대악력 = ifelse(상대악력<41.4,3,
                                       ifelse(상대악력<51.1,2,1)),
                  등급_악력 = ifelse(악력<23.6,3,
                                   ifelse(악력<27.8,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<11.5,3,
                                     ifelse(좌전굴<21.9,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<140.1,3,
                                             ifelse(제자리멀리뛰기<161.7,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<18,3,
                                                 ifelse(왕복오래달리기_20m<29,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<12.3,1,
                                                 ifelse(왕복빨리달리기_10m<13.8,2,3)))
female_3 <- female_eval %>%
  filter(연령집단 == 3) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<24,3,
                                  ifelse(윗몸일으키기<34,2,1)),
                  등급_상대악력 = ifelse(상대악력<42.0,3,
                                       ifelse(상대악력<49.0,2,1)),
                  등급_악력 = ifelse(악력<24.2,3,
                                   ifelse(악력<28.4,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<13.1,3,
                                     ifelse(좌전굴<19.9,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<139.1,3,
                                             ifelse(제자리멀리뛰기<158.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<18,3,
                                                 ifelse(왕복오래달리기_20m<25,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<12.8,1,
                                                 ifelse(왕복빨리달리기_10m<14.0,2,3)))
female_4 <- female_eval %>%
  filter(연령집단 == 4) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<18,3,
                                  ifelse(윗몸일으키기<30,2,1)),
                  등급_상대악력 = ifelse(상대악력<41.6,3,
                                       ifelse(상대악력<49.4,2,1)),
                  등급_악력 = ifelse(악력<23.7,3,
                                   ifelse(악력<28.0,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<10.0,3,
                                     ifelse(좌전굴<17.9,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<134.1,3,
                                             ifelse(제자리멀리뛰기<155.3,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<16,3,
                                                 ifelse(왕복오래달리기_20m<24,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<13.2,1,
                                                 ifelse(왕복빨리달리기_10m<14.9,2,3)))
female_5 <- female_eval %>%
  filter(연령집단 == 5) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<21,3,
                                  ifelse(윗몸일으키기<31,2,1)),
                  등급_상대악력 = ifelse(상대악력<41.0,3,
                                       ifelse(상대악력<50.2,2,1)),
                  등급_악력 = ifelse(악력<24.4,3,
                                   ifelse(악력<28.5,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<11.1,3,
                                     ifelse(좌전굴<17.8,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<135.1,3,
                                             ifelse(제자리멀리뛰기<155.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<16,3,
                                                 ifelse(왕복오래달리기_20m<23,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<13.0,1,
                                                 ifelse(왕복빨리달리기_10m<14.0,2,3)))
female_6 <- female_eval %>%
  filter(연령집단 == 6) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<20,3,
                                  ifelse(윗몸일으키기<30,2,1)),
                  등급_상대악력 = ifelse(상대악력<41.3,3,
                                       ifelse(상대악력<48.7,2,1)),
                  등급_악력 = ifelse(악력<23.8,3,
                                   ifelse(악력<28.0,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<10.4,3,
                                     ifelse(좌전굴<19.4,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<130.1,3,
                                             ifelse(제자리멀리뛰기<150.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<14,3,
                                                 ifelse(왕복오래달리기_20m<21,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<13.5,1,
                                                 ifelse(왕복빨리달리기_10m<14.4,2,3)))
female_7 <- female_eval %>%
  filter(연령집단 == 7) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<16,3,
                                  ifelse(윗몸일으키기<26,2,1)),
                  등급_상대악력 = ifelse(상대악력<39.5,3,
                                       ifelse(상대악력<47.3,2,1)),
                  등급_악력 = ifelse(악력<23.2,3,
                                   ifelse(악력<26.6,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<13.0,3,
                                     ifelse(좌전굴<19.4,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<122.1,3,
                                             ifelse(제자리멀리뛰기<142.5,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<13,3,
                                                 ifelse(왕복오래달리기_20m<20,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<13.7,1,
                                                 ifelse(왕복빨리달리기_10m<14.9,2,3)))
female_8 <- female_eval %>%
  filter(연령집단 == 8) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<12,3,
                                  ifelse(윗몸일으키기<21,2,1)),
                  등급_상대악력 = ifelse(상대악력<37.9,3,
                                       ifelse(상대악력<46.0,2,1)),
                  등급_악력 = ifelse(악력<21.7,3,
                                   ifelse(악력<25.9,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<13.4,3,
                                     ifelse(좌전굴<19.9,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<113.1,3,
                                             ifelse(제자리멀리뛰기<133.5,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<12,3,
                                                 ifelse(왕복오래달리기_20m<17,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<14.1,1,
                                                 ifelse(왕복빨리달리기_10m<15.4,2,3)))
female_9 <- female_eval %>%
  filter(연령집단 == 9) %>%
  mutate(등급_윗몸일으키기 = ifelse(윗몸일으키기<8,3,
                                  ifelse(윗몸일으키기<17,2,1)),
                  등급_상대악력 = ifelse(상대악력<38.4,3,
                                       ifelse(상대악력<45.2,2,1)),
                  등급_악력 = ifelse(악력<22.3,3,
                                   ifelse(악력<25.7,2,1)),
                  등급_좌전굴 = ifelse(좌전굴<13.6,3,
                                     ifelse(좌전굴<20.4,2,1)),
                  등급_제자리멀리뛰기 = ifelse(제자리멀리뛰기<101.1,3,
                                             ifelse(제자리멀리뛰기<126.1,2,1)),
                  등급_20m왕복오래달리기 = ifelse(왕복오래달리기_20m<10,3,
                                                 ifelse(왕복오래달리기_20m<15,2,1)),
                  등급_10m왕복빨리달리기 = ifelse(왕복빨리달리기_10m<15.0,1,
                                                 ifelse(왕복빨리달리기_10m<16.2,2,3)))

female_eval <- rbind(female_1, female_2)
female_eval <- rbind(female_eval, female_3)
female_eval <- rbind(female_eval, female_4)
female_eval <- rbind(female_eval, female_5)
female_eval <- rbind(female_eval, female_6)
female_eval <- rbind(female_eval, female_7)
female_eval <- rbind(female_eval, female_8)
female_eval <- rbind(female_eval, female_9)
female_eval <- subset(female_eval,select = c(분류_BMI,분류_체지방률,분류_허리둘레,등급_윗몸일으키기,등급_좌전굴,등급_제자리멀리뛰기,등급_10m왕복빨리달리기,등급_20m왕복오래달리기))


#소수점데이터 소수점한자리까지 반올림
health$BMI <- round(health$BMI, digits = 0)
health$체지방률 <- round(health$체지방률, digits = 0)
health$체중 <- round(health$체중, digits = 0)
health$신장 <- round(health$신장, digits = 0)
health$허리둘레 <- round(health$허리둘레, digits = 0)
health$상대악력 <- round(health$상대악력, digits = 0)
health$악력 <- round(health$악력, digits = 0)
health$좌전굴 <- round(health$좌전굴, digits = 0)
health$제자리멀리뛰기 <- round(health$제자리멀리뛰기, digits = 0)
health$왕복빨리달리기_10m <- round(health$왕복빨리달리기_10m, digits = 0)

#수치가 반올림된 남성데이터 재추출
health_male <- health %>%
  filter(성별 == "남자")
#남성만 추출한 데이터에서 성별항목제거 - 모든 데이터를 numeric타입으로 만들기 위해
health_male <- subset(health_male, select = -c(성별, 연령집단))

#수치가 반올린된 여성데이터 재추출
health_female <- health %>%
  filter(성별 == "여자")
#남성만 추출한 데이터에서 성별항목제거 - 모든 데이터를 numeric타입으로 만들기 위해
health_female <- subset(health_female, select = -c(성별, 연령집단))

#분석할 데이터파악, 결측치가 없음은 데이터추출전 미리 파악완료
summary(health$BMI)
summary(health$체지방률)
summary(health$상대악력) 
summary(health$악력) 
summary(health$좌전굴) #좌전굴이란, 다리를 쭉뻗고 앉아서 앞으로 팔을 내미는 유연성테스트임
summary(health$왕복빨리달리기_10m) #왕복달리기를 수행한 초(second)
summary(health$왕복오래달리기_20m) #왕복오래달리기를 수행한 횟수(count)




##### geom_boxplot() - 박스플롯으로 데이터(성별)분석 #####
##성별별 BMI, 체지방률,허리둘레 상관관계그래프 생성
ggplot(data = health, aes(x = 성별, y = BMI)) +
  geom_boxplot() # 여자의 중앙값은 22.5정도, 남자는 25정도로 남성이 전체적으로 BMI가 높은 경향이있다.
ggplot(data = health, aes(x = 성별, y = 체지방률)) +
  geom_boxplot() # 여자의 중앙값은 31정도, 남자는 22정도로 여성이 전체적으로 체지방률이 높은 경향이있다.
ggplot(data = health, aes(x = 성별, y = 허리둘레)) +
  geom_boxplot() # 여자의 중앙값은 78정도, 남자는 82정도로 남성이 전체적으로 허리둘레가 두꺼운 경향이있다.
## 체지방률과 BMI,허리둘레는 상관관계가 있지만, 남성이 여성과 비교해 체지방률은 명확히 낮고 BMI,허리둘레는 크다.
## 그렇기 때문에 데이터를 분석할때 남성과 여성을 반드시 구분해주어야한다.




##### geom_line() - 선그래프로 데이터(연령)분석 #####
##geom_line()그래프에 적합하게 연령별 평균체지방률, 평균BMI, 평균허리둘레데이터 생성
연령별평균BMI <- health %>%
  group_by(연령, 성별) %>%
  summarise(평균BMI = mean(BMI))
연령별평균체지방률 <- health %>%
  group_by(연령, 성별) %>%
  summarise(평균체지방률 = mean(체지방률))
연령별평균허리둘레 <- health %>%
  group_by(연령, 성별) %>%
  summarise(평균허리둘레 = mean(허리둘레))

##연령별 평균체지방률,평균BMI,평균허리둘레 그래프생성
ggplot(data = 연령별평균BMI , aes(x = 연령, y = 평균BMI, col = 성별)) +
  geom_line() # 등락이 있지만 여성은 대체적으로 나이가 들어감에따라 평균BMI가 상승하는 경향을보인다. 
# 남성은 30대 초반에 평균 BMI가 최대치를 찍고 그후 미세하게 감소하는 경향을 보인다.
ggplot(data = 연령별평균체지방률, aes(x = 연령, y = 평균체지방률, col = 성별)) +
  geom_line() # 등락이 있지만 남성과 여성 모두 대체적으로 나이가 들어감에따라 평균체지방률이 상승하는 경향을보인다. 
ggplot(data = 연령별평균허리둘레, aes(x = 연령, y = 평균허리둘레, col = 성별)) +
  geom_line() # 등락이 있지만 BMI와 유사하게 여성은 대체적으로 나이가 들어감에따라 평균허리둘레가 상승하는 경향을보인다. 
# 남성은 30대 초반에 평균 허리둘레가 최대치를 찍고 그후 미세하게 감소하는 경향을 보인다.




##### geom_point() - 산점도로 데이터분석 #####
##BMI와 체지방률,허리둘레의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 체지방률, col = 성별)) +
  geom_point() # 각 성별별로 BMI와 체지방률은 강한 양의 상관관계를 보인다.
ggplot(data = health, aes(x = BMI, y = 허리둘레, col = 성별)) +
  geom_point() # 각 성별별로 BMI와 허리둘레도 강한 양의 상관관계를 보인다.
ggplot(data = health, aes(x = 허리둘레, y = 체지방률, col = 성별)) +
  geom_point() # 각 성별별로 허리둘레와 체지방률은 강한 양의 상관관계를 보인다.
## BMI,체지방률, 허리둘레 셋다 서로 강한 양의 상관관계를 보인다.


##BMI와 체지방률,허리둘레 - 체중의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 체중, col = 성별)) +
  geom_point()# BMI와 체중은 강한 양의 상관관계를 보인다.
ggplot(data = health, aes(x = 체지방률, y = 체중, col = 성별)) +
  geom_point()# 체지방률과 체중은 약한 양의 상관관계를 보인다.
ggplot(data = health, aes(x = 허리둘레, y = 체중, col = 성별)) +
  geom_point()# 허리둘레와 체중은 강한 양의 상관관계를 보인다.
## 체중은 체지방률보다 BMI, 허리둘레와 더 강한 양의 상관관계를보인다.
## 체중을 신장의 제곱으로 나눠서 구한 BMI이기 때문에 당연한 결과라고할수있다.
## 체중과 더욱관련있는것은 체지방보다 허리둘레 라는 것이 의미있다.


##BMI와 체지방률,허리둘레 - 신장의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 신장, col = 성별)) +
  geom_point() # BMI와 신장은 상관관계가 없다
ggplot(data = health, aes(x = 체지방률, y = 신장, col = 성별)) +
  geom_point() # 체지방률과 신장은 상관관계가 없다
ggplot(data = health, aes(x = 허리둘레, y = 신장, col = 성별)) +
  geom_point() # 허리둘레와 신장은 상관관계가 없다
## 체중에 신장의 제곱을 나눠서 BMI를 구한 BMI와 체지방률, 허리둘레 모두 신장과 상관관계가 없음을 보인다.


##BMI와 체지방률,허리둘레 - 윗몸일으키기의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 윗몸일으키기, col = 성별)) +
  geom_point() # BMI와 윗몸일으키기는 상관관계가 거의 없다.
ggplot(data = health, aes(x = 체지방률, y = 윗몸일으키기, col = 성별)) +
  geom_point() # 체지방률이 증가할수록 윗몸일으키기하는 수가 적어지는 약한 음의 상관관계를 보인다.
ggplot(data = health, aes(x = 허리둘레, y = 윗몸일으키기, col = 성별)) +
  geom_point() # 허리둘레와 윗몸일으키기는 상관관계가 거의 없다.
## BMI, 허리둘레보다 체지방률이 윗몸일으키기에 더 큰 상관관계를 보인다.
## 허리둘레와 윗몸일으키기가 상관관계가 거의 없다는것이 의미있다.
## 여자보다 남자가 대체적으로 윗몸일으키기를 더 많이함을 보인다.


##BMI와 체지방률,허리둘레 - 악력의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 상대악력, col = 성별)) +
  geom_point() 
ggplot(data = health, aes(x = BMI, y = 악력, col = 성별)) +
  geom_point() # BMI와 악력은 상관관계가 없다
ggplot(data = health, aes(x = 체지방률, y = 상대악력, col = 성별)) +
  geom_point() 
ggplot(data = health, aes(x = 체지방률, y = 악력, col = 성별)) +
  geom_point() # 체지방률과 악력은 상관관계가 없다.
ggplot(data = health, aes(x = 허리둘레, y = 상대악력, col = 성별)) +
  geom_point() 
ggplot(data = health, aes(x = 허리둘레, y = 악력, col = 성별)) +
  geom_point() # 허리둘레와 악력은 상관관계가 없다
## BMI와 체지방률,허리둘레 모두 악력과 상관관계가 없음을 보인다.
## 남자가 여자보다 명확하게 악력이 강함을 보인다.


##BMI와 체지방률,허리둘레 - 좌전굴의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 좌전굴, col = 성별)) +
  geom_point() # BMI와 좌전굴은 상관관계가 없다.
ggplot(data = health, aes(x = 체지방률, y = 좌전굴, col = 성별)) +
  geom_point() # 체지방률과 좌전굴은 약한 음의 상관관계를 보인다.
ggplot(data = health, aes(x = 허리둘레, y = 좌전굴, col = 성별)) +
  geom_point() # 허리둘레와 좌전굴은 상관관계가 거의 없다.
## 유연성을 측정하는 좌전굴은 성별, BMI와 상관관계가 없고, 체지방률과 약한 상관관계를 보인다.
## 앉아서 앞으로 숙이는 좌전굴 특성상 허리둘레가 상관이 있을것같았지만, 상관관계가 거의 없었다.


##BMI와 체지방률,허리둘레 - 제자리멀리뛰기의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 제자리멀리뛰기, col = 성별)) +
  geom_point() # BMI와 제자리멀리뛰기는 상관관계가 거의 없다.
ggplot(data = health, aes(x = 체지방률, y = 제자리멀리뛰기, col = 성별)) +
  geom_point() # 체지방룰은 제자리멀리뛰기와 약한 음의 상관관계를 보인다.
ggplot(data = health, aes(x = 허리둘레, y = 제자리멀리뛰기, col = 성별)) +
  geom_point() # 허리둘레와 제자리멀리뛰기는 상관관계가 거의 없다.
## BMI,허리둘레보다 체지방률이 제자리멀리뛰기에 더 큰 상관관계를 보인다.


##BMI와 체지방률,허리둘레 - 20m왕복오래달리기의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 왕복오래달리기_20m, col = 성별)) +
  geom_point() # BMI와 20m왕복오래달리기는 상관관계가 거의 없다.
ggplot(data = health, aes(x = 체지방률, y = 왕복오래달리기_20m, col = 성별)) +
  geom_point() # 체지방률과 20m왕복오래달리기는 아주 약한 음의 상관관계를 보인다.
ggplot(data = health, aes(x = 허리둘레, y = 왕복오래달리기_20m, col = 성별)) +
  geom_point() # 허리둘레와 20m왕복오래달리기는 상관관계가 거의 없다.
## BMI, 허리둘레보다 체지방률이 20m왕복오래달리기에 그나마 더 큰 상관관계를 보인다.
## 대체적으로 남성이 여성보다 더 오래달리는 경향을 보인다.


##BMI와 체지방률,허리둘레 - 10m왕복빨리달리기의 상관관계그래프 생성
ggplot(data = health, aes(x = BMI, y = 왕복빨리달리기_10m, col = 성별)) +
  geom_point() # BMI와 10m왕복빨리달리기는 상관관계가 거의 없다.
ggplot(data = health, aes(x = 체지방률, y = 왕복빨리달리기_10m, col = 성별)) +
  geom_point() # 체지방률과 10m왕복빨리달리기는 아주약한 양의 상관관계를 보인다.
ggplot(data = health, aes(x = 허리둘레, y = 왕복빨리달리기_10m, col = 성별)) +
  geom_point() # 허리둘레와 10m왕복빨리달리기는 양의 상관관계를 보인다.
## 허리둘레, 체지방률, BMI순으로 10m왕복빨리달리기와 상관관계를 보인다.



###### 가설 : BMI가 다른수치들보다 체력수준을 파악하는데 용이하지않다. #####
###### 흔히 본인 신체에대한 평가로 BMI를 가장 흔하게 사용하는데,  BMI가 다른 수치들보다 신체의 체력과 상관관계가 밀접한지 알기위해 가설을 세움.
###### 검정방법 : BMI를 체지방률, 허리둘레와 비교하여 체력과의 상관관계를 교차분석과 상관분석 두분석모두 사용하여 검정 #####



##### 교차분석실시 #####
##BMI와 체지방률,허리둘레는 좌전굴과 수치적으로 유의미한 관계를 갖는지 확인
#남성
chisq.test(health_male$BMI,health_male$좌전굴) #귀무가설 : 남성의 BMI와 좌전굴은 서로 관계없다. 
#p = 0.99로 유의수준 0.05보다 크므로 귀무가설승인, 남성의 BMI과 좌전굴을 서로 관계가 없다.
chisq.test(health_male$체지방률,health_male$좌전굴) #귀무가설 : 남성의 체지방률과 좌전굴은 서로 관계없다. 
#p = 7.8e-09로 유의수준 0.05보다 작으므로 귀무가설기각, 남성의 BMI와 좌전굴은 서로 유의미한 관계를 갖는다.
chisq.test(health_male$허리둘레,health_male$좌전굴) #귀무가설 : 남성의 BMI와 좌전굴은 서로 관계없다. 
#p < 2.2e-16로 유의수준 0.05보다 작으므로 귀무가설기각, 남성의 허리둘레와 좌전굴은 서로 유의미한 관계를 갖는다.
#여성
chisq.test(health_female$BMI,health_female$좌전굴) #귀무가설 : 여성의 BMI와 좌전굴은 서로 관계없다. 
#p = 0.14로 유의수준 0.05보다 크므로 귀무가설승인, 여성의 BMI과 좌전굴을 서로 관계가 없다.
chisq.test(health_female$체지방률,health_female$좌전굴) #귀무가설 : 여성의 체지방률과 좌전굴은 서로 관계없다. 
#p = 4.6e-06로 유의수준 0.05보다 작으므로 귀무가설기각, 여성의 BMI와 좌전굴은 서로 유의미한 관계를 갖는다.
chisq.test(health_female$허리둘레,health_female$좌전굴) #귀무가설 : 여성의 체지방률과 좌전굴은 서로 관계없다. 
#p < 2.2e-16로 유의수준 0.05보다 작으므로 귀무가설기각, 여성의 허리둘레와 좌전굴은 서로 유의미한 관계를 갖는다.

#그래프에서 분석한것처럼 남녀 구분없이 BMI은 좌전굴과 서로 관계가 없다고나오고, 
#체지방률은 좌전굴과 서로 유의미한 관계가있다고 나왔다.
#하지만 허리둘레는 그래프에선 상관관계가 거의없는것처럼 보였지만, 수치적으로는 서로 유의미한 관계가있다고 나왔다.
#다만, Warning message: Chi-squared approximation may be incorrect메시지가 떠서 정확하지않을수있다.


##BMI와 체지방률, 허리둘레는 10m왕복빨리달리기와 수치적으로 유의미한 관계를 갖는지 확인
#남성
chisq.test(health_male$BMI,health_male$왕복빨리달리기_10m) #귀무가설 : BMI와 10m왕복빨리달리기는 서로 관계없다. 
#p = 1.2e-09으로 유의수준 0.05보다 작으므로 귀무가설기각,남성의 BMI와 10m왕복빨리달리기는 서로 유의미한 관계를 갖는다.
chisq.test(health_male$체지방률,health_male$왕복빨리달리기_10m) #귀무가설 : 체지방률과 10m왕복빨리달리기는 서로 관계없다. 
#p < 2.2e-16으로 유의수준 0.05보다 작으므로 귀무가설기각,남성의 체지방률과 10m왕복빨리달리기는 서로 유의미한 관계를 갖는다.
chisq.test(health_male$허리둘레,health_male$왕복빨리달리기_10m) #귀무가설 : 체지방률과 10m왕복빨리달리기는 서로 관계없다. 
#p < 2.2e-16으로 유의수준 0.05보다 작으므로 귀무가설기각,남성의 허리둘레와 10m왕복빨리달리기는 서로 유의미한 관계를 갖는다.
#여성
chisq.test(health_female$BMI,health_female$왕복빨리달리기_10m) #귀무가설 : BMI와 10m왕복빨리달리기는 서로 관계없다. 
#p = 1.6e-05으로 유의수준 0.05보다 작으므로 귀무가설기각,여성의 BMI와 10m왕복빨리달리기는 서로 유의미한 관계를 갖는다.
chisq.test(health_female$체지방률,health_female$왕복빨리달리기_10m) #귀무가설 : 체지방률과 10m왕복빨리달리기는 서로 관계없다. 
#p < 2.2e-16으로 유의수준 0.05보다 작으므로 귀무가설기각,여성의 체지방률과 10m왕복빨리달리기는 서로 유의미한 관계를 갖는다.
chisq.test(health_female$체지방률,health_female$왕복빨리달리기_10m) #귀무가설 : 체지방률과 10m왕복빨리달리기는 서로 관계없다. 
#p < 2.2e-16으로 유의수준 0.05보다 작으므로 귀무가설기각,여성의 허리둘레와 10m왕복빨리달리기는 서로 유의미한 관계를 갖는다.

#그래프에서 분석한것과 다르게 BMI와 체지방률 모두 10m왕복빨리달리기와 서로 유의미한 관계를 갖는다고 나왔다.
#그래프에서도 10m빨리달리기와 상관관계가 보였던 허리둘레도 역시 서로 유의미한 관계를 갖는다고 나왔다.
#다만, Warning message: Chi-squared approximation may be incorrect메시지가 떠서 정확하지않을수있다.


##BMI와 체지방률, 허리둘레는 20m왕복오래달리기와 수치적으로 유의미한 관계를 갖는지 확인
#남성
chisq.test(health_male$BMI,health_male$왕복오래달리기_20m) #귀무가설 : BMI와 20m왕복오래달리기는 서로 관계없다. 
#p = 0.79로 유의수준 0.05보다 크므로 귀무가설승인, 남성의 BMI와 10m왕복빨리달리기는 서로 관계가 없다고 볼수있다.
chisq.test(health_male$체지방률,health_male$왕복오래달리기_20m) #귀무가설 : 체지방률과 20m왕복오래달리기는 서로 관계없다. 
#p < 2.2e-16으로 유의수준 0.05보다 낮으므로 귀무가설기각, 남성의 체지방률과 20m왕복오래달리기는 서로 유의미한 관계를 갖는다.
chisq.test(health_male$허리둘레,health_male$왕복오래달리기_20m) #귀무가설 : 체지방률과 20m왕복오래달리기는 서로 관계없다. 
#p = 0.0006으로 유의수준 0.05보다 낮으므로 귀무가설기각, 남성의 허리둘레와 20m왕복오래달리기는 서로 유의미한 관계를 갖는다.
#여성
chisq.test(health_female$BMI,health_female$왕복오래달리기_20m) #귀무가설 : BMI와 20m왕복오래달리기는 서로 관계없다. 
#p = 0.99로 유의수준 0.05보다 크므로 귀무가설승인, 여성의 BMI와 10m왕복빨리달리기는 서로 관계가 없다고 볼수있다.
chisq.test(health_female$체지방률,health_female$왕복오래달리기_20m) #귀무가설 : 체지방률과 20m왕복오래달리기는 서로 관계없다. 
#p < 2.2e-16으로 유의수준 0.05보다 낮으므로 귀무가설기각, 여성의 체지방률과 20m왕복오래달리기는 서로 유의미한 관계를 갖는다.
chisq.test(health_female$허리둘레,health_female$왕복오래달리기_20m) #귀무가설 : 체지방률과 20m왕복오래달리기는 서로 관계없다. 
#p = 1으로 유의수준 0.05보다 크므로 귀무가설승인, 여성의 허리둘레와 10m왕복빨리달리기는 서로 관계가 없다고 볼수있다.

#그래프에서 분석한것처럼 BMI,허리둘레보다 체지방률이 20m왕복오래달리기와 서로 유의미한 관계를 갖는다.
#다만, Warning message: Chi-squared approximation may be incorrect메시지가 떠서 정확하지않을수있다.



##### 상관분석실시 #####
#남성
cor(health_male)
corrplot(cor(health_male), method="pie", type="lower")
#여성
cor(health_female)
corrplot(cor(health_female), method="pie", type="lower")
##성별 관계없이 BMI는 체지방률보다 허리둘레에 더 밀접한 상관관계를 가지고 있다.
##남자는 체지방률이 BMI보다 허리둘레와 미세하게나마 더 밀접한 상관관계를 가지고 있다.
##반면에 여자는 체지방률이 허리둘레보다 BMI와 미세하게나마 더 밀접한 상관관계를 가지고 있다.
##성별 관계없이 체지방률, 허리둘레, BMI순으로 악력을 제외한 체력과 더 밀접한 상관관계를 가지고 있다.



##### 연관분석실시 #####
###연관분석위해 factor형 변환
###남성데이터 변환
male_eval$분류_BMI <- factor(male_eval$분류_BMI, levels=c(1:5), labels=c('낮음', '정상', '경도비만', '비만', '고도비만'))
male_eval$분류_체지방률 <- factor(male_eval$분류_체지방률, levels=c(1:4), labels=c('낮음',	'정상', '경도비만',	'비만'))
male_eval$분류_허리둘레 <- factor(male_eval$분류_허리둘레, levels=c(1:3), labels=c('정상', '복부비만', '고도복부비만'))
male_eval$등급_윗몸일으키기 <- factor(male_eval$등급_윗몸일으키기, levels=c(1:3), labels=c('상', '중', '하'))
male_eval$등급_좌전굴 <- factor(male_eval$등급_좌전굴, levels=c(1:3), labels=c('상', '중', '하'))
male_eval$등급_제자리멀리뛰기 <- factor(male_eval$등급_제자리멀리뛰기, levels=c(1:3), labels=c('상', '중', '하'))
male_eval$등급_10m왕복빨리달리기 <- factor(male_eval$등급_10m왕복빨리달리기, levels=c(1:3), labels=c('상', '중', '하'))
male_eval$등급_20m왕복오래달리기 <- factor(male_eval$등급_20m왕복오래달리기, levels=c(1:3), labels=c('상', '중', '하'))
#male_eval$등급_상대악력 <- factor(male_eval$등급_상대악력, levels=c(1:3), labels=c('상', '중', '하'))
#male_eval$등급_악력 <- factor(male_eval$등급_악력, levels=c(1:3), labels=c('상', '중', '하'))

## 조건 (support=0.04, confidence=0.01, minlen=1, maxlen=2)으로 연관분석 시작
#arules 및 tm 라이브러리에 inspect () 메소드가 있음
#로드 순서에 따라이 메소드가 구현되는 방식에 영향을 미치는 오류가있어서 tm을 detach하고 다시 arules라이브러리를 로드.
detach(package:tm, unload=TRUE)
library(arules)
rule_male <- apriori(male_eval, parameter=list(support=0.04, confidence=0.3, minlen=1, maxlen=2))
## 규칙 요약 보기
summary(rule_male)
## 규칙 상세 보기
rule_male.df <- as(rule_male, "data.frame")
#남성 - BMI에 따른 운동능력의 등급 연관분석
rule_male.BMI<- inspect(subset(rule_male, subset=lhs %pin% "분류_BMI" & rhs %pin% "등급"))
#남성 - 체지방률에 따른 운동능력의 등급 연관분석
rule_male.FAT<- inspect(subset(rule_male, subset=lhs %pin% "분류_체지방률=" & rhs %pin% "등급"))
#남성 - 허리둘레에 따른 운동능력의 등급 연관분석
rule_male.WRIST<- inspect(subset(rule_male, subset=lhs %pin% "분류_허리둘레=" & rhs %pin% "등급"))
#남성 - 분류가 비만일때 따른 운동능력 '하'등급 연관분석
rule_male.LOW<- inspect(subset(rule_male, subset=lhs %pin% "비만" & rhs %pin% "하"))
##기준을 충족한 규칙들중 연관성을 표현할수있는 lift를 기준으로 평가해보면(lift > 1만 다룸),
##BMI가 정상으로 분류된 집단은 9가지 룰을 가지고있는데, 그 중 "하" 2개, "중" 2개, "상" 5개였다.
##  경도비만으로 분류된 집단은 9가지 룰을 가지고있는데, 그 중 "중" 4개, "상" 5개 "하"등급은 1개도 없다.
##  비만으로 분류된 집단은 8가지 룰을 가지고있는데, 그 중 "하" 5개, "중" 3개로 "상"등급은 1개도 없다.
##  비만등급은 "상"등급이 1개도 없는 걸로보아 연관성이 있어보이기는 하나, 
##  경도비만으로 분류된 집단이 정상보다도 더 좋은성적을 거두었다.
##  BMI는 제지방량과 지방량을 구분하지 못해서 근육량이 많은 사람들이 경도비만으로 분류되었을 가능성이 있어서 이런경향이 나타나는것 같다.
##체지방률이 낮음으로 분류된 집단은 5가지 룰을 가지고있는데, 모두 "상"이었다.
##  정상으로 분류된 집단은 8가지 룰을 가지고있는데, 그 중 "중" 3개, 상" 5개로, "하"등급은 1개도 없다.
##  경도비만으로 분류된 집단은 6가지룰을 가지고있는데, 그 중 "중" 5개, "상" 1개 "하"등급은 1개도 없다.
##  비만으로 분류된 집단은 6가지 룰을 가지고있는데, 그 중 "하" 5개, "중" 1개로 "상"등급은 1개도 없다.
##  낮음에서 비만으로 체지방률이 증가함에따라 "상"등급은 줄어들고, "하"등급이 늘어나는 패턴이 보인다.
##  정상과 경도비만의 경계가 BMI는 모호한데에 비해 체지방률은 정확하다고 볼수있다.
##허리둘레가 정상으로 분류된 집단은 9가지 룰을 가지고있는데, 그 중 "중" 4개, "상" 5개으로, "하"등급은 1개도 없다.
##  복부비만으로 분류된 집단은 7가지룰을 가지고있는데, 그 중 "하" 5개, "중" 2개로, "상"등급은 1개도 없다.
##  고도복부비만으로 분류된 집단은 5가지 룰을 가지고있는데, 모두 "하" 등급이다.
##체지방률과 허리둘레는 신체능력등급에서 서로 비슷한 수준의 경향을보이며 BMI보다 더 신체능력과 밀접한 연관성이 있다고 보인다.



###여성데이터 변환
female_eval$분류_BMI <- factor(female_eval$분류_BMI, levels=c(1:5), labels=c('낮음', '정상', '경도비만', '비만', '고도비만'))
female_eval$분류_체지방률 <- factor(female_eval$분류_체지방률, levels=c(1:4), labels=c('낮음',	'정상', '경도비만',	'비만'))
female_eval$분류_허리둘레 <- factor(female_eval$분류_허리둘레, levels=c(1:3), labels=c('정상', '복부비만','고도복부비만'))
female_eval$등급_윗몸일으키기 <- factor(female_eval$등급_윗몸일으키기, levels=c(1:3), labels=c('상', '중', '하'))
female_eval$등급_좌전굴 <- factor(female_eval$등급_좌전굴, levels=c(1:3), labels=c('상', '중', '하'))
female_eval$등급_제자리멀리뛰기 <- factor(female_eval$등급_제자리멀리뛰기, levels=c(1:3), labels=c('상', '중', '하'))
female_eval$등급_10m왕복빨리달리기 <- factor(female_eval$등급_10m왕복빨리달리기, levels=c(1:3), labels=c('상', '중', '하'))
female_eval$등급_20m왕복오래달리기 <- factor(female_eval$등급_20m왕복오래달리기, levels=c(1:3), labels=c('상', '중', '하'))
#female_eval$등급_상대악력 <- factor(female_eval$등급_상대악력, levels=c(1:3), labels=c('상', '중', '하'))
#female_eval$등급_악력 <- factor(female_eval$등급_악력, levels=c(1:3), labels=c('상', '중', '하'))

## 조건 (support=0.04, confidence=0.3, minlen=1, maxlen=2)으로 연관분석 시작
rule_female <- apriori(female_eval, parameter=list(support=0.04, confidence=0.3, minlen=1,maxlen=2))
## 규칙 요약 보기
summary(rule_female)
## 규칙 상세 보기
rule_female.df <- as(rule_female, "data.frame")
#여성 - BMI에 따른 운동능력의 등급 연관분석
rule_female.BMI<- inspect(subset(rule_female, subset=lhs %pin% "분류_BMI=" & rhs %pin% "등급"))
#여성 - 체지방률에 따른 운동능력의 등급 연관분석
rule_female.FAT<- inspect(subset(rule_female, subset=lhs %pin% "분류_체지방률=" & rhs %pin% "등급"))
#여성 - 허리둘레에 따른 운동능력의 등급 연관분석
rule_female.WRIST<- inspect(subset(rule_female, subset=lhs %pin% "분류_허리둘레=" & rhs %pin% "등급"))
#여성 - 분류가 비만일때 따른 운동능력 '하'등급 연관분석
rule_female.LOW<- inspect(subset(rule_female, subset=lhs %pin% "비만" & rhs %pin% "하"))
##기준을 충족한 규칙들중 연관성을 표현할수있는 lift를 기준으로 평가해보면(lift > 1만 다룸),
##BMI가 정상으로 분류된 집단은 8가지 룰을 가지고있는데, 그 중 "중" 3개, "상" 5개로 "하"등급은 1개도 없다.
##  경도비만으로 분류된 집단은 7가지 룰을 가지고있는데, 그 중 "중" 3개, "상" 4개 "하"등급은 1개도 없다.
##  비만으로 분류된 집단은 8가지 룰을 가지고있는데, 그 중 "하" 5개, "중" 3개로 "상"등급은 1개도 없다.
##  비만등급은 "상"등급이 1개도 없는 걸로보아 연관성이 있어보이기는 하나, 
##  경도비만으로 분류된 집단과 정상으로 분류된 집단 사이에 별다른 차이가 없다.
##  여성 또한 BMI는 제지방량과 지방량을 구분하지 못해서 근육량이 많은 사람들이 경도비만으로 분류되었을 가능성이 있어서 이런경향이 나타나는것 같다.
##  남성과 여성 모두 경도비만으로 분류된 집단은 좋은 신체등급을 가지고있고,
##  비만으로 분류된 집단부터 좋지못한 신체등급을 받고있다.
##  BMI 지수의 경도비만의 경계를 좀더 높여야될 필요성이 보인다.
##체지방률이 정상으로 분류된 집단은 5가지 룰을 가지고있는데, 모두 "상" 등급이다. 
##  경도비만으로 분류된 집단은 5가지룰을 가지고있는데, 그 중 "하" 1개, "중" 4개 "상"등급은 1개도 없다.
##  비만으로 분류된 집단은 8가지 룰을 가지고있는데, 그 중 "하" 5개, "중" 3개로 "상"등급은 1개도 없다.
##  여성 또한 정상에서 비만으로 체지방률이 증가함에따라 눈에띄게 "상"등급은 줄어들고, "하"등급이 늘어나는 패턴이 보인다.
##  남성과 여성 모두 정상과 경도비만의 경계가 BMI는 모호한데에 비해 체지방률은 정확하다고 볼수있다.
##허리둘레가 정상으로 분류된 집단은 8가지 룰을 가지고있는데, 그 중 "중" 3개, "상" 5개으로, "하"등급은 1개도 없다.
##  복부비만으로 분류된 집단은 10가지룰을 가지고있는데, 그 중 "하" 5개, "중" 5개로, "상"등급은 1개도 없다.
##  고도복부비만으로 분류된 집단은 5가지 룰을 가지고있는데, 모두 "하" 등급이다.
##남성과 여성 모두 체지방률과 허리둘레는 신체능력등급에서 서로 비슷한 수준의 경향을보이며 BMI보다 더 신체능력과 밀접한 연관성이 있다고 보인다.





### 결론 : 체지방률이 가장 정확하고 BMI보다 허리둘레가 체력수준을 더 잘 파악할수있다. 

#체지량지수인 BMI는 단순히 몸무게에 키의제곱을 나누는것으로 구할수있기 때문에 몸무게에 비례한다.
#체지방률은 쉽게 알기힘들기때문에 비교적 쉽게 알수있는 BMI를 이용하지만, 
#근육질인 운동선수들도 BMI지수로 바라본다면 비만일수있고 팔다리마르고 배만나온마른비만들도 BMI에서는 정상으로 나올수있다. 
#그렇기 때문에 BMI는 우리 신체건강상태를 파악할수있는 적절한 기준이 되지못한다. 
#우리는 질병을 제외하고서 신체적으로 건강하다는것은 신체적능력이 뛰어난것이라고 말할수있다.  
#이러한 신체적 퍼포먼스가 BMI에 영향을 많이 받는지 혹은 체지방률이나 허리둘레가 더 영향을 많이 받는것인지 데이터를 통해 알아보니,
#만약 우리가 운동을하거나 다이어트를 하려고한다면 근육이나 수분같은 제지방량이 빠져도 줄어들수있는 체중이나 BMI를 줄이는것보다 
#체지방이 집중되있는 복부지방을 줄이는 방향으로 허리둘레줄이기를 목표로하는것이 더욱 바람직 하다.
#그리고 다른 분류기준들에 비해 BMI는 정상과 경도비만의 구분이 모호하기때문에 BMI수치을 좀더 적절하게 이용하기 위해서는 기준을 현대체형에 맞게 조절해야할 필요가 있어보인다.


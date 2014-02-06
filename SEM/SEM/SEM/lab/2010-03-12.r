#ednopromenlivi danni
#KATEGORNI DANNI 
#pazqt w sebesi nqkakaw wid kategoriq 
#(primer: wazrast na horata, rasa)
#razglejdane na takuw wid danni - chrez tablici 
#tablici
#table(x) # x e wektor(kategorna promenliwa)
dali horta pusht ili ne
x = c("YES", "NO", "NO", "YES", "YES", "NO", "NO")
table(x)
factor(x) # wrashta razlichnite stoinosti na wektora
as.factor(x)

#barcharts - move da pokazwa proporciq
#25 choweka kakwi sa predpochitaniqta im za bira
#1 mestna bira w kutiq
#2 mestna bira butilka
#3 nalivna
#4 jiwa bira
bira = c(3,4,1,1,3,4,3,3,1,3,2,1,2,1,2,3,2,3,1,1,1,1,4,3,1)
barplot(bira)#iska winagi obobshteni danni
barplot(table(bira))
y = table(bira)
a = table(bira)/length(bira)
barplot(a)
colors = c("red", "green", "blue", "yellow")
barplot(a, col = colors)

#piecharts
#otnowo raboti s obobshteni danni
pie(y)
pie(a)
names(y) = c("domestic\ncan", "domestic\nbottle", "microbrew", "fresh")
pie(y, col = colors)

CHISLENI DANNI
#merki za centar i razmah
mean(bira) # sredno aritmetichno(ochakwane)
var(bira) #dispersiq
sd(bira) #standartno otklonenie
median(bira) #mediana na dannite

#fivenum
#summery

s = c(12, .4, 5, 2, 50, 8, 3, 1, 4, .25)
mean(s)
var(s)
sd(s)
median(s)

fivenum(s)
#min, lower hinge, median, upper hinge, max

summary(s)
#min, parwi kwantil, mediana, ochakwane, treti kwantil, maksimum


#10, 17, 18, 25, 28
#18 - median
#lower hinge = dannite < medianata i se wzima tqhnata mediana
#(10 + 17)/2 = 13.5
#analogichno upper hinge = 36.5

#kwantili 
#ako P e kwantil, to toj e stojnost m/u 0 i 1
#
#ako n brpi elementa
#to Q-ti kwantil e na poziciq 1+(n-1)*q
#x = c(10, 17, 19,25,28,28)
#n=6
#1+(6-1)*0.25 = 2.25
# 2 -> indeksa na stoinostta na kwantila
# .25 otstypamejdu izbranoto i sledwashtoto (2 i 3to chislo)
#w sluchaq
#x[2] + (x[2+1]-x[2])*.25
#17 + (19-17)*0.25
# Q1 - pyrwi kwartil/kwantil e 0.25tiq kwantil ili 100*0.25%
# Q3 - treti kwantil/kwartil e 0.75
d = c(10, 17,18,25,28,28)
summary(d)
quantile(d, 0.25) # koeficienta e chislo w interwala [0 : 1]
quantile(d, c(0.25, 0.75))

#USTOJCHIWI MERKI ZA CENTAR PO RAZMAH
#.   .   .   ... ..... .........:::::O::::...... ... .. .. ... ..... ... .    .
#w dwata kraq e outlier
ustojchiwa mqrka za centar towa e - medianata ili ochakwaneto na otrqzak ot dannite
#otrezowoto ochakwane
mean(vector_name, trim = 0.1)#
#trim smalqwa podadeniq wektor porawno ot dwete strani (pri 1/2 = median)

#IQR - interkwartilno razstoqnie Inter Quartil Range
# razlikata m/u 3ti i 1wi kwartil

#MAD - Median Average Deviation 
#ot wsqka stojnost na X wzima razlikata na medianata s neq, kato rezultata se wzima po modul
#i poluchenoto se umnojawa po 1.4826
#s tezi stojnosti se sazdawa now wektor i se wzima nowata mediana
mad(x)

#1) Stem-And-Leaf (stablo i lista)
#ima rezultat ot basketbolna igra, kao dannite sa tochkite
result = c(2,3,16,23,14,12,4,13,2,0,0,0,6,28,31,14,4,8,2,5)
aprops("stem") #tarsi funkciq sadarjashta posocheniq string w ime na funkciq ot sistemata
apropos("stem")
stem(result)
# 0 | 000222344568	chislata w dannite ot [0  - 10)
# 1 | 23446			chislata		 ot [10 - 20)
# 2 | 38			chislata 		    [20 - 30)
# 3 | 1						    [30 - 40)

v = c(12, 0.4, 5, 2, 50, 8, 3, 1, 4, 0.25)
#0 - 1 milion
#1 - 5 mil
#5 - max
v_cut = cut(v, breaks=c(0,1,5,max(v)))
v_cut
table(v_cut)
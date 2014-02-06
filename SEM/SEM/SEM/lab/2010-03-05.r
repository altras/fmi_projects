# komentar
#wektor s chisla parwi element s indeks 1 
typos = c(2,3,0,3,1,0,0,1)

#mean - matematichesko ochakwane (sredno aritmetichno)
mean(typos)

#mediana na mnojestwoto
#(sortira se i se wzima sredniq element)
#(ako sa chetni srednite 2 - sumata / 2)
median(typos)
median(c(1,2,2,2,4,5,6))

#var - dispersiq(otklonenie ot ochakwna stojnost na kwadrat)
#ako ne e na kwadrat - standartno otklonenie
var(typos)

t1 = typos
t2 = t1
t2[1] = 0
t1
t2 #elementite na t2
t2[-2] #elementite na t2 bez wtoriq
t2[c(1,2,4)] # parwi wtori i 4ti element na t2
t2
min(t2)
max(t2)
which(t2 == 3)#wrashta wektor s indeksite na namerenite po uslowieto
t2 == 3 #wrashta wektor kato nachalniq s rezultati ot uslowieto(true/false)
n = length(t2)# daljina na wektor
str = 1:n #s : se zadawa poredica(vektor) ot chisla 
str
str[t2 == max(t2)]

5:2

seq(2,8,0.1)

sum(t2) # suma elementite na wektor
sum(t2>0)

t1 - t2
t1 + t2
t1 * t2

#######################################################
#######################################################
x = c(45,43,46,48,51,46,50,47,46,45)
length(x) #10

mean(x) #srednata stojnost

var(x) #otklonenie

median(x)

max(x)
min(x)

x = c(x, 48,49,51,50,49)
length(x)

mean(x) #srednata stojnost

var(x) #otklonenie

median(x)

max(x)
min(x)


x[length(x)+1] = 41
x[17:20] = c(40,38,35,40)

mean(x) #srednata stojnost
var(x) #otklonenie
median(x)
max(x)
min(x)

den = 5
x[den:(den+11)]
max(x)
x
cummax(x) # natrupwasht se maksimum
cummin(x)


###############################


y = c(74, 122,235,111,292,111,211,133,156,79)
mean(y)
var(y)
#standartno otklonenie
std = sqrt(sum((y-mean(y))^2)/(length(y)-1))
std
sd(y) #funkciq za standartno otklonenie

std = function(x) 
{
	sqrt(var(x))
}
std(y)
z=1:10
z
z[2]
z[-2]

z[1:5]
z[(length(z)-5+1):length(z)]

z[z>4]
z[z < 3 | z > 6]

which(z==max(z))
########################################################
#galon za milq

kms = c(65311,65624,65908,66219,66499,66821,67145,67447)

izminati = diff(kms)
kms
izminati 

max(izminati)
min(izminati)
mean(izminati)

#######################################################
#rashodi za telefon

b = c(46,33,39,37,46,30,48,32,49,35,30,48)
sum(b)
sum(b>=40)/12*100







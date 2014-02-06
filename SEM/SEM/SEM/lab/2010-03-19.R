x = c(29.6, 28.2, 19.6, 13.7, 13.0, 7.8, 3.4, 2.0, 1.9, 1.0, 0.7, 0.4, 0.4, 0.3, 0.3, 0.3, 0.3, 0.3, 2, 0.2, 0.2, 0.1, 0.1, 0.1, 0.1)
hist(x)#chestota
hist(x, probability = TRUE) 
rug(jitter(x))

y = rnorm(10, 0, 1)

#kutiq s mustacu

boxplot(x, horizontal = T)

library('UsingR')

data(movies)

names(movies)
attach(movies)
detach(movies)
boxplot(movies, horizontal = TRUE)

library()	#importwa wshichki paketi
data()	#importwa wsichki danni

data(package = "name")#
#ako ima "simple" w imeto to e w UsingR paketa

help(movies)

#diagrami na neshta s 1 promenliwa

z = c(.21, .21, .21, .33, .33, .33, .33, .314, .289, .282, .279, .275, .267, .266, .265, .256, .250, .249, .211, .161)
simple.freqpoly(z)
hist(z)
# $ - wzimane na pod danni 
hz = hist(z)
lines(c(min(hz$breaks), hz$mids, max(hz$breaks)), c(0, hz$counts, 0), type = "l")

data("faithful")
attach(faithful)
?faithful

hist(eruptions)

hist(eruptions, 20, probability = T)
lines(density(eruptions))
lines(density(eruptions), bw = 0.1, col="red")

#####################################################################
#domashno
#1. Neka e daden wektora X sys slednite stojnotsti 1, 8, 2, 6, 3 ,8, 5, 5, 5, 5
# Izpolzwajte komandite na R, za da:
# a) (x1 + x2 + ... + x10) / 10
# b) log desetichen za wsqko xi i = 1..10
# c) za wsqko i = 1...10 => (xi - 4.4)/2.875
# d) namerete razlikata mejdu nai golqmoto i maj malkoto x w dadenoto mnojestwo stojnosti
#
#2. Neka X = rnorm(100) (100 sluchaini chisla s standartno normalno razpredelenie).
# Na tozi wektor da se pusne pone 2 pyti histograma i boxplot. 
# Da se obqsni ako ima razliki mevdu dwata rezultata
#
#3. histograma i boxplot za dannite ot "UsingR":
# south, cryme, aid. Koi ot dannite sa simetrichni, koi ne sa. 
# Koi imat outliers?
#
#
#
#
#
#
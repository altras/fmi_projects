%?????????? ??????????

expt=c(5,5,5,13,7,11,11,9,8,9)
control=c(11,8,4,5,9,5,10,5,4,10)
boxplot(expt,control)

boxplot(expt,control,horizontal=T)

kol=c(expt,control)
kol

gr=c(1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2)

% sprqmo ~
boxplot(gr~kol)

%????? ? ???????? ?????????
library("UsingR")
data(home)
attach(home)
names(home)
boxplot(scale(old),scale(new))
boxplot(old,new)

stripchart(old)
stripchart(old~new)
%??????? ?? ??????????
simple.violinplot(scale(old),scale(new))

%scatterplot
plot(old,new)

detach(home)

%novi danni
data(homedata)
attach(homedata)
names(homedata)
plot(y1970,y2000)
x=c(1,2)
x=1:2;y=c(2,4)
df=data.frame(x=x,y=y)
ls()
%remove rm
rm(y)
attach(df)
ls()
ls(pos=2)
y
x
%??????? ?????????? ?
x=c(x,3,4)
x
df
detach(df)
x
y
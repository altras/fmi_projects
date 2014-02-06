%lineina regresiq
%y~x
%y=a+bx
%bx-y+a=0 b-naklon na pravata a-otmestvane ot nachaloto
%y-otklik x-predikator
%yi=a+bxi yi-realni stoinosti
%eps(i)=y(i)chavka-y(i) greshka
%sum(i=1..n)(yi-yi^)^2
%y^=a+b*x
library("UsingR")
data(home)
names(home)
attach(home)
x=old; y=new
plot(x,y)
abline(lm(y~x))
simple.lm(x,y)
ls=simple.lm(x,y)
coef(ls)
%eps - residuals ostatuci
simple.lm(x,y,show.residuals=TRUE)
%qqplot
the.residuals=resid(ls)
plot(the.residuals)
cor(x,y)
cor(x,y)^2

z=c(2,3,5,7,11)
rank(z)
z=c(3,2,5,7,11)
rank(z)
z1=c(1,2,3,3,3,5,7,11)
rank(z1)
%rank-na vsi4ki ednakvi sredno aritmeti4no
z1=c(1,2,3,3,5,7,11)
rank(z1)
%spearman
cor(rank(x),rank(y))
%primer za lo6o subrani danni
data("florida")
names(florida)
attach(florida)
g=simple.lm(BUSH,BUCHANAN)
%klikane s mi6ka
identify() % dava koordinatite na nai blizkata to4ka
locator() %dava koordinatite na klika s mi6kata

identify(BUSH,BUCHANAN,n=2)
BUSH[50]
BUCHANAN[50]
g1=simple.lm(BUSH[-50],BUCHANAN[-50])
coef(g1)
coef(g)
BUCH=45.29+0.0049*BUSH[50]
simple.lm(BUSH[-50],BUCHANAN[-50],pred=BUSH[50])
abline(65.5735,0.00348,lty=2)
library("MASS")
data("florida")
plot(BUSH,BUCHANAN)
abline(lm(BUCHANAN~BUSH),lty=1)
abline(rlm(BUCHANAN~BUSH),lty=2)
legend(locator(1))
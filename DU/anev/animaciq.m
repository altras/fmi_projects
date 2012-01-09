clear all
close all
[t,x] = ode45(@sys1, [0,6], [-0.25,-0.25]);
for k = 1:length(x)
	plot(x(1:k,1),x(1:k,2))
	hold on
	plot(x(k,1),x(k,2),'o')
	axis([-10,10,-20,10]);
	M = getframe;
    hold off
end
movie(M)
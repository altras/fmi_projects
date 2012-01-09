function res = sys1(t,x)
res = [-2*x(1)+x(2)+4*x(1)^3;
       x(2)-x(1)];
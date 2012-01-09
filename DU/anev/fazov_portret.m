plot([-5, 5], [0, 0])
hold on
plot([0, 0], [-5, 5])
axis ([-5, 5, -5, 5])
[x0, y0] = ginput (1);
while x0 >= -5 & x0 <= 5 & y0 >= -5 & y0 <= 5
    [t, x] = ode45(@sys1, [0, 7], [x0, y0]);
    plot(x(:, 1), x(:, 2), 'k')
    [t, x] = ode45(@sys1, [0, -7], [x0, y0]);
    plot(x(:, 1), x(:, 2), 'r')
    [x0, y0] = ginput (1);
end
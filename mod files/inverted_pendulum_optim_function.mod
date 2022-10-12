control; u; -3; 3; 31

variable; x1; 0; -1; 1; 50; x2
variable; x2; 0; -1; 1; 50; sin(x1)+u

optim; x1*x1 + x2*x2 + u*u * 0.1
;Y = (1+x*x)*arctg(x)/2
.286
.model small
.data
dnd segment 'code'
assume cs:dnd, ds:dnd, ss:dnd, es:dnd
org 100h
begin: jmp main
;-------Данные -------------------
;mov ax, @data
;mov ds, ax

X dq 1.3
Y dq ?

DWA dq 2.0
TIME dq ?
TEM dq ?

my_s db '+'
T_Th db ?
Th db ?
Hu db ?
Tens db ?
Ones db ?

;---------------------------------
main proc near
;-------Команды программы --------
FINIT ; инициализация математического сопроцессора
FLD X 		; ST(0) = x = 1.3
FLD X		; ST(0) = x = 1.3; ST(1) = x = 1.3
FMUL 		; ST(0) = x*x
FLD1 		; ST(0) =1; ST(1) = x*x = 1.69
FADD 		; ST(0) = x*x +1 = 2.69
FSTP TIME 	; TIME = x*x +1 = 2.69
FLD X 		; ST(0) = x = 1.3
FPATAN		; ST(0) = 1; ST(1) = 0.915
FSTP X 		; X = 1
FSTP TEM 	; TEM= 0.915
FLD TEM		; ST(0) = 0.915
FLD DWA	; ST(0) = 2; ST(1) = 0.915
FDIV		; ST(0) = 0.915/2 = 0.4725
FLD TIME		; ST(0) = x*x +1  =2.69; ST(1) = 0.915/2 = 0.4725
FMUL		; ST(0) = 2.69 * 0.4725 = 1.27
FSTP Y 		; Y= 1.27

FLD Y
push 10
call outfloat

; аргумент — количество цифр дробной части
length_frac equ [bp+4]
; локальные переменные
ten equ word ptr [bp-2]
temp equ word ptr [bp-4]

ret
main endp

OutFloat proc near 
enter 4, 0 
mov ten, 10 
ftst 
fstsw ax 
sahf 
jnc @positiv 
mov al, '-'
int 29h 
fchs
@positiv:
fld1 
fld st(1)
fprem
fsub st(2), st 
fxch st(2)
xor cx, cx 
@1: 
fidiv ten 
fxch st(1) 
fld st(1)
fprem 
fsub st(2), st 
fimul ten
fistp temp
push temp
inc cx 
fxch st(1)
ftst
fstsw ax 
sahf 
jnz @1
@2:
pop ax 
add al, '0' 
int 29h
loop @2 

fstp st 
fxch st(1) 
ftst 
fstsw ax 
sahf 
jz @quit 
mov al, '.' 
int 29h 
mov cx, length_frac
@3: 
fimul ten
fxch st(1)
fld st(1)
fprem
fsub st(2), st
fxch st(2) 
fistp temp
mov ax, temp
int 29h
fxch st(1)
ftst 
fstsw ax 
sahf
loopne @3 
@quit: 
fstp 
fstp st 
leave
mov ah,08 ;ожидание нажатия клавиши
int 21h
ret 2 
OutFloat endp

dnd ends
end begin

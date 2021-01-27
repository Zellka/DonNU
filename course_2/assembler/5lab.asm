dnd segment 'code'
assume cs:dnd, ds:dnd, ss:dnd, es:dnd
org 100h
begin: jmp main
;-------Данные -------------------
n dw 40 ; количество разбиений
s dw 0 ; текущее значение суммы(интегралла)
a dw -1 ; начало отрезка
b dw 1 ; конец отрезка
x dw ? ; текущая точка
t dw ?
;---------------------------------
main proc near
;-------Команды программы --------
mov ax,a ; задаем начальную точку
mov x,ax
mov cx,39 ; счетчик цикла
m1:
; считаем f(x), т.е. в текущей точке
imul x ; dx:ax=x*x
mov bl, -1 	  
imul bl
add ax, 3 ; f(x)=ax=3-(x*x)
add s,ax ; наращиваем сумму(интеграл)
add x,1 ; переходим к следующей точке
mov ax,x ;
loop m1
;---------------------------------
mov ax,s
cwd ; dx:ax=s
mov bx,1
idiv bx ; s/1--> ax
mov s,ax
ret
main endp
dnd ends
end begin
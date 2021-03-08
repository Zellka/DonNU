ADDED macro p
local @w4,@m2,@m3

mov al,p ;счётчик цикла
mov spisok+25,al

endm
;---------------------------------

tanya segment 'code'
assume cs:tanya, ds:tanya, ss:tanya, es:tanya
org 100h
begin: jmp main

;-------Data -------------------
SPISOK db 17,35,88,23,18,31,34,58,72,95
       db 41,61,53,28,60,65,72,12,11,77
       db 81,56,44,76,10,?
	   
mes db 10,13,'What element should I add?', 10,13,'$'
buf db 4,4 dup(?)
ps db 10,13,'$'
sk db ?
des db ?
ed db ?
elem db ?  
xx db ?  
len db ?   
;---------------------------------

main proc near
;-------Команды программы --------
mov sk,25  
call print
call fun
;************* Макровызов********************************
ADDED elem
;****************************************************
mov sk,26   
call print
ret
main endp

; *********Считываем введённое число***************
fun proc near
; подсказка
mov ah,09
lea dx,mes
int 21h
; считываем с экрана число как строку
mov ah,0ah
lea dx,buf
int 21h
; преобразуем строку в число
cmp buf+1,1 ; сколько символов ввели?
jne @w1
;один символ ввели
mov al,buf+2
sub al,30h
jmp @w2 
@w1: ; две цифры
mov al,buf+2
sub al,30h
mov bl,10
imul bl
mov bl,buf+3
sub bl,30h
add al,bl
@w2: 
mov elem,al
; перевод строки
mov ah,09
lea dx,ps
int 21h
ret
fun endp


;*******выводим список на экран**********************************
print proc near
mov cl,sk
mov bp,0
@w3:
mov al,SPISOK+bp ; один элемент списка
cbw ; al --> ax
mov bl,10
idiv bl
mov des,al
mov ed,ah
; выводим десятки
mov ah,02
mov dl,des
add dl,30h
int 21h
; выводим единицы
mov ah,02
mov dl,ed
add dl,30h
int 21h
; выводим пробел
mov ah,02
mov dl,' '
int 21h
add bp,1 ; переход к следующему элементу
loop @w3
mov ah,09
lea dx,ps
int 21h
; ожидание нажатия на клавишу
mov ah,08
int 21h
ret
print endp


tanya ends
end begin

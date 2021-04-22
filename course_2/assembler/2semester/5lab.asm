yulya segment para 'code'
assume cs:yulya, ds:yulya,es:yulya,ss:yulya
org 100h
begin: jmp main
;----------------------------------------------------------
; выделение и инициализация ячеек оперативной памяти
s db 'Number of mouse keys = $'
nr db ?
s0 db 13,10,'The following mouse type is installed:',13,10,'$'
s1 db '1 - Bus Mouse',13,10,'$'
s2 db '2 - Serial Mouse',13,10,'$'
s3 db '3 - Inport Mouse',13,10,'$'
s4 db '4 - PS/2 Mouse',13,10,'$'
s5 db '5 - HP Mouse',13,10,'$'
X1 dw ?
Y1 dw ?
X db ?
Y db ?
MN db 8
s_k db 5 DUP(?)
 
; ---------------------------------------------------------
main proc near
; получение текущего видеорежима
mov ah,0fh
int 10h
mov nr,al ; nr - номер режима
; инициализация мыши
mov ax,0000h
int 33h
; вывод количества клавиш мыши
mov ah,09
lea dx,s
int 21h
mov ah,02
mov dl,bl
add dl,48
int 21h
; Получение информации о типе мыши ***************
mov ah,09
lea dx,s0
int 21h
mov ax,0024h
int 33h
; вывод информации о типе мыши ***************
cmp ch,1

jne @z2
; 1 тип
mov ah,09
lea dx,s1
int 21h
jmp @z100
@z2: cmp ch,2
jne @z3
; 2 тип
mov ah,09
lea dx,s2
int 21h
jmp @z100
@z3: cmp ch,3
jne @z4
; 3 тип
mov ah,09
lea dx,s3
int 21h
jmp @z100
@z4: cmp ch,4
jne @z5
; 4 тип
mov ah,09
lea dx,s4
int 21h
jmp @z100
@z5: cmp ch,5
jne @z100
; 5 тип
mov ah,09
lea dx,s5
int 21h
@z100:
; ожидание нажатия любой клавиши
mov ah,0 ; получаем номер клавиши
int 16h
; выключить курсор
mov ah,01
mov ch,20h
int 10h
; включить курсор мыши
mov ax,0001
int 33h

;изменяем форму мыши
mov ax, 000Ah
int 33h
mov bx, 1110
mov cx, 0
mov dx, 01418h

mov ah,08 ;ожидание нажатия клавиши
int 21h

; ******************************************************
ret ; возврат в операционную систему
main endp
yulya ends
end begin

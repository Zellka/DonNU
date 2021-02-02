nata segment 'code'
assume cs:nata
org 100h
begin: jmp main
;--------------------------------- DATA
Roads DB 11,'MOC11     ',12,'HAR12     ' 
DB 13,'KIR13     ',14,'LOP14     '
DB 15,'JUN15     ',16,'POC16     '
DB 17,'YIV17     ',18,'AUT18     '
DB 19,'SET19     ',20,'XOR20     '

Rezult DB 9 Dup(?),'$'
Buf DB 3,3 Dup(?)
Number DB ?
Mes DB 'Not found!$'
Eter DB 10,13,'$'
Podskaz DB 'Enter number:$'
;---------------------------------
main proc near
;------------------------------------- PROGRAM
; ------ Подсказка -------
mov ah,09
lea dx,podskaz
int 21h
; Ввод строки
mov ah,0ah
lea dx,Buf
int 21h
; Преобразование символов в число
; Получаем десятки из буфера
mov bl,buf+2
sub bl,30h
mov al,10
imul bl ; в al - десятки
; Получаем единицы из буфера
mov bl,buf+3
sub bl,30h
; Складываем ------
add al,bl
mov number,al ; сохраняем в number
; -------- Переход на новую строку ---
mov ah,09h
lea dx,eter
int 21h
; --- сканирование таблицы дорог ----
cld ; искать слева направо

mov cx,117 ; сколько байт сканировать
lea di,roads ; строка, где искать
mov al,number ; что искать
repne scasb ; поиск
je @m2
; ------- Сообщение об отсутствии дороги
mov ah,09h
lea dx,Mes
int 21h
jmp @m3 ; выходим из программы
; -------- переписываем в результат
@m2:
cld
mov si,di
lea di,rezult
mov cl,9
rep movsb
; ----- Вывод результата ----
mov ah,09h
lea dx,rezult
int 21h
;-------------------------------------
@m3: mov ah,08
int 21h
ret
main endp
nata ends
end begin

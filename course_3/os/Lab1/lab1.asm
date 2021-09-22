vanya segment 'code'
	assume cs: vanya, ds: vanya, ss: vanya, es: vanya
	org 100h
begin: jmp main

vib db ?
s db 10,13,'1 Create file',10,13
db '2 Open file ',10,13
db '3 Close file',10,13
db '4 Reading from a file',10,13
db '5 Write to file',10,13
db '6 Exit',10,13,'$'
osho db 10,13,'Unable to open file',10,13,'$'
oshcl db 10,13,'Unable to close file',10,13,'$'
oshcr db 10,13,'Unable to create file',10,13,'$'
oshr db 10,13,'Unable to read from file',10,13,'$'
oshw db 10,13,'Unable to write to file',10,13,'$'
normcr db 10,13,'File created successfully',10,13,'$'
normw db 10,13,'Data written to file',10,13,'$'
normr db 10,13,'Data read from file',10,13,'$'
normo db 10,13,'File opened',10,13,'$'
normcl db 10,13,'File closed',10,13,'$'
nepr db 10,13,'Error',10,13,'$'
papka db 'VANYA.txt',0
handle dw ? ; дескриптор файла
buffer dw ? ; буфер для записи

main proc near
nachalo: mov ah, 09h ; вывод меню
	lea dx, s
	int 21h
	; Ввод выбора
	mov ah, 01
	int 21h
	mov vib,al
	cmp vib,'6'
	jnz dalshe

	; конец программы (ожидание нажатия на клавишу)
	mov ah,08
	int 21h
	ret
dalshe: cmp vib,'1'
	je create
	cmp vib,'2'
	je open
	cmp vib,'3'
	je close
	cmp vib,'4'
	je read
	cmp vib,'5'
	je write
	; нажата неверная клавиша
	mov ah,09h
	lea dx, nepr
	int 21h
	ret
	;jmp nachalo
create: ; Создание файла
	call create_file
	jmp nachalo
open: ; Открытие файла
	call open_file
	jmp nachalo
close: ; Закрытие файла
	call close_file
	jmp nachalo
read: ; Считывание файла
	call read_file
	jmp nachalo
write: ; Запись файла
	call write_file
	jmp nachalo
ret
main endp

;****************** ; Процедура создания файла
create_file proc near
mov ah,3ch
mov cx,20h
lea dx,papka
int 21h
mov [handle],ax
jnc @normcr ; из help
; ошибка создания файла
mov ah,09h
lea dx,oshcr
int 21h
jmp konecs
@normcr: ; файл нормально создан
mov ah,09h
lea dx,normcr
int 21h
konecs: ret
create_file endp

;****************** ; Процедура открытия файла
open_file proc near
mov ah,3dh
lea dx,papka
int 21h
mov [handle],ax
jnc @normo ; из help
; ошибка открытия
mov ah,09h
lea dx,osho
int 21h
jmp koneco
@normo: ; файл нормально открылся
mov ah,09h
lea dx,normo
int 21h
koneco: ret
open_file endp

;****************** ; Процедура закрытия файла
close_file proc near
mov ah,3eh
lea dx,papka
int 21h
mov bx,[handle]
jnc @normcl ; из help
; ошибка закрытия
mov ah,09h
lea dx,oshcl
int 21h
jmp koneccl
@normcl: ; файл нормально закрылся
mov ah,09h
lea dx,normcl
int 21h
koneccl: ret
close_file endp

;****************** ; Процедура чтения из файла
read_file proc near
mov ah,3fh
lea dx,papka
int 21h
mov bx,[handle]
mov dx,buffer;буффер для данных
mov cx,10;количество считываемых байт
jnc @normr ; из help
; ошибка
mov ah,09h
lea dx,oshr
int 21h
jmp konecr
@normr: ; файл нормально считался
mov ah,09h
lea dx,normr
int 21h
konecr: ret
read_file endp

;****************** ; Процедура записи файла
write_file proc near
mov ah,40h
lea dx,papka
mov si, buffer
mov cx,10;количество считываемых байт
int 21h
jnc @normw ; из help
; ошибка
mov ah,09h
lea dx,oshw
int 21h
jmp konecw
@normw: ; файл нормально записался
mov ah,09h
lea dx,normw
int 21h
konecw: ret
write_file endp

vanya ends
end begin
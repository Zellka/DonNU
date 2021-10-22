Assume CS: Code, DS: Code
Code SEGMENT
org 100h

D 		equ 	523 	;До
Dsharp 		equ 	554 	;До#
R 		equ 	587	;Ре
Rsharp 		equ 	622 	;Ре#
M		equ 	659	;Ми
F 		equ 	698	;Фа
Fsharp 		equ 	740	;Фа#
S 		equ 	784	;Соль
Ssharp 		equ 	831	;Соль#
L 		equ 	880	;Ля
Lsharp 		equ 	932	;Ля#
C 		equ 	988	;Си

number_cycles 	equ 	100 	;число переключений динамика
port_b 		equ 	61h 	;адрес системного порта В

.286
Start proc near
	mov 	ax,cs
	mov 	ds,ax 		; DS = CS

; Обработка клавиш

beg1: 	call kbin 		; Опрос клавиатуры
	cmp al,'z' 		; = z ?
	jnz beg2 		;нет
	call ton1		;звук ноты C
	jmp beg1 		;переход на начало цикла
beg2:	
	cmp al,'s'				
	jnz beg3  				
	call ton2 				
	jmp beg1  				
beg3: 	
	cmp al,'x' 				
	jnz beg4 				
	call ton3 				
	jmp beg1 				
beg4: 	
	cmp al,'d' 				
	jnz beg5 				
	call ton4 				
	jmp beg1 				
beg5: 	
	cmp al,'c' 				
	jnz beg6 				
	call ton5 				
	jmp beg1 				
beg6: 	
	cmp al,'v' 				
	jnz beg7 				
	call ton6 				
	jmp beg1 				
beg7: 
	cmp al,'g' 				
	jnz beg8 				
	call ton7 				
	jmp beg1 				
beg8: 
	cmp al,'b' 				
	jnz beg9 				
	call ton8 				
	jmp beg1 				
beg9: 
	cmp al,'h' 				
	jnz beg10 				
	call ton9 				
	jmp beg1 				
beg10: 
	cmp al,'n' 					
	jnz beg11 				
	call ton10 				
	jmp beg1 				
beg11:
	cmp al,'j' 					
	jnz beg12 				
	call ton11 				
	jmp beg1 				
beg12:
	cmp al,'m' 				
	jnz begend 				
	call ton12 				
	jmp beg1 				

begend: cmp al,'q' 			; = 'q' ?
	jnz beg1 			;нет
	int 20h 			;выход из программы 
start endp		

; Воспроизведение звука

ton12 proc near				
	mov dx,number_cycles		;длительность
	mov di, C			;Си
	jmp ton0			;переход на универсальную процедуру генерации звука
ton11 proc near				
	mov dx,number_cycles	
	mov di, Lsharp		
	jmp ton0				
ton10 proc near
	mov dx,number_cycles	
	mov di, L				
	jmp ton0				
ton9 proc near
	mov dx,number_cycles	
	mov di, Ssharp			
	jmp ton0				
ton8 proc near
	mov dx,number_cycles	
	mov di, S			
	jmp ton0				
ton7 proc near
	mov dx,number_cycles	
	mov di, Fsharp			
	jmp ton0				
ton6 proc near
	mov dx,number_cycles	
	mov di, F				
	jmp ton0				
ton5 proc near
	mov dx,number_cycles	
	mov di, M			
	jmp ton0				
ton4 proc near
	mov dx,number_cycles	
	mov di, Rsharp			
	jmp ton0				
ton3 proc near
	mov dx,number_cycles	
	mov di, R			
	jmp ton0				
ton2 proc near
	mov dx,number_cycles	
	mov di, Dsharp			
	jmp ton0				
ton1 proc near 				
	mov dx,number_cycles 	
	mov di, D 				

;универсальная процедура генерации звука
; DX – количество циклов, DI – задержка

ton0 proc near
	cli 				;запрет прерываний
	in al,port_b 			;получаем статус порта
	and al,11111110b 		;отключаем динамик от таймера

ton01:	or al,00000010b 		;включаем динамик
	out port_b,al 		
	mov cx,di 			;счётчик цикла задержки
	loop $ 				;задержка
; Выключение звука
	and al,11111101b 		;выключение динамика
	out port_b,al 			;запись в системный порт В
	mov cx,di 			;счётчик цикла задержки
	loop $ 				;задержка
	dec dx 				;декремент счетчика колич. циклов
	jnz ton01 			;переход на начало нового периода
	sti 				;разрешение прерываний
	ret 					

ton0 endp 
					
ton1 endp 					
ton2 endp 					
ton3 endp					
ton4 endp					
ton5 endp					
ton6 endp					
ton7 endp					
ton8 endp					
ton9 endp					
ton10 endp					
ton11 endp					
ton12 endp					

kbin proc near 				;ожидание нажатие клавиши
	mov ah,0 			
	int 16h 				
	ret 					
kbin endp 					


code ends 					
END Start 			

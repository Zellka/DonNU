.686
.model flat, c
option casemap: none
ExitProcess PROTO STDCALL :DWORD
MessageBoxA PROTO STDCALL :DWORD,:DWORD,:DWORD,:DWORD
wsprintfA PROTO C :VARARG
.data
	TitleMsg db '1 задание',0 ; указываем буфер для форматированного вывода
	buffer db 128 dup(0) ; указываем строку формата со спецификациями форматов
	format db 'Ответ = %d', 0 ; задаем исходные данные
	a dd -5
	b dd 0
	k dd 6
	d dd ?
.code
program:
	push k ; кладём параметры в стек
	push b
	push a
	call Procedure
	add esp, 12 ; освобождаем 12 байт стека
	mov d, eax 
	push 0
	invoke wsprintfA, addr buffer, addr format, eax ; формируем строку вывода по заданному формату
	invoke MessageBoxA, 0, ADDR buffer, ADDR TitleMsg,0 ; выводим результат в диалоговое окно
	invoke ExitProcess,0
	call ExitProcess

Procedure proc
	mov eax, [esp + 4] ; заносим в EAX первый параметр
	mov edx, [esp + 8] ; заносим в EDX второй параметр
	mov ebx, [esp + 12] ; заносим в EBX третий параметр

	cmp eax, 1
	jge m1 ; если больше или равно 1, то уходим на метку m1
	cmp edx, 1
	jge m2 ; если больше или равно 1, то уходим на метку m2
	cmp ebx, 1
	jge m3 ; если больше или равно 1, то уходим на метку m3

	jl m4 ; если меньше 1, то уходим на метку m4

	m1:
		mov eax, 0
		jmp konec
	m2:
		mov eax, 1
		jmp konec
	m3:
		mov eax, 2
		jmp konec
	m4:
		mov eax, 3
		jmp konec

	konec:
	ret

Procedure endp

end program

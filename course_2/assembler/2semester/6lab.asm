;Y = (1+x*x)*arctg(x)/2

dnd segment 'code'
assume cs:dnd, ds:dnd, ss:dnd, es:dnd
org 100h
begin: jmp main
;-------Данные -------------------
X dd 1.3
Y dd ?
DWA dd 2.0
TIME dd ?
TEM dd ?
;---------------------------------
main proc near
;-------Команды программы --------
FINIT ; инициализация математического сопроцессора
FLD X 		; ST(0) = x = 1.3
FLD X		  ; ST(0) = x = 1.3; ST(1) = x = 1.3
FMUL 		  ; ST(0) = x*x
FLD1 		  ; ST(0) =1; ST(1) = x*x = 1.69
FADD 		  ; ST(0) = x*x +1 = 2.69
FSTP TIME ; TIME = x*x +1 = 2.69
FLD X 		; ST(0) = x = 1.3
FPATAN		; ST(0) = 1; ST(1) = 0.915
FSTP X 		; X = 1
FSTP TEM 	; TEM= 0.915
FLD TEM		; ST(0) = 0.915
FLD DWA	  ; ST(0) = 2; ST(1) = 0.915
FDIV		  ; ST(0) = 0.915/2 = 0.4725
FLD TIME	; ST(0) = x*x +1  =2.69; ST(1) = 0.915/2 = 0.4725
FMUL		  ; ST(0) = 2.69 * 0.4725 = 1.27
FSTP Y 		; Y= 1.27

ret
main endp
dnd ends
end begin

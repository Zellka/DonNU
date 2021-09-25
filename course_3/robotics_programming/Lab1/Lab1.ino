const int GREEN = 11;             
const int YELLOW = 12;
const int RED = 13;   

const int TIMEPICK = 4000; //период свечения светодиода.

void setup()
{
	//переводим все порты в состояние вывода информации
	pinMode(GREEN, OUTPUT);
	pinMode(YELLOW, OUTPUT);
	pinMode(RED, OUTPUT); 

	//устанавливаем начальное значение светодиодов
	digitalWrite(GREEN, LOW);
	digitalWrite(YELLOW, LOW);
	digitalWrite(RED, LOW);
}  

void loop()
{
	digitalWrite(GREEN, HIGH); //включается зелёный            
	delay(TIMEPICK);            

	digitalWrite(GREEN, LOW); //выключается зелёный
	digitalWrite(YELLOW, HIGH); //включается жёлтый        
	delay(TIMEPICK);            

	digitalWrite(YELLOW, LOW); //выключается жёлтый
	digitalWrite(RED, HIGH); //включается красный    
	delay(TIMEPICK);                           
	digitalWrite(RED, LOW); //выключается красный

/* VIRANDOLA 
 
GND - GND 
SIG - D2 
+5V - D3 
*/ 
 
int hits = 0; 
float wheel_radius = 1; 
volatile unsigned int current_time; 
//how often do you want to know velocity (milliseconds) 
long time_interval = 200;  
//this is the velocity in length units / time_interval 
float velocity;  
 
void setup () {   
    Serial.begin(9600);   attachInterrupt(digitalPinToInterrupt(2), count, CHANGE);   
    current_time = millis();   
    pinMode(3, OUTPUT);   
    digitalWrite(3, HIGH);  
} 
 
void loop () {   
    if ( millis() >= current_time + time_interval)     {     
        // the constant is 2*pi*1000/16     
        velocity = (hits*(wheel_radius * 392.7))/time_interval;
        Serial.println(velocity);     
        hits = 0;     
        current_time = millis();
        
        
        } 
}   
 
void count() {  hits++; } 

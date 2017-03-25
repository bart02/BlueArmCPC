#include <Servo.h> 
Servo myservo9;

String message;
int jh;
int j = 0;
int asd[5];



void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  myservo9.attach(9);
}

void loop() {
  while (Serial.available()){
    char s = Serial.read();
    if (s == ';') {
      asd[j] = message.toInt();
      Serial.print(j);
      Serial.println(asd[j]);
      message = "";
      j++;
      if (j == 5) j = 0;
    } else if (s == 'x') {
      //message.toInt(); otpravlaem na motor
      message = "";
    } else {
      message = message + s; 
      //otpravka na motori
    }
  }
  myservo9.write(asd[0]);
}

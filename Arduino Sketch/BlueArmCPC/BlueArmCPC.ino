#include <VarSpeedServo.h>
 
VarSpeedServo ocn;
VarSpeedServo lokot;

#define SPEED 50

String message;
int jh;
int j = 0;
int asd[5];



void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  ocn.attach(2);
  lokot.attach(4);
  Serial.println("(RE)START");
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
  ocn.write(asd[0], SPEED, false);
  lokot.write(asd[1], SPEED, false);
}

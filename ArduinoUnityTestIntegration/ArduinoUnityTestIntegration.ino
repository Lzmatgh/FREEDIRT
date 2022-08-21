/*
    This sketch demonstrates how to set up a simple HTTP-like server.
    The server will set a GPIO pin depending on the request
      http://server_ip/gpio/0 will set the GPIO2 low,
      http://server_ip/gpio/1 will set the GPIO2 high
    server_ip is the IP address of the ESP8266 module, will be
    printed to Serial when the module is connected.
*/

#include <ESP8266WiFi.h>
#include <WiFiUdp.h>

#ifndef STASSID
#define STASSID "your-ssid"
#define STAPSK  "your-password"
#endif

//const char* ssid = "FreeDirt";
//const char* password = "freethedirt";
const char* ssid = "TheDolphinCriesAtMidnight";
const char* password = "dolphintears";
const int port = 4001;
char tempChar = 0;


// Create an instance of the server
// specify the port to listen on as an argument

WiFiServer server(5001);


int input1 = 0; // pin0 input1
int input2 = 13; // pin13 input2
int input3 = 16; //pin16 input3
int input4 = 2; // pin2 input4

boolean prevConnected = false;
int timer = 0;
int lastTimer = 0;
int checkInterval = 10000;

char packetBuffer[255]; //buffer to hold incoming packet
char  ReplyBuffer[] = "";       // a string to send back


void setup() {
  IPAddress ip(192, 175, 0, 20); 
  IPAddress gateway(192, 175, 0, 1); 
  IPAddress subnet(255, 255, 255, 0); 
  IPAddress DNS(192, 175, 0, 1);

  WiFi.config(ip, gateway, subnet, DNS);
  delay(100);
  
  Serial.begin(115200);
  WiFi.begin(ssid, password);

  while (!Serial) {
    ;
  }
  //reset each IO, the mode is OUTPUT
  pinMode(input1, OUTPUT);
  pinMode(input2, OUTPUT);
  pinMode(input3, OUTPUT);
  pinMode(input4, OUTPUT);


  // Connect to WiFi network
  Serial.println();
  Serial.println();
  Serial.print(F("Connecting to "));
  Serial.println(ssid);

  WiFi.mode(WIFI_STA);

  if (WiFi.status() == WL_NO_SHIELD) {
    Serial.println("WiFi shield not present");
    while (true);
  }

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(F("."));
    WiFi.begin(ssid, password);

  }
  Serial.println();
  Serial.println(F("WiFi connected"));

  // Start the server
  server.begin();
  Serial.println(F("Server started"));

  // Print the IP address
  Serial.println(WiFi.localIP());
}

void loop() {
  // Check if a client has connected
  WiFiClient client = server.available();
  if (!client) {
    return;
  }
  Serial.println(F("new client"));
  client.setTimeout(5000);

  if (client.available()) {
    seekCommand(client);
  }

  int packetSize = Udp.parsePacket();
  if(packetSize) {
    IPAddress remoteIp = Udp.remoteIP();
    Serial.print(remoteIp);
    Serial.print(", port: ");
    Serial.print(Udp.remotePort());

    int len = Udp.read(packetBuffer, 255);
    if (len > 0) {
      packetBuffer[len] = 0;
    }
    Serial.println("Contents:");
    Serial.println(packetBuffer);

    char str(packetBuffer);
  }
}

void seekCommand(char tempChar)
{
   //tempChar = client.read();
    //client.flush();
    if (tempChar == 's') {     //character is '0'
      Serial.print("Stop");
      //client.println("Stop");
      //Trigger a movement.
    }
    else if (tempChar == 'f') {   //character is '1'
      Serial.print("Forward");
      //client.println("Forward");
      //Trigger a movement.
    }
    else if (tempChar == 'b') {   //character is '2'
      Serial.print("Backward");
      //client.println("Backward");
      //Trigger a movement.
    }
    else if (tempChar == 'l') {   //character is '3'
      Serial.print("Left turn");
      //client.println("Left turn");
      //Trigger a movement.
    }
    else if (tempChar == 'r') {   //character is '4'
      Serial.print("Right turn");
      //client.println("Right turn");
      //Trigger a movement.
    }
    else {
      Serial.print("invalid command");
    }
}

void moveForward()
{
  digitalWrite(input1, HIGH); // high voltage
  digitalWrite(input2, LOW); // low voltage
  digitalWrite(input3, HIGH);
  digitalWrite(input4, LOW);
}

void moveBackward()
{
  digitalWrite(input1, LOW);
  digitalWrite(input2, HIGH);
  digitalWrite(input3, LOW);
  digitalWrite(input4, HIGH);
}

void moveLeft()
{
  digitalWrite(input1, LOW);
  digitalWrite(input2, HIGH);
  digitalWrite(input3, HIGH);
  digitalWrite(input4, LOW);
}

void moveRight()
{
  digitalWrite(input1, HIGH);
  digitalWrite(input2, LOW);
  digitalWrite(input3, LOW);
  digitalWrite(input4, HIGH);
}

void moveStop()
{
  digitalWrite(input1, LOW);
  digitalWrite(input2, LOW);
  digitalWrite(input3, LOW);
  digitalWrite(input4, LOW);
}

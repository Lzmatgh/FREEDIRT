/*
    This sketch demonstrates how to set up a simple HTTP-like server.
    The server will set a GPIO pin depending on the request
      http://server_ip/gpio/0 will set the GPIO2 low,
      http://server_ip/gpio/1 will set the GPIO2 high
    server_ip is the IP address of the ESP8266 module, will be
    printed to Serial when the module is connected.
*/

#include <ESP8266WiFi.h>

#ifndef STASSID
#define STASSID "your-ssid"
#define STAPSK  "your-password"
#endif

//const char* ssid = "FreeDirt";
//const char* password = "freethedirt";
const char* ssid = "TheDolphinCriesAtMidnight";
const char* password = "dolphintears";
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

void setup() {
  Serial.begin(115200);

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
  //  digitalWrite(input2,LOW);  // low voltage
  // Check if a client has connected
  WiFiClient client = server.available();
  if (!client) {
    return;
  }
  Serial.println(F("new client"));
  client.setTimeout(5000); // default is 1000

  if (client) {
    if (!prevConnected) {
      client.flush();
      Serial.println("Client has connected");
      client.println("To client from server");
      prevConnected = true;
    }
  }
  else {
    if (prevConnected) {    // if there has just been a client, set alreadyConnected to false and flash the lights off
      prevConnected = false;

    }
    client.println("Off");  // tell Unity light is off
    prevConnected = false;
    if (timer - lastTimer > checkInterval) { // if the current time minus the last time is more than the check interval
      Serial.println("No client available");
      lastTimer = timer;
    }
  }

  if (client.available()) {
    seekCommand(client);
  }
}

 void printWifiStatus() {
   // print the SSID of the network you're attached to:
   Serial.print("SSID: ");
   Serial.println(WiFi.SSID());
 
   // print your WiFi shield's IP address:
   IPAddress ip = WiFi.localIP();
   Serial.print("IP Address: ");
   Serial.println(ip);
 
   // print the received signal strength:
   long rssi = WiFi.RSSI();
   Serial.print("signal strength (RSSI):");
   Serial.print(rssi);
   Serial.println(" dBm");
 }

void seekCommand(WiFiClient client)
{
   tempChar = client.read();
    client.flush();
    if (tempChar == 's') {     //character is '0'
      Serial.print("Stop");
      client.println("Stop");
      //Trigger a movement.
    }
    else if (tempChar == 'f') {   //character is '1'
      Serial.print("Forward");
      client.println("Forward");
      //Trigger a movement.
    }
    else if (tempChar == 'b') {   //character is '2'
      Serial.print("Backward");
      client.println("Backward");
      //Trigger a movement.
    }
    else if (tempChar == 'l') {   //character is '3'
      Serial.print("Left turn");
      client.println("Left turn");
      //Trigger a movement.
    }
    else if (tempChar == 'r') {   //character is '4'
      Serial.print("Right turn");
      client.println("Right turn");
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

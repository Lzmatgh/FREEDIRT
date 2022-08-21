#include <ESP8266WiFi.h>
#include <WiFiUdp.h>

//SSID of your network
char ssid[] = "TUI"; //SSID of your Wi-Fi router
char pass[] = "password"; //Password of your Wi-Fi router
int keyIndex = 0;

unsigned int localPort = 4000;
char packetBuffer[255]; //buffer to hold incoming packet
char  ReplyBuffer[] = "";       // a string to send back

WiFiUDP Udp;

int input1 = 0; // pin0 input1
int input2 = 13; // pin13 input2
int input3 = 16; //pin16 input3
int input4 = 2; // pin2 input4

void setup()
{
  pinMode(input1, OUTPUT);
  pinMode(input2, OUTPUT);
  pinMode(input3, OUTPUT);
  pinMode(input4, OUTPUT);


  IPAddress ip(192, 175, 0, 20);
  IPAddress gateway(192, 175, 0, 1);
  IPAddress subnet(255, 255, 255, 0);
  IPAddress DNS(192, 175, 0, 1);
  Serial.begin(115200);
  WiFi.config(ip, gateway, subnet, DNS);
  delay(100);
  //WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, pass);
  Serial.print("Connecting");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(200);
  }
  while (WiFi.waitForConnectResult() != WL_CONNECTED) {
    Serial.println();
    Serial.println("Fail connecting");
    delay(5000);
    ESP.restart();
  }
  Serial.print("   OK  ");
  Serial.print("Module IP: ");
  Serial.println(WiFi.localIP());
  printWifiStatus();
  // if you get a connection, report back via serial:
  Udp.begin(localPort);
}

void loop () {
  // if there's data available, read a packet
  int packetSize = Udp.parsePacket();

  if (packetSize) {
    Serial.print("Received packet of size ");
    Serial.println(packetSize);
    Serial.print("From ");
    IPAddress remoteIp = Udp.remoteIP();
    Serial.print(remoteIp);
    Serial.print(", port ");
    Serial.println(Udp.remotePort());

    // read the packet into packetBufffer
    int len = Udp.read(packetBuffer, 255);
    if (len > 0) {
      packetBuffer[len] = 0;
    }
    Serial.println("Contents:");
    Serial.println(packetBuffer);

    String str(packetBuffer);

    seekCommand(str);

    Serial.println(ReplyBuffer);
    Serial.println(Udp.remoteIP());
    Serial.println(Udp.remotePort());

    // send a reply, to the IP address and port that sent the packet
    Udp.beginPacket(Udp.remoteIP(), 4001);
    Udp.write(ReplyBuffer);
    Udp.endPacket();
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


void seekCommand(String comm)
{
  if (comm == "s") {     //character is '0'
    Serial.print("Stop");
    //client.println("Stop");
    //Trigger a movement.
    moveStop();
  }
  else if (comm == "f") {   //character is '1'
    Serial.print("Forward");
    //client.println("Forward");
    //Trigger a movement.
    moveForward();
  }
  else if (comm == "b") {   //character is '2'
    Serial.print("Backward");
    //client.println("Backward");
    //Trigger a movement.
    moveBackward();
  }
  else if (comm == "l") {   //character is '3'
    Serial.print("Left turn");
    //client.println("Left turn");
    //Trigger a movement.
    moveLeft();
  }
  else if (comm == "r") {   //character is '4'
    Serial.print("Right turn");
    //client.println("Right turn");
    //Trigger a movement.
    moveRight();
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

#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClient.h>

const char* ssid = "REPLACE_WITH_YOUR_SSID";
const char* password = "REPLACE_WITH_YOUR_PASSWORD";

String api = "http:/ijerk.pro/api";


void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED)
  {
    delay(1000);
    Serial.println("Connecting to WiFi..");
  }  
}

void loop() {
  if (WiFi.status() == WL_CONNECTED)
  {
    HTTPClient http;

    http.begin(api);
    http.addHeader("Content-Type", "text/plain");

    int httpCode = http.POST("Message from ESP8266");
    String payload = http.getString();

    Serial.println(httpCode);
    Serial.println(payload);

    http.end();
  } else {
    Serial.println("WiFi not connected");
  }
}

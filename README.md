# 🛡️ Project: Urban Security Application for Women

This repository contains the documentation and core concepts for a specialized security application designed to help women feel safer when walking alone, especially at night.

## 1. Introduction and Purpose

The primary mission of this application is to enhance personal safety through a map-based interface. Users can define their starting point and destination, receiving guidance through verified "Safe Routes."

> **Restricted Distribution:** This application is not available for general public download. It is distributed and installed exclusively through official entities, such as city councils and local governments, to ensure the integrity of the user network.

---

## 2. Privacy and Data Management

Privacy and anonymity are the fundamental pillars of the system architecture.

*   **Network Anonymity:** The application does not store any personal user data. The system operates using a unique code. The local city council is the only entity capable of linking this code to a real identity; the application server operates exclusively with anonymous codes.
*   **Ephemeral Journey Management:** Journey data is automatically deleted as soon as the trip ends.
*   **Report Exception:** If a user reports inappropriate behavior through the chat after a journey, the data is preserved and sent to official bodies for evaluation.
*   **Camouflage Mode (Incognito):** To prevent an aggressor from knowing a security app is being used, the main interface can adopt the appearance of another application (e.g., a music player, calculator, or news feed). Emergency functions are activated via hidden gestures (e.g., two-finger swipe).

---

## 3. Safety Features (Prevention and Passive Security)

### 🗺️ Routes and Navigation
*   **"Safe" vs. Fast Routes:** Instead of prioritizing the shortest path, the app suggests a "Safe Route." Based on municipal data, it prioritizes well-lit streets, areas with security cameras, and main roads.
*   **Automatic Arrival Notification:** Contact management is performed locally on the phone. Upon reaching the destination, the device automatically sends an SMS to pre-configured family members: *"I have arrived safely."*

### 🤝 Community and Accompaniment
*   **Nearby Support Network:** When a journey begins, the app notifies nearby users in case they wish to accompany the user, call her, or send a message.
*   **Voluntary Physical Encounters:** If two users share a common path, the app asks both if they wish to be introduced to walk together. If both accept, they are put in contact.
*   **Identity Validation (Anti-Impersonation):** To ensure the person approaching is the correct user, both screens will display a specific color or a random keyword (e.g., "Apple") to serve as a password/signal.

### ⚠️ Active Prevention
*   **Deviation Alert (Monitor Mode):** If the GPS detects a drastic deviation, an unusual stop, or a sudden change in speed, the app prompts: *"Are you okay?"*. If there is no response within 15 seconds, the Panic sequence is activated.
*   **"Fake Call" Mode:** A discreet button that simulates a realistic incoming call (with recorded voice and pauses) to act as a deterrent.
*   **Safe Havens (Refuge Points):** The map shows participating local businesses (24h pharmacies, gas stations, bars) where staff are trained to offer assistance.

---

## 4. Emergency System: The Panic Button

The application features a large button designed for use in situations of fear, harassment, or stalking.

### ⏳ Activation Sequence
Once pressed, a **10-second grace countdown** begins. This allows for cancellation in case of an accidental press. If not stopped, the alarm is emitted automatically.

**Alarm Recipients:**
1. Nearby users.
2. Relevant official agencies.
3. Police forces.
4. User's emergency contacts.

### 🚨 Advanced Activation Modes
*   **"Dead Man's Switch" (High Tension):** When crossing a dangerous area, the user can walk while keeping a finger pressed on the screen. If they let go (e.g., during a struggle), a PIN is requested. If not entered within 5 seconds, the alarm triggers.
*   **Hardware Activation:** Alerts can be launched without looking at the screen by repeatedly pressing the power button or shaking the device violently.
*   **Automatic Encrypted A/V Recording:** After the 10-second countdown, the microphone and camera begin recording. This file is encrypted instantly and sent *exclusively* to the police/official server. Even the user cannot play it back.

---

## 5. Participation and Urban Planning

*   **Anonymous Heat Maps:** After a successful journey, the user can mark points on the map reporting *"Poor lighting"* or *"Intimidating presence."* This data is sent 100% anonymously to the city council to optimize patrols or urban maintenance.

---

## 📑 Glossary of Terms

### Core Concepts & Privacy
*   **Anonymity:** No personal data is stored; users are identified only through unique codes.
*   **Camouflage Mode:** Disguises the app interface as a common tool (e.g., calculator).
*   **Ephemeral Data:** Automatic deletion of trip data once completed.
*   **Institutional Distribution:** Provided only through official government channels.

### Navigation & Prevention
*   **Automatic Arrival Notification:** Local SMS sent once destination is reached.
*   **Deviation Alert:** Safety check triggered by sudden route changes or stops.
*   **Safe Havens:** Businesses partnered with the city to provide assistance.

### Community & Support
*   **Companion Identity Validation:** Screen color or "watchword" to verify users meeting.
*   **Peer Support Network:** Alerts nearby users when a journey starts.

### Emergency Systems
*   **Dead Man's Switch:** requires constant finger contact or triggers alarm.
*   **Encrypted A/V Recording:** Automatic capturing of audio/video during emergencies.
*   **Grace Period:** 10-second window to cancel false alarms.

---

## 📱 Application Flow and Pages

### 1. Access and Initial Setup
*   **Welcome Screen:** Official logos.
*   **Access Screen:** Login via **User Code** provided by the city council.
*   **Emergency Contact Setup:** Local form for adding SMS contacts.
*   **Security PIN:** Creation of a PIN to cancel alarms.

### 2. Journey Planning
*   **Main Screen:** Map with current location, destination search, and **Safe Havens**.
*   **Route Selector:** Comparison between "Safe Route" and "Fast Route."

### 3. Active Journey Mode
*   **Navigation Screen:** Real-time GPS tracking with floating safety buttons.
*   **Fake Call Simulator:** Interface mimicking a native incoming call.
*   **Monitor Mode Pop-up:** Prompting for safety confirmation if a deviation occurs.

### 4. Community and Encounters
*   **Nearby Users List:** Options to call or message women nearby for support.
*   **Safe Chat:** Basic messaging with a "Report" button for inappropriate behavior.
*   **Validation Screen:** Matching colors or large text keywords for physical recognition.

### 5. Emergency and Panic
*   **Panic Countdown:** Flashing red screen with a 10 to 0 countdown.
*   **Active Panic Mode:** Encrypted recording and live location sharing with authorities.
*   **Panic Deactivation:** PIN pad to stop the alarm.

### 6. End of Journey
*   **Arrival Screen:** Success animation and automatic SMS notification.
*   **Evaluation Screen:** Perception survey and **Anonymous Reporting Pins** for urban issues.

### 7. Settings
*   **Camouflage Configuration:** Selection of the fake UI (Calculator, Music Player, etc.).
*   **Hardware Settings:** Enabling power button or shake-to-trigger alerts.

---

## 7. Technical Architecture

The ecosystem consists of three main projects:

*   **RutasApp**: A cross-platform **.NET MAUI** application for the end-user. It uses a local **SQLite** database for persistent storage, managed through **Entity Framework Core (Code First)**.
*   **RutasBackend**: A web-based administration portal for official entities to manage user codes and oversight. It utilizes **SQL Server** and **Entity Framework Core (Code First)**.
*   **RutasAppShared** (named `RutasAppBackend` in the filesystem): A shared class library that provides common models and business logic to both the mobile application and the backend.

### Communication and Real-time Updates
The mobile application (**RutasApp**) and the administrative portal (**RutasBackend**) communicate in real-time using **SignalR**, ensuring immediate alerts and data synchronization.

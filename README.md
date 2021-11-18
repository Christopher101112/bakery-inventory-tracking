# bakery-inventory-tracking
Inventory tracking application for Rice & Beans, LLC.

2021 Inventory Tracking App @Author = ChristopherPouch

DEMONSTRATION

To see a 3-minute YouTube video explaining and demonstrating this program, follow this link: https://youtu.be/hWRfng1jdC0 .

PERMISSIONS

This program was written for a private company, but the code is published here with permission from said company. 
Permission was granted because there is no sensitive company information in the source code, and because the company will soon transition to a separate
web-based version of this program.

CONTENTS

This repository contains source code for the inventory tracking app. It does not contain the database necessary to run the app, so you will not be able to compile.

OVERVIEW

This program is designed to keep track of company inventory, and to log a history of inventory and customer order changes.
The program is designed to run on a single computer in the production room, and serves mainly as a tool for workers on the factory floor as opposed to management.
The design is based upon 'Pages', which are essentially classes with only one instance. Each page contains all its own frontend and backend code.
This app uses a PostgreSQL database on disk, which is queried and updated through a custom ORM located in the source code (PostgreSQL.cs).

HOW TO RUN

Do not attempt to run this program, it will not work as the database is not included here.

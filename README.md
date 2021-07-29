# Async-Inn

## Lab-13
Created services for the models, to hand off request tasks from the default methods created by the controller to the services with implemented interfaces for each corresponding model

## Author
Benjamin Ibarra  


## Colaborators
Q Hashi  
Dave Arno  

## Visual
![ERD](./ERD.png)

Async Hotel
- Location(grabs info from Location Tabel)
- Name(grabs name from Location Tabel)

Locations
- Contains Hotel: Name, City, State, Address, Phone Number

Rooms
- List of avaibale rooms at this location

Empire Suite
- City of Room
- Amenties provided with room

Subway Suite
- City of Room
- Amenties provided with room

Amenties 1
- Contains the amenties for this type of room

Amenities 2
- Contains the amenties for this type of room

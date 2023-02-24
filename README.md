<<<<<<< HEAD
# Meetup

How to start: The solution has 2 microservice projects with onion architecture, each contains its own database. For the correct work of application, you need to configure the databases and start both microservices.

The project has authentication via bearer token. So you need to get a token from the Login.API and put it in a request to receive events. (you can use postman)

The project has role restrictions (admin/user). A simple user can only view events, please note this.

Endpoint list:

https://localhost:5001/Event (Get/Put/Post/Detele - for all interactions with events);

https://localhost:7044/Login (Post - to get JWT, Get/Put/Delete - to get/update/delete users);

https://localhost:7044/Register (Post - register new user);
=======
# Meetup test project

How to start: 
The solution has 2 microservice projects, each contains its own database.
For the correct work of application, you need to configure the databases and start both microservices.

The project has authentication via bearer token. 
So you need to get a token from the Login.API and put it in a request to receive events.
(you can use postman)

The project has role restrictions (admin/user). A simple user can only view events, please note this.

Endpoint list: 

https://localhost:5001/Event (Get/Put/Post/Detele) - for all interactions with events

https://localhost:7044/Login (Get) - to get JWT
>>>>>>> 62bcc0b86593750bcbf0468873a0bebb70403182

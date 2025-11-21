# REST in ASP.NET Core

When you browse to a webpage, the web server communicates with your browser by using HTML, CSS, and JavaScript. For example, If you interact with the page by submitting a sign-in form or selecting a buy button, the browser sends the information back to the web server.

In a similar way, web servers can communicate with a broad range of clients (browsers, mobile devices, other web servers, and more) by using web services. API clients communicate with the server over HTTP, and the two exchange information by using a data format such as JSON or XML. APIs are often used in single-page applications (SPAs) that perform most of the user-interface logic in a web browser. Communication with the web server primarily happens through web APIs.

# REST: A common pattern for building APIs with HTTP

Representational State Transfer (REST) is an architectural style for building web services. REST requests are made over HTTP. They use the same HTTP verbs that web browsers use to retrieve webpages and send data to servers.

An API often needs to provide services for a few different but related things. For example, our pizza API might manage pizzas, customers, and orders. We use routing to map URIs (uniform resource identifiers) to logical divisions in our code, so that requests to <https://localhost:5000/pizza> are routed to PizzaController and requests to <https://localhost:5000/order> are routed to OrderController.

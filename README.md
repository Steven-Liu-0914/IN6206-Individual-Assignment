This repository demonstrates various authentication methods commonly used in web applications, implemented with ASP.NET Core and C#. Each method includes practical examples, security considerations, and Postman testing instructions to help developers understand and apply secure authentication.

Authentication Methods
1. HTTP Basic Authentication
Simple username-password authentication encoded in Base64.
Security Tip: Always use HTTPS to protect credentials.
Testing: Use Basic Auth in Postman’s Authorization tab.

2. Session-Based Authentication
Manages user sessions on the server after login, using session cookies.
Security Tip: Set session timeouts to enhance security.
Testing: Send a login request to create a session, then access secure endpoints.

4. Token-Based Authentication (JWT)
Issues a JSON Web Token (JWT) for stateless authentication, suitable for APIs.
Security Tip: Use short-lived tokens and HTTPS.
Testing: Obtain a JWT on login, then include it in the Authorization header.

4. Multi-Factor Authentication (MFA)
Adds extra verification steps, like OTP, to strengthen security.
Security Tip: Recommended for high-security applications.
Testing: Log in to receive an OTP, then verify it before accessing secure data.

6. API Key Authentication
Uses an API key to control access to resources.
Security Tip: Limit API keys to specific routes and use rate limiting.
Testing: Add X-API-KEY header with the key in Postman.

6. OAuth and OpenID Connect
Allows third-party login (e.g., Google) for Single Sign-On.
Security Tip: Ideal for apps needing third-party authentication.
Testing: Access /oauth/login to initiate OAuth login and follow redirect instructions.

Testing with Postman
Each authentication method can be tested using Postman. Access the Postman collection here: https://www.postman.com/aviation-specialist-85086927/in6206-individual-assignment-web-auth-examples/overview

# 🔐 ASP.NET Core Identity with External Logins

This project demonstrates how to integrate **ASP.NET Core Identity** with multiple **OAuth external login providers**, along with user **email confirmation**, **password reset**, and **traditional username/password login** features.

---
[![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blueviolet)](https://dotnet.microsoft.com/)
[![Live Demo](https://img.shields.io/badge/Live%20Demo-Click%20Here-brightgreen)](http://external-logins.runasp.net/)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Abdelrahman%20Zagloul-blue?logo=linkedin)](https://www.linkedin.com/in/abdelrahman-zagloul/)


## 🚀 Features

* ✅ External Login via:

  * Google
  * GitHub
  * Facebook
  * LinkedIn
  * Microsoft

* 📧 Email confirmation after registration

* 🔑 Forgot/Reset Password functionality

* 🔐 Manual login using username/email and password

* 🔒 Secure authentication using ASP.NET Core Identity

* 🧰 Clean and modular Identity setup

---

## ⚙️ Setup

1. Clone the repo:

   ```bash
   git clone https://github.com/your-username/your-repo.git
   ```

2. Add your `appsettings.json` (not included in repo) with OAuth credentials:

   ```json
   {
     "Authentication": {
       "Google": {
         "ClientId": "your-google-client-id",
         "ClientSecret": "your-google-secret"
       },
       "GitHub": {
         "ClientId": "your-github-client-id",
         "ClientSecret": "your-github-secret"
       },
       "Facebook": {
         "AppId": "your-facebook-app-id",
         "AppSecret": "your-facebook-secret"
       },
       "LinkedIn": {
         "ClientId": "your-linkedin-client-id",
         "ClientSecret": "your-linkedin-secret"
       },
       "Microsoft": {
         "ClientId": "your-microsoft-client-id",
         "ClientSecret": "your-microsoft-secret"
       }
     },
     "Email": {
       "SMTP": "smtp.example.com",
       "Port": 587,
       "Username": "your-email@example.com",
       "Password": "your-password"
     }
   }
   ```

3. Apply Migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the project:

   ```bash
   dotnet run
   ```

---

## 📧 Email Confirmation & Password Reset

* After registration, a confirmation email is sent to verify the user's email.
* If the user forgets their password, they can request a reset link via email.

---

## 🔐 Authentication Options

* External logins via OAuth2 providers (Google, GitHub, etc.)
* Manual login using traditional username/email and password

---


## 👨‍💻 Author

Abdelrahman Zaglol
.NET Developer | Computer Science Student
[LinkedIn](https://www.linkedin.com/in/abdelrahman-zagloul/)

---

## 📄 License

This project is licensed under the MIT License.

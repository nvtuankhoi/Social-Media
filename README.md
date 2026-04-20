# KSocial

A full-featured social media web application built with ASP.NET Core MVC, Entity Framework Core, and Tailwind CSS.

## Features

- **User Accounts** – Registration, login, profile pictures, and bios
- **Posts** – Create, edit, and delete posts with optional images; support for public/private visibility
- **Stories** – Time-limited story posts visible to friends
- **Comments & Likes** – Interact with posts through comments and likes
- **Favorites** – Save posts to a personal favorites list
- **Friends** – Send, accept, and manage friend requests
- **Hashtags** – Tag posts with hashtags and browse content by tag
- **Notifications** – Real-time notifications powered by SignalR
- **Reports** – Report inappropriate posts; reported posts tracked by an admin
- **Admin Panel** – Manage users and review reported content
- **Settings** – Update profile information and account preferences

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Authentication | ASP.NET Core Identity |
| Real-time | SignalR |
| Styling | Tailwind CSS |
| Build tool | Node.js / npm |

## Project Structure

```
KSocial.sln
├── KSocial/               # Web application (MVC)
│   ├── Controllers/       # Request handlers
│   ├── Views/             # Razor views
│   ├── ViewModels/        # View-specific models
│   ├── ViewComponents/    # Reusable view components
│   └── wwwroot/           # Static assets (CSS, JS, uploads)
└── KSocial.Data/          # Data access layer
    ├── Models/            # Entity models
    ├── Dtos/              # Data transfer objects
    ├── Services/          # Business logic services
    ├── Hubs/              # SignalR hubs
    ├── Migrations/        # EF Core database migrations
    └── AppDbContext.cs    # Database context
```

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version matching the project)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
- [Node.js & npm](https://nodejs.org/) (for building CSS)

### Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/nvtuankhoi/Social-Media.git
   cd Social-Media
   ```

2. **Configure the database connection**

   Update the connection string in `KSocial/appsettings.json`:

   ```json
   "ConnectionStrings": {
     "Default": "Server=<your-server>;Initial Catalog=KSocial;Integrated Security=True;TrustServerCertificate=True"
   }
   ```

3. **Build Tailwind CSS**

   ```bash
   cd KSocial
   npm install
   npm run css:build
   ```

4. **Run the application**

   ```bash
   cd ..
   dotnet run --project KSocial
   ```

   The application will automatically apply any pending database migrations and seed initial roles and users on first startup.

5. Open your browser and navigate to `https://localhost:<port>`.

## Development

To watch for CSS changes during development:

```bash
cd KSocial
npm run watch
```

## License

This project is provided for educational and personal use.

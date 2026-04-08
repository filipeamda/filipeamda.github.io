# Filipe Almeida - Professional Portfolio

[![Deploy Blazor WASM to GitHub Pages](https://github.com/filipeamda/filipeamda.github.io/actions/workflows/main.yml/badge.svg)](https://github.com/filipeamda/filipeamda.github.io/actions/workflows/main.yml)

This is my personal professional portfolio website, built with **Blazor WebAssembly** and **.NET 10**. It showcases my skills, experience, and professional journey as a .NET Developer.

## 🚀 Technologies

- **Frontend Framework:** [Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) (.NET 10.0)
- **Styling:** [Bootstrap 5.3](https://getbootstrap.com/)
- **Animations:** [GSAP (GreenSock Animation Platform)](https://greensock.com/gsap/)
- **Icons:** [Font Awesome 6](https://fontawesome.com/)
- **Deployment:** [GitHub Actions](https://github.com/features/actions) to [GitHub Pages](https://pages.github.com/)

## 🛠️ Project Structure

- **`Layout/`**: Contains the main layout components like `MainLayout` and `NavMenu`.
- **`Models/`**: C# classes representing the data structures for Bio, Experience, and Skills.
- **`Pages/`**: The main page components of the application.
- **`Services/`**: Contains the `DataService`, which handles fetching and caching the portfolio data from JSON files.
- **`wwwroot/`**:
    - `css/`: Application-specific styles.
    - `data/`: JSON files containing the portfolio content (`bio.json`, `experience.json`, `skills.json`).
    - `scripts/`: Custom JavaScript for animations and navbar behavior.

## 💻 Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Running Locally

1.  Clone the repository:
    ```bash
    git clone https://github.com/filipeamda/filipeamda.github.io.git
    cd filipeamda.github.io
    ```

2.  Run the application:
    ```bash
    dotnet watch run
    ```

3.  Open your browser and navigate to `http://localhost:5000` (or the port specified in the console).

## 🚢 Deployment

The project is automatically deployed to GitHub Pages whenever changes are pushed to the `main` branch via the [GitHub Actions workflow](.github/workflows/main.yml).

## 📄 License

This project is licensed under the [Apache License 2.0](LICENSE).

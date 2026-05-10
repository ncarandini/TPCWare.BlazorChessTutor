# TPCWare.BlazorChessTutor

A client-side Blazor WebAssembly app designed to run entirely in the browser.

## Run locally

```powershell
dotnet run
```

Then open the local URL shown in the terminal.

## Deploy to Azure Static Web Apps (Free)

This repo includes:

- `wwwroot/staticwebapp.config.json` for SPA routing and security headers.
- `.github/workflows/azure-static-web-apps.yml` for CI/CD deployment from GitHub.

### One-time setup

1. Push this repository to GitHub.
2. In Azure portal, create a **Static Web App** using the **Free** plan.
3. Connect the Static Web App to this GitHub repository and branch (`main`).
4. In the repository settings, add secret `AZURE_STATIC_WEB_APPS_API_TOKEN` from the Static Web App deployment token.

After setup, each push to `main` deploys the app automatically.

## Notes

- This is a static, browser-hosted app (no server-side rendering required).
- If you later add Azure Functions APIs, use the `api_location` setting in the workflow.

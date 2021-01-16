# Lucavice - Luca Vicenzotti Blog

A blog template, built with [Orchard Core CMS (RC2)](https://github.com/OrchardCMS/OrchardCore) and [Tailwind](https://tailwindcss.com/).

![screen](./src/theme/wwwroot/Theme.png)

Live demo on https://blog.lucavice.com

This repository contains the source code of my blog, which includes:

- **src/website/Lucavice.Website**: the actual web application, which includes the references necessary to boot up **Orchard Core**
- **src/theme/Lucavice.TailwindTheme**: an Orchard Core theme built with Tailwind.
- **src/modules/Lucavice.BunnyCDN**: an Orchard Core module that automatically purges the full-page cache of the blog posts on BunnyCDN. This allows me to serve the entire site through BunnyCDN, and invalidate the stale content during publication.

## Getting Started

### Requirements for development
- Node.js with npm
- .NET Core SDK 3.1 LTS

### Requirements for deployed app
- .NET Core Runtime 3.1 LTS

### Setup

To startup Orchard Core with this theme, simply:
```
git clone https://github.com/lucavice/lucavice-site.git
cd lucavice-site\src\website
dotnet run
```

If you go to your browser to https://localhost:5001, you should see Orchard Core setup screen. You must select *Lucavice* as recipe in the recipes dropdown, in order to enable and select the custom theme.

Fill in the rest of information as desired, the click *finish setup*.

You should now see the same result as the screenshot shown above :)

## Tailwind: how it works

When the application is built with ```dotnet build``` (implicitly called by ```dotnet run```), we are also kicking off a build task for producing the final css.
In fact, msbuild kicks off  ```npm run build``` in the *theme* folder, with is an alias for a *gulp* task called *css*.

This task starts a PostCSS build that takes ```tailwind.config.js``` and ```Styles\lucavice.css```, and converts them to the final css output in ```wwwroot\assets\dist\css\lucavice.css```

You will notice that the css file is *very* large. This is because Tailwind is generating all possible combinations of css classes. This is useful during development, as you can freely use most utility classes provided by Tailwind without rebuilding.

When you are ready to deploy your application to production, you can use the command ```npm run build-prod```, which will include purge and minification subtaks, bringing down the css size from about 2000kb to 8kb (a total of only 3kb gzipped!). You don't have to call this task explicitly in a CI/CD environment, as it is triggered automatically by msbuild if you are building in ```Release``` mode.

Checkout the ```gulp.js``` file to see how it works.

## Customization

You can change the ```.liquid``` templates provided in the ```Views``` folder, all the css is inlined with Tailwind utility classes.

You can also change the theme base colors by modifying the palette colors in ```tailwind.config.js```.

Remember that whenever you change either ```tailwind.config.js``` or ```Styles\lucavice.css```, you will have to re-run the gulp task to regenerate the Tailwind classes.

## Deploy

I deployed this app on Azure App Service. You will find a Github Action under ```.github\workflows\lucavice-blog.yml``` to see what's going on in the CI/CD process (it's essentially the default template for .NET Core apps on the app service)

You should be able to deploy this blog template easily on a Windows, Linux or containerized environment. You can follow standard processes on the Orchard Core documentation.








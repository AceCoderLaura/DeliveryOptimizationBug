using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace PackageHost
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var packageFolderProvider = new PhysicalFileProvider(env.ContentRootPath + @"\..\PackageApplication.Package\AppPackages\");

            app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = { "index.html" }, FileProvider = packageFolderProvider });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = packageFolderProvider,
                ServeUnknownFileTypes = true,
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings =
                    {
                        { ".appinstaller", "application/xml" },
                        { ".appx", "application/vns.ms-appx" },
                        { ".appxbundle", "application/vns.ms-appx" },
                        { ".msix", "application/vns.ms-appx" },
                        { ".msixbundle", "application/vns.ms-appx" }
                    }
                }
            });

            app.UseRouting();
        }
    }
}
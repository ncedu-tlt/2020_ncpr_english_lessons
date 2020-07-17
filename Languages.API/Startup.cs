using Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddEntityFrameworkSqlite().AddDbContext<DataBaseContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add CORS header
            app.Use((context, next) =>
            {
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                return next.Invoke();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(ROOT_PAGE_HTML);
                });
            });
        }
            
        private const string ROOT_PAGE_HTML = "<!DOCTYPE html>" +
                                                "<html>" +
                                                "<body>" +
                                                "<p>Languages</p>" +
                                                "<p>GET <a target='_blank' rel='noopener noreferrer' href='/api/languages'>/api/languages</a></p>" +
                                                "<p>GET <a target='_blank' rel='noopener noreferrer' href='/api/languages/1'>/api/languages/1</a></p>" +
                                                "<p>POST <a target='_blank' rel='noopener noreferrer' href='/api/languages'>/api/languages</a> (BODY: \"Content-Type: application/json\" {\"title\" : \"newLanguage\"})</p>" +
                                                "<p>PUT <a target='_blank' rel='noopener noreferrer' href='/api/languages'>/api/languages</a> (BODY: \"Content-Type: application/json\" {\"title\" : \"newLanguage\" \"languageId\": 6})</p>" +
                                                "<p>DELETE <a target='_blank' rel='noopener noreferrer' href='/api/languages'>/api/languages</a> (BODY: \"Content-Type: application/json\" {\"title\" : \"newLanguage\" \"languageId\": 6})</p>" +

                                                "<p>GET <a target='_blank' rel='noopener noreferrer' href='/api/reset'>/api/reset</a></p>" +

                                                "<p>Courses</p>" +
                                                "<p>GET <a target='_blank' rel='noopener noreferrer' href='/api/courses'>/api/courses</a></p>" +
                                                "<p>GET <a target='_blank' rel='noopener noreferrer' href='/api/courses/1'>/api/courses/1</a></p>" +
                                                
                                                "</body>" +
                                                "</html>";
    }
}

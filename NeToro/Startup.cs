using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NeToro.Api.Infrastructure;
using NeToro.BL.Contracts;
using NeToro.BL.Services;
using NeToro.DAL.Configuration;
using NeToro.DAL.PaymentCard;
using NeToro.DAL.PaymentCard.Contracts;
using NeToro.DAL.Profile;
using NeToro.DAL.Profile.Contracts;
using NeToro.DAL.User;
using NeToro.DAL.User.Contracts;
using NeToro.Interfaces.Inputs.PaymentCard;
using NeToro.Interfaces.Inputs.User;
using NeToro.Validation;

namespace NeToro
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddFluentValidation();//options => options.RegisterValidatorsFromAssemblyContaining(typeof(Startup)));
            
            services.AddTransient<IValidator<UserInputModel>,UserValidator>();
            services.AddTransient<IValidator<PaymentCardInputModel>, PaymentCardValidator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NeToro", Version = "v1" });
            });

            services.Configure<DatabaseOptions>(configuration.GetSection(Constants.Settings.DatabaseSection));

            services.AddTransient<IPaymentCardService, PaymentCardService>();
            services.AddTransient<IPaymentCardManagment, PaymentCardManagement>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IProfileManagment, ProfileManagment>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserManagement, UserManagement>();
            services.AddTransient<IPasswordHandler, PasswordHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NeToro v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasieR.Api.Core;
using EasieR.Application;
using EasieR.Application.Commands;
using EasieR.Application.Commands.EventCommand;
using EasieR.Application.Commands.LocationCommand;
using EasieR.Application.Commands.PlaceCommand;
using EasieR.Application.Commands.ReservationCommand;
using EasieR.Application.Commands.RolesCommand;
using EasieR.Application.Commands.UserCommand;
using EasieR.Application.Queries.AuditQueries;
using EasieR.Application.Queries.EventQueries;
using EasieR.Application.Queries.Images;
using EasieR.Application.Queries.LocationQueries;
using EasieR.Application.Queries.PlaceQueries;
using EasieR.Application.Queries.ReservationQueries;
using EasieR.Application.Queries.RolesQueries;
using EasieR.Application.Queries.SeatTable;
using EasieR.Application.Queries.UserQueries;
using EasieR.DataAccess;
using EasieR.Implementation.Commands;
using EasieR.Implementation.Commands.AuditLogCommand;
using EasieR.Implementation.Commands.EventCommand;
using EasieR.Implementation.Commands.ImageCommand;
using EasieR.Implementation.Commands.LocationCommand;
using EasieR.Implementation.Commands.PlaceCommand;
using EasieR.Implementation.Commands.ReservationCommand;
using EasieR.Implementation.Commands.RolesCommand;
using EasieR.Implementation.Commands.SeatTableCommand;
using EasieR.Implementation.Commands.UserCommand;
using EasieR.Implementation.Mappers;
using EasieR.Implementation.Validations;
using EasieR.Implementation.Validations.EventValidations;
using EasieR.Implementation.Validations.LocationValidations;
using EasieR.Implementation.Validations.PlaceValidations;
using EasieR.Implementation.Validations.ReservationValidations;
using EasieR.Implementation.Validations.RolesValidations;
using EasieR.Implementation.Validations.UserValidations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nedelja7.Api.Core;
using Newtonsoft.Json;

namespace EasieR.Api
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
            services.AddTransient<EasieRContext>();

            services.AddTransient<ICreateRoleCommand, CreateRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, UpdateRoleCommand>();
            services.AddTransient<IGetRolesQuery, GetRolesQuery>();
            services.AddTransient<IGetOneRoleQuery, GetOneRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, DeleteRoleCommand>();

            services.AddTransient<RoleValidator>();
            services.AddTransient<UpdateRoleValidator>();

            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IGetOneUserQuery, GetOneUserCommand>();
            services.AddTransient<IGetUsersQuery, GetUsersCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();

            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();

            services.AddTransient<ICreateLocationCommand, CreateLocationCommand>();
            services.AddTransient<IUpdateLocationCommand, UpdateLocationCommand>();
            services.AddTransient<IGetOneLocationQuery, GetOneLocationCommand>();
            services.AddTransient<IGetLocationQuery, GetLocationsCommand>();
            services.AddTransient<IDeleteLocationCommand, DeleteLocationCommand>();

            services.AddTransient<CreateLocationValidator>();

            services.AddTransient<ICreatePlaceCommand, CreatePlaceCommand>();
            services.AddTransient<IUpdatePlaceCommand, UpdatePlaceCommand>();
            services.AddTransient<IGetOnePlaceQuery, GetOnePlaceCommand>();
            services.AddTransient<IGetPlacesQuery, GetPlacesCommand>();
            services.AddTransient<IDeletePlaceCommand, DeletePlaceCommand>();
            services.AddTransient<IGetPlaceStaffQuery, GetPlaceStaffCommand>();


            services.AddTransient<CreatePlaceValidator>();
            services.AddTransient<UpdatePlaceValidator>();

            services.AddTransient<ICreateEventCommand, CreateEventCommand>();
            services.AddTransient<IUpdateEventCommand, UpdateEventCommand>();
            services.AddTransient<IGetOneEventQuery, GetOneEventCommand>();
            services.AddTransient<IGetEventsQuery, GetEventsCommand>();
            services.AddTransient<IDeleteEventCommand, DeleteEventCommand>();

            services.AddTransient<CreateEventValidator>();
            services.AddTransient<UpdateEventValidator>();

            services.AddTransient<ICreateReservationCommand, CreateReservationCommand>();
            services.AddTransient<IUpdateReservationCommand, UpdateReservationCommand>();
            services.AddTransient<IDeleteReservationCommand, DeleteReservationCommand>();
            services.AddTransient<IGetOneReservationQuery, GetOneReservationCommand>();
            services.AddTransient<IGetReservationsQuery, GetReservationsCommand>();

            services.AddTransient<CreateReservationValidator>();
            services.AddTransient<UpdateReservationValidator>();

            services.AddTransient<IGetAuditLogs, GetAuditLogsCommand>();

            services.AddTransient<IGetSeatTablesQuery, GetSeatTablesCommand>();

            services.AddTransient<IGetImagesQuery, GetImagesCommand>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IApplicationActor>(x => {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    throw new InvalidOperationException("Actor data doesnt exist in token.");
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });
            services.AddTransient<UseCasesExecutor>();
            services.AddTransient<IUseCaseLogger, LoggerCommand>();
            services.AddTransient<JwtManager>();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


            services.AddAutoMapper(typeof(RoleProfile), typeof(UserProfile), typeof(LocationProfile), typeof(PlaceProfile), typeof(EventProfile), typeof(SeatTableProfile), typeof(ImageProfile), typeof(ReservationProfile));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}

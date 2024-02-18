using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
	public static class ServiceExtensions
	{
		public static void AddAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}

		public static void AddFluentValidators(this IServiceCollection services)
		{
			services.AddFluentValidationAutoValidation();
			services.AddFluentValidationClientsideAdapters();
			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
		}

		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddScoped<IAdvertsService, AdvertisementsService>();
            services.AddScoped<IOrdersService, OrdersService>();

        }
	}
}

using Microsoft.Extensions.DependencyInjection;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.Interfaces;
using SImaraMaharramli_Pasha.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            //services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IVacancyApplicationService, ApplicationService>();
            services.AddScoped<IQuestionService, QuestionService>();
            //services.AddScoped<TicketValidation, TicketValidation>();
            //services.AddScoped<PriceCalculator, PriceCalculator>();
            //services.AddScoped<ITicketService, TicketService>();
            //services.AddScoped<IStoryService, StoryService>();
            //services.AddScoped<IEmailService, EMailService>();
            //services.AddScoped<EmailSettings>();
            //services.AddScoped<IRealEstate, RealEstateService>();

            //services.AddScoped<IHotelService, HotelService>();
            //services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<ILocalizing, LocalizingService>();
            //services.AddScoped<IEntertainmentService, EntertainmentService>();
            //services.AddScoped<INewsService, NewsService>();
            //services.AddScoped<IMapService, MapService>();
            //services.AddScoped<IRestaurantService, RestaurantService>();
            //services.AddScoped<INotifyService, NotifyService>();
            //services.AddScoped<ICommunalService, CommunalService>();
            //services.AddScoped<IFitnessService, FitnessService>();
            //services.AddScoped<IStoreService, StoreService>();
            return services;
        }
    }
}

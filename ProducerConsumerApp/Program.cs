using ProducerConsumerApp.Infrastructure.API;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using ProducerConsumerApp.Core.Repository;
using ProducerConsumerApp.Core.Models;
using ProducerConsumerApp.Infrastructure.Repository.InMemory;
using ProducerConsumerApp.Core.Services;
using ProducerConsumerApp.Core.Services.Default;
using ProducerConsumerApp.Core.API;
using ProducerConsumerApp.Core.MockDataFactory;
using ProducerConsumerApp.Infrastructure.DataFactory;
using ProducerConsumerApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICreatureRepository<Tribble>, TribbleRepository>();
builder.Services.AddSingleton<IDataConsumer<Tribble>, DataConsumer<Tribble>>();
builder.Services.AddSingleton<ITrackingDataConsumer<Tribble>, TrackingDataConsumer<Tribble>>();
builder.Services.AddSingleton<IDataProducer<Tribble>, DataProducer<Tribble>>();
builder.Services.AddSingleton<ICreatureApi<Tribble>, TribbleApi>();
builder.Services.AddSingleton<ICreateMockData<Tribble>, TribbleFactory>();
builder.Services.AddSingleton<IProducerConsumerService<Tribble>, TribbleProducerConsumerService>();

builder.Services.AddTransient<MockDataHttpDelegatingHandler>();

builder.Services.AddHttpClient("ApiClient")
    .ConfigureHttpClient(config => {
        config.BaseAddress = new Uri("http://localhost:1234");
    })
    .AddHttpMessageHandler<MockDataHttpDelegatingHandler>();

builder.Services.AddHostedService<ProducerConsumerExecutor>();

var app = builder.Build();

app.Run();
